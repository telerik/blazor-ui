using Bunit;
using BUnit_Sample.Pages;
using Microsoft.Extensions.DependencyInjection;
using Telerik.Blazor.BUnit.Moq.Common;
using Xunit;

namespace Telerik.Blazor.BUnit.Moq
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
