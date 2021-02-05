using Bunit;
using BUnit_Sample.Pages;
using Telerik.Blazor.BUnit.JustMock.Common;
using Xunit;

namespace Telerik.Blazor.BUnit.JustMock
{
    public class IndexPage
    {
        [Fact]
        public void Greeting_message_displayed()
        {
            using var ctx = new TelerikTestContext();

            ctx.AddTelerikBlazor();

            var indexPage = ctx.RenderComponent<Index>();

            var button = indexPage.Find(".k-button");

            button.Click();

            Assert.Contains("Glad to see you here!", indexPage.Markup);
        }
    }
}
