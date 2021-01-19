using System;
using System.Linq;
using BlazingCoffee.Shared.Models;
using Telerik.Blazor.Components;
using Telerik.DataSource;

namespace BlazingCoffee.Client.Pages.SalesReports
{
    public static class SalesExtensions
    {
        public static FilterDescriptor TransactionDateFilters(this GridState<Sale> gridState, 
            Func<FilterDescriptor, bool> predicate) =>
                gridState.FilterDescriptors
                    .OfType<FilterDescriptor>()
                    .Where(f=> f.Member == "TransactionDate")
                    .First(predicate);
    }
}