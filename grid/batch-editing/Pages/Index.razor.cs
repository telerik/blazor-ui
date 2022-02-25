using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;
using Telerik.Blazor;
using BatchEditing.Data;

namespace BatchEditing.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        BatchEditingService theService { get; set; }
        public ObservableCollection<BatchEditModel> LocalData { get; set; }
        private List<BatchEditModel> PristineItems { get; set; } = new List<BatchEditModel>();
        public IEnumerable<BatchEditModel> SelectedItems { get; set; } = Enumerable.Empty<BatchEditModel>();

        public bool GridIsDirty => LocalData.ToList().Exists(itm => itm.IsDirty);

        public bool SelectionIsDirty => SelectedItems.ToList().Exists(itm => itm.IsDirty);

        protected override async Task OnInitializedAsync()
        {
            await FetchData();
        }

        private async Task FetchData()
        {
            LocalData = new ObservableCollection<BatchEditModel>(await theService.GetData());
        }

        public void EditHandler(GridCommandEventArgs args)
        {
            BatchEditModel item = (BatchEditModel)args.Item;

            //prevent opening for edit for deleted items
            if (item.IsDeleted)
            {
                args.IsCancelled = true;
            }

            //show notification
        }

        public void UpdateHandler(GridCommandEventArgs args)
        {
            BatchEditModel item = (BatchEditModel)args.Item;

            if (!item.IsDirty)
            {
                BatchEditModel pristineItem = GetItemFromCollection(PristineItems, item);
                if (pristineItem == null)
                {
                    //add only the first time a field is edited, later it is no longer pristine
                    PristineItems.Add(GetItemFromCollection(LocalData, item));
                }
            }

            item.IsChanged = true;
            ChangeLocalItem(item);
        }

        public void CreateHandler(GridCommandEventArgs args)
        {
            BatchEditModel item = (BatchEditModel)args.Item;
            item.Id = LocalData.Max(model => model.Id) + 1;
            item.IsNew = true;
            LocalData.Insert(0, item);
        }

        public void DeleteHandler(GridCommandEventArgs args)
        {
            BatchEditModel item = (BatchEditModel)args.Item;

            DeleteItem(item);

            //show notification for undelete
        }

        private void ChangeLocalItem(BatchEditModel item)
        {
            var index = LocalData.ToList().FindIndex(i => i.Id == item.Id);
            if (index != -1)
            {
                LocalData[index] = item;
            }
        }

        public async Task SaveAllChanges()
        {
            List<BatchEditModel> deletedItems = LocalData.Where(itm => itm.IsDeleted == true).ToList();
            List<BatchEditModel> newItems = LocalData.Where(itm => itm.IsNew == true).ToList();
            List<BatchEditModel> updatedItems = LocalData.Where(itm => itm.IsChanged == true && itm.IsDeleted == false).ToList();

            // clean up current data and selection
            LocalData.Clear();
            SelectedItems = Enumerable.Empty<BatchEditModel>();

            // update the grid with the data from the service
            List<BatchEditModel> newData = await theService.BatchUpdate(deletedItems, newItems, updatedItems);
            LocalData = new ObservableCollection<BatchEditModel>(newData);
        }

        public void RevertAllChanges()
        {
            for (int i = LocalData.Count - 1; i >= 0; i--)
            {
                if (LocalData[i].IsDirty)
                {
                    RevertItem(LocalData[i]);
                }
            }
            StateHasChanged();
        }

        public void RestoreItem(BatchEditModel item)
        {
            BatchEditModel localItem = GetItemFromCollection(LocalData, item);
            if (localItem != null)
            {
                localItem.IsDeleted = false;
            }
        }

        public void RevertItem(BatchEditModel item)
        {
            if (item.IsNew)
            {
                LocalData.Remove(item);
            }
            if (item.IsDeleted)
            {
                item.IsDeleted = false;
                ChangeLocalItem(item);
            }
            if (item.IsChanged)
            {
                BatchEditModel pristineItem = GetItemFromCollection(PristineItems, item);
                if (pristineItem != null)
                {
                    ChangeLocalItem(pristineItem);
                    PristineItems.Remove(pristineItem);
                }
            }
        }

        public void RevertSelected()
        {
            foreach (BatchEditModel item in SelectedItems)
            {
                RevertItem(item);
            }
        }

        public void DeleteItem(BatchEditModel itmToDelete)
        {
            BatchEditModel localItem = GetItemFromCollection(LocalData, itmToDelete);
            if (localItem != null)
            {
                if (localItem.IsDeleted)
                {
                    return;
                }
                else if (localItem.IsNew)
                {
                    LocalData.Remove(localItem);
                }
                else
                {
                    localItem.IsDeleted = true;
                }
            }
        }

        public void DeleteSelected()
        {
            foreach (BatchEditModel item in SelectedItems)
            {
                DeleteItem(item);
            }
        }

        private BatchEditModel GetItemFromCollection(IList<BatchEditModel> collection, BatchEditModel itmToFind)
        {
            var index = collection.ToList().FindIndex(i => i.Id == itmToFind.Id);
            if (index != -1)
            {
                return collection[index];
            }
            return null;
        }

    }
}
