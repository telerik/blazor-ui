using Bunit;
using BUnit_Sample.Pages;
using Telerik.Blazor.BUnit.JustMock.Common;
using Xunit;

namespace Telerik.Blazor.BUnit.JustMock
{
    public class WindowButtonPage
    {
        [Fact]
        public void Button_in_window_is_rendered()
        {
            using var ctx = new TelerikTestContext();

            ctx.AddTelerikBlazor();

            ctx.RenderComponent<Window_Button>();

            var button = ctx.RootComponent.Find("button[id=\"window-test-button\"]");
            
            Assert.Contains("Add Content", button.InnerHtml);
        }

        [Fact]
        public void Button_in_window_click_action()
        {
            using var ctx = new TelerikTestContext();

            ctx.AddTelerikBlazor();

            ctx.RenderComponent<Window_Button>();

            var button = ctx.RootComponent.Find("button[id=\"window-test-button\"]");

            button.Click();

            Assert.Contains("Custom Content", ctx.RootComponent.Markup);
        }
    }
}

