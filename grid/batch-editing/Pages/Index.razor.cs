using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;
using Telerik.Blazor;
using BatchEditingMimic.Data;

namespace BatchEditingMimic.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        BatchEditingService theService { get; set; }
        public ObservableCollection<BatchEditModel> LocalData { get; set; }
        private List<BatchEditModel> PristineItems { get; set; } = new List<BatchEditModel>();

        public IEnumerable<BatchEditModel> SelectedItems { get; set; } = Enumerable.Empty<BatchEditModel>();

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
            BatchEditModel localItem = GetItemFromCollection(LocalData, item);

            if (!item.IsDirty)
            {
                BatchEditModel pristineItm = GetItemFromCollection(PristineItems, item);
                if (pristineItm == null)
                {
                    //add only the first time a field is edited, later it is no longer pristine
                    PristineItems.Add(localItem);
                }
            }

            item.IsChanged = true;
            ChangeLocalItem(item);
        }

        public void CreateHandler(GridCommandEventArgs args)
        {
            BatchEditModel item = (BatchEditModel)args.Item;
            item.Id = LocalData.Count + 1;
            item.IsNew = true;
            LocalData.Insert(0, item);
        }

        public void DeleteHandler(GridCommandEventArgs args)
        {
            BatchEditModel item = (BatchEditModel)args.Item;

            DeleteItem(item);

            //show notification for undelete
        }

        public bool GridIsDirty()
        {
            return LocalData.ToList().Exists(itm => itm.IsDirty);
        }

        public bool SelectionIsDirty()
        {
            return SelectedItems.ToList().Exists(itm => itm.IsDirty);
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

        public async Task RevertAllChanges()
        {
            for (int i = LocalData.Count - 1; i >= 0; i--)
            {
                if (LocalData[i].IsDirty)
                {
                    await RevertItem(LocalData[i]);
                }
            }
            StateHasChanged();
        }

        public async Task UndeleteItem(BatchEditModel itmToUndelete)
        {
            BatchEditModel itm = GetItemFromCollection(LocalData, itmToUndelete);
            if (itm != null)
            {
                itm.IsDeleted = false;
            }
        }

        public async Task RevertItem(BatchEditModel itmToUndelete)
        {
            if (itmToUndelete.IsNew)
            {
                LocalData.Remove(itmToUndelete);
            }
            if (itmToUndelete.IsDeleted)
            {
                itmToUndelete.IsDeleted = false;
                ChangeLocalItem(itmToUndelete);
            }
            if (itmToUndelete.IsChanged)
            {
                BatchEditModel pristineItem = GetItemFromCollection(PristineItems, itmToUndelete);
                if (pristineItem != null)
                {
                    itmToUndelete = pristineItem;
                    ChangeLocalItem(itmToUndelete);
                    PristineItems.Remove(pristineItem);
                }
            }
        }

        public async Task RevertSelected()
        {
            foreach (BatchEditModel item in SelectedItems)
            {
                await RevertItem(item);
            }
        }

        public async Task DeleteItem(BatchEditModel itmToDelete)
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

        public async Task DeleteSelected()
        {
            foreach (BatchEditModel item in SelectedItems)
            {
                await DeleteItem(item);
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
