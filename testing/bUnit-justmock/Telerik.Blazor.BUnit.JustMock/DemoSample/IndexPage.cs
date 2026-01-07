using Bunit;
using BUnit_Sample.Pages;
using Telerik.Blazor.BUnit.JustMock.Common;
using Xunit;

namespace Telerik.Blazor.BUnit.JustMock
{
    public class IndexPage : TelerikTestContext
    {    
        [Fact]
        public void Greeting_message_displayed()
        {
            var indexPage = Render<Index>();

            var button = indexPage.Find(".k-button");

            button.Click();

            Assert.Contains("Glad to see you here!", indexPage.Markup);
        }
    }
}
