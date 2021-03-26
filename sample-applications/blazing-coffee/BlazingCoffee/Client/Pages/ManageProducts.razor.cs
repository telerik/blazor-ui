using BlazingCoffee.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Telerik.Blazor;
using Telerik.Blazor.Components;

namespace BlazingCoffee.Client.Pages
{
    public partial class ManageProducts
    {
        [Inject] HttpClient Http { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        #region Grid Operations
        bool isLoading = true;
        bool hasErrors;
        bool isIdVisible = false;
        ObservableCollection<Product> Products { get; set; }
        IEnumerable<string> Groups { get; set; }

        TelerikNotification CrudNotification { get; set; }

        ConfirmationDialog DeleteDialog { get; set; }

        async Task ShowDialog(GridCommandEventArgs args)
        {
            var argsItem = (Product)args.Item;

            bool result = await DeleteDialog.ShowConfirmAsync(L["ConfirmDialog_AreYouSure"], string.Format(L["ManageProducts_ConfirmDelete"], argsItem.Sku));
            args.IsCancelled = !result;
        }

        protected override void OnInitialized()
        {
            Layout.DocsTitle = L["ManageProducts"];

            base.OnInitialized();
        }

        protected override Task OnInitializedAsync() => LoadData();

        Task LoadData() => TryLoadDataAsync(LoadDataSuccess, LoadDataError);

        void LoadDataSuccess(Product[] data)
        {
            Products = new ObservableCollection<Product>(data);
            hasErrors = false;
        }

        void LoadDataError(Exception ex)
        {
            // Further Devlopment: Implement ILogger<T>
            // logger.LogWarning("You may want to log exceptions here");
            hasErrors = true;
        }

        async Task LoadGroups(GridCommandEventArgs args)
        {
            try
            {
                var response = await Http.GetAsync("api/products/groups");
                response.EnsureSuccessStatusCode();

                Groups = await response.Content.ReadFromJsonAsync<IEnumerable<string>>();
                StateHasChanged();
            }
            catch (Exception)
            {
                args.IsCancelled = true;
                CrudNotification.Show(new()
                {
                    Text = L["DatabaseConnectionError"],
                    ThemeColor = ThemeColors.Error
                });
            }
        }

        async Task TryLoadDataAsync(Action<Product[]> success, Action<Exception> fail)
        {
            isLoading = true;
            try
            {
                var data = await Http.GetFromJsonAsync<Product[]>("api/products");
                success(data);
            }
            catch (Exception e)
            {
                fail(e);
            }
            finally
            {
                isLoading = false;
            }
        }

        async Task CreateItem(GridCommandEventArgs args)
        {
            var argsItem = (Product)args.Item;
            var httpResponseMessage = await Http.PostAsJsonAsync<Product>($"api/products", argsItem);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var newItem = await httpResponseMessage.Content.ReadFromJsonAsync<Product>();
                Products.Insert(0, newItem);
                CrudNotification.Show(new()
                {
                    Text = string.Format(L["ManageProducts_Create_Success"], newItem.Sku),
                    ThemeColor = ThemeColors.Success
                });
            }
        }

        async Task DeleteItem(GridCommandEventArgs args)
        {
            var argsItem = (Product)args.Item;
            var httpResponseMessage = await Http.DeleteAsync($"api/products/{argsItem.Id}");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                Products.Remove(argsItem);
                CrudNotification.Show(new()
                {
                    Text = string.Format(L["ManageProducts_Delete_Success"], argsItem.Sku),
                    ThemeColor = ThemeColors.Success
                });
            }
        }

        async Task UpdateItem(GridCommandEventArgs args)
        {
            var argsItem = (Product)args.Item;
            var httpResponseMessage = await Http.PutAsJsonAsync<Product>($"api/products/{argsItem.Id}", argsItem);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var productToUpdate = Products.First(p => p.Id == argsItem.Id);
                productToUpdate.Cost = argsItem.Cost;
                productToUpdate.Sku = argsItem.Sku;
                productToUpdate.Group = argsItem.Group;
                CrudNotification.Show(new()
                {
                    Text = string.Format(L["ManageProducts_Update_Success"], argsItem.Sku),
                    ThemeColor = ThemeColors.Success
                });
            }
        }
        #endregion

        #region File Upload

        List<string> AllowedExtensions => new List<string> { ".pdf" };
        public string SaveUrl => $"{NavigationManager.BaseUri}api/products/addfile";

        async Task OnUploadHandler(UploadEventArgs e, int productId)
        {
            e.RequestData.Add("productId", productId);
        }

        async Task OnSuccessHandler(Product product)
        {
            // After the file uploads, get the new file name from the server and update the grid item
            product = await Http.GetFromJsonAsync<Product>($"api/products/{product.Id}");
            Products.First(p => p.Id == product.Id).NutritionFileName = product.NutritionFileName;
        }

        #endregion
    }
}
