using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingCoffee.Client.Shared.Layouts;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Services;

namespace BlazingCoffee.Client.Shared
{
    public class CoffeeComponentBase : ComponentBase
    {
        [Inject] internal MainLayoutState Layout { get; set; }
        [Inject] public ITelerikStringLocalizer Localizer { get; set; }

        protected override void OnInitialized()
        {
            Layout.DocsPath = GetType().Name;
        }
    }
}
