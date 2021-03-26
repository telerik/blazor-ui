using Bunit;
using BUnit_Sample.Pages;
using Telerik.Blazor.BUnit.JustMock.Common;
using Xunit;

namespace Telerik.Blazor.BUnit.JustMock
{
    public class WindowButtonPage : TelerikTestContext
    {
        //one way to bootstrap the test is to inherit the bUnit test context
        //and use the extension method in the test constructor
        public WindowButtonPage()
        {
            // Bootstrap the test
            this.AddTelerikBlazor();
        }
    
        [Fact]
        public void Button_in_window_is_rendered()
        {
            RenderComponent<Window_Button>();

            var button = this.RootComponent.Find("button[id=\"window-test-button\"]");
            
            Assert.Contains("Add Content", button.InnerHtml);
        }

        [Fact]
        public void Button_in_window_click_action()
        {
            RenderComponent<Window_Button>();

            var button = this.RootComponent.Find("button[id=\"window-test-button\"]");

            button.Click();

            Assert.Contains("Custom Content", this.RootComponent.Markup);
        }
    }
}

