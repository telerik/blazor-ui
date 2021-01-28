using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using Telerik.DataSource;

namespace Loccioni.DataSource
{
    public class DataSourceRequestBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(DataSourceRequest))
            {
                return new BinderTypeModelBinder(typeof(DataSourceRequestBinder));
            }

            return null;
        }
    }
}
