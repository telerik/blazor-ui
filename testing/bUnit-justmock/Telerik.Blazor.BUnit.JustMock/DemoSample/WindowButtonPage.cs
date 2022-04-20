using Bunit;
using BUnit_Sample.Pages;
using Telerik.Blazor.BUnit.JustMock.Common;
using Xunit;

namespace Telerik.Blazor.BUnit.JustMock
{
    public class WindowButtonPage : TelerikTestContext
    {    
        [Fact]
        public void Button_in_window_is_rendered()
        {
            _ = RenderComponent<Window_Button>();

            var button = this.RootComponent.Find("button[id=\"window-test-button\"]");
            
            Assert.Contains("Add Content", button.InnerHtml);
        }

        [Fact]
        public void Button_in_window_click_action()
        {
            _ = RenderComponent<Window_Button>();

            var button = this.RootComponent.Find("button[id=\"window-test-button\"]");

            button.Click();

            Assert.Contains("Custom Content", this.RootComponent.Markup);
        }
    }
}

