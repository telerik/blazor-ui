using Bunit;
using BUnit_Sample.Model;
using BUnit_Sample.Pages;
using Telerik.Blazor.BUnit.JustMock.Common;
using Telerik.Blazor.Components;
using Xunit;

namespace Telerik.Blazor.BUnit.JustMock
{
    public class GridPage : TelerikTestContext
    {
        //one way to bootstrap the test is to inherit the bUnit test context
        //and use the extension method in the test constructor
        public GridPage()
        {
            // Bootstrap the test
            this.AddTelerikBlazor();
        }
    
        [Fact]
        public void DetailTemplate_is_rendered()
        {
            var gridPage = RenderComponent<Grid>();

            var grid = gridPage.FindComponent<TelerikGrid<Person>>();

            var firstHierarchyCell = grid.Find(".k-grid-table tr:first-child .k-hierarchy-cell");

            firstHierarchyCell.Click();

            Assert.Contains("<span>DetailTemplate for Employee 0</span>", grid.Markup);
        }

        [Fact]
        public void ItemTemplate_is_rendered()
        {
            var gridPage = RenderComponent<Grid>();

            var grid = gridPage.FindComponent<TelerikGrid<Person>>();

            var firstTr = grid.Find(".k-grid-table tr:first-child");

            Assert.Contains("<span class=\"custom-id-0\">0</span>", firstTr.InnerHtml);
        }
    }
}
