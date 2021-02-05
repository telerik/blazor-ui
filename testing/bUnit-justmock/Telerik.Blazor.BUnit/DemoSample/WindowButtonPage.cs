using Bunit;
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

