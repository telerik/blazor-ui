using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;
using Telerik.DataSource;

namespace Loccioni.DataSource
{
    public class DataSourceRequestBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            DataSourceRequest request = new DataSourceRequest();

            var pageValueProviderResult = bindingContext.ValueProvider.GetValue(GridUrlParameters.Page);
            if (pageValueProviderResult != ValueProviderResult.None)
            {
                if (int.TryParse(pageValueProviderResult.FirstValue, out var page))
                {
                    request.Page = page;
                }
            }

            var pageSizeValueProviderResult = bindingContext.ValueProvider.GetValue(GridUrlParameters.PageSize);
            if (pageSizeValueProviderResult != ValueProviderResult.None)
            {
                if (int.TryParse(pageSizeValueProviderResult.FirstValue, out var pageSize))
                {
                    request.PageSize = pageSize;
                }
            }

            var sortValueProviderResult = bindingContext.ValueProvider.GetValue(GridUrlParameters.Sort);
            if (sortValueProviderResult != ValueProviderResult.None)
            {
                request.Sorts = GridDescriptorSerializer.Deserialize<SortDescriptor>(sortValueProviderResult.FirstValue);
            }

            var filterValueProviderResult = bindingContext.ValueProvider.GetValue(GridUrlParameters.Filter);
            if (filterValueProviderResult != ValueProviderResult.None)
            {
                request.Filters = FilterDescriptorFactory.Create(filterValueProviderResult.FirstValue);
            }

            bindingContext.Result = ModelBindingResult.Success(request);

            return Task.CompletedTask;
        }
    }

}
