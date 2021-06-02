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
        // using the null-forgiving operator on injected services. This is likely automatic in .NET 6
        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-forgiving

        [Inject]
        HttpClient Http { get; set; } = default!;

        [Inject]
        NavigationManager NavigationManager { get; set; } = default!;

        [CascadingParameter]
        public DialogFactory Dialogs { get; set; } = default!;

        #region Grid Operations

        bool isLoading = true;
        bool hasErrors;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "Data bound value")]
        bool isIdVisible;

        ObservableCollection<Product> Products { get; set; } = new();
        IEnumerable<string>? Groups { get; set; }
        TelerikNotification? CrudNotification { get; set; }

        protected override void OnInitialized()
        {
            Layout.DocsTitle = L["ManageProducts"];

            base.OnInitialized();
        }
        protected override Task OnInitializedAsync() => LoadData();
        Task LoadData() => TryLoadDataAsync(LoadDataSuccess, LoadDataError);
        async Task TryLoadDataAsync(Action<Product[]> success, Action<Exception> fail)
        {
            isLoading = true;
            try
            {
                var response = await Http.GetAsync("api/products");
                response.EnsureSuccessStatusCode();

                Product[]? data = await response.Content.ReadFromJsonAsync<Product[]>();

                success(data ?? Array.Empty<Product>());
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
        void LoadDataSuccess(Product[] data)
        {
            Products = new ObservableCollection<Product>(data);
            hasErrors = false;
        }
        void LoadDataError(Exception ex)
        {
            // Further Devlopment: Implement
            //
            // ILogger<T>
            // logger.LogWarning("You may want to log exceptions here");
            hasErrors = true;
        }

        #region Edit Operations

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
                ShowDataConnectionError();
            }
        }
        async Task CreateItem(GridCommandEventArgs args)
        {
            try
            {
                Product product = (Product)args.Item;
                var httpResponseMessage = await Http.PostAsJsonAsync($"api/products", product);

                httpResponseMessage.EnsureSuccessStatusCode();

                Product? newProduct = await httpResponseMessage.Content.ReadFromJsonAsync<Product>();

                // Something has gone wrong with the generated response
                if (newProduct is null) throw new NullReferenceException();

                Products.Insert(0, newProduct);
                CrudNotification?.Show(new()
                {
                    Text = string.Format(L["ManageProducts_Create_Success"], newProduct.Sku),
                    ThemeColor = ThemeColors.Success
                });
            }
            catch (Exception)
            {
                ShowDataConnectionError();
            }
        }
        async Task UpdateItem(GridCommandEventArgs args)
        {
            try
            {
                Product product = (Product)args.Item;
                var httpResponseMessage = await Http.PutAsJsonAsync($"api/products/{product.Id}", product);

                httpResponseMessage.EnsureSuccessStatusCode();

                Product productToUpdate = Products.First(p => p.Id == product.Id);
                productToUpdate.Cost = product.Cost;
                productToUpdate.Sku = product.Sku;
                productToUpdate.Group = product.Group;

                CrudNotification?.Show(new()
                {
                    Text = string.Format(L["ManageProducts_Update_Success"], product.Sku),
                    ThemeColor = ThemeColors.Success
                });
            }
            catch (Exception)
            {
                ShowDataConnectionError();
            }

        }
        async Task DeleteItem(GridCommandEventArgs args)
        {
            try
            {
                Product product = (Product)args.Item;
                var httpResponseMessage = await Http.DeleteAsync($"api/products/{product.Id}");

                httpResponseMessage.EnsureSuccessStatusCode();

                Products.Remove(product);
                CrudNotification?.Show(new()
                {
                    Text = string.Format(L["ManageProducts_Delete_Success"], product.Sku),
                    ThemeColor = ThemeColors.Success
                });
            }
            catch (Exception)
            {
                ShowDataConnectionError();
            }
        }
        async Task ShowConfirmationDialog(GridCommandEventArgs args)
        {
            var argsItem = (Product)args.Item;

            bool result = await Dialogs.ConfirmAsync(L["ConfirmDialog_AreYouSure"], string.Format(L["ManageProducts_ConfirmDelete"], argsItem.Sku));
            args.IsCancelled = !result;
        }
        void ShowDataConnectionError() =>
            CrudNotification?.Show(new()
            {
                Text = L["DatabaseConnectionError"],
                ThemeColor = ThemeColors.Error
            });

        #endregion

        #endregion

        #region File Upload

        static List<string> AllowedExtensions => new() { ".pdf" };
        public string SaveUrl => $"{NavigationManager.BaseUri}api/products/addfile";

        static void OnUploadHandler(UploadEventArgs e, int productId)
        {
            e.RequestData.Add("productId", productId);
            // If the application uses authentication
            // An authorization token can be resolved during this event
            // Example:
            // var tokenResult = await accessTokenProvider.RequestAccessToken();
            // tokenResult.TryGetToken(out var token);
            // e.RequestHeaders.Add("authorization", $"Bearer {token.Value}");
        }

        async Task OnSuccessHandler(Product product)
        {
            try
            {
                // After the file uploads, get the new file name from the server and update the grid item
                Product? updatedProduct = await Http.GetFromJsonAsync<Product>($"api/products/{product.Id}");

                Products.Single(p => p.Id == product.Id).NutritionFileName = updatedProduct?.NutritionFileName;
            }
            catch (Exception)
            {
                ShowDataConnectionError();
            }


        }

        #endregion
    }
}
