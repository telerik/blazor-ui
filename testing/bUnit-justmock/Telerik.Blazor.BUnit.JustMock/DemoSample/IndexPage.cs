using Bunit;
using BUnit_Sample.Pages;
using Telerik.Blazor.BUnit.JustMock.Common;
using Xunit;

namespace Telerik.Blazor.BUnit.JustMock
{
    public class IndexPage : TelerikTestContext
    {
        //one way to bootstrap the test is to inherit the bUnit test context
        //and use the extension method in the test constructor
        public IndexPage()
        {
            // Bootstrap the test
            this.AddTelerikBlazor();
        }
    
        [Fact]
        public void Greeting_message_displayed()
        {
            var indexPage = RenderComponent<Index>();

            var button = indexPage.Find(".k-button");

            button.Click();

            Assert.Contains("Glad to see you here!", indexPage.Markup);
        }
    }
}
