using Bunit;
using BUnit_Sample.Model;
using BUnit_Sample.Pages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Telerik.Blazor.BUnit.Common;
using Telerik.Blazor.Components;
using Telerik.Blazor.Components.RootComponent;
using Telerik.JustMock;
using Xunit;

namespace Telerik.Blazor.BUnit
{
    public class GridPage
    {
        [Fact]
        public void DetailTemplate_is_rendered()
        {
            using var ctx = new TelerikTestContext();

            ctx.AddTelerikBlazor();

            var gridPage = ctx.RenderComponent<Grid>();

            var grid = gridPage.FindComponent<TelerikGrid<Person>>();

            var firstHierarchyCell = grid.Find(".k-grid-table tr:first-child .k-hierarchy-cell");

            firstHierarchyCell.Click();

            Assert.Contains("<span>DetailTemplate for Employee 0</span>", grid.Markup);
        }

        [Fact]
        public void ItemTemplate_is_rendered()
        {
            using var ctx = new TelerikTestContext();

            ctx.AddTelerikBlazor();

            var gridPage = ctx.RenderComponent<Grid>();

            var grid = gridPage.FindComponent<TelerikGrid<Person>>();

            var firstTr = grid.Find(".k-grid-table tr:first-child");

            Assert.Contains("<span class=\"custom-id-0\">0</span>", firstTr.InnerHtml);
        }
    }
}
