using Bunit;
using BUnit_Sample.Pages;
using Telerik.Blazor.BUnit.JustMock.Common;
using Xunit;

namespace Telerik.Blazor.BUnit.JustMock
{
    public class DialogPage : TelerikTestContextWithActualRoot
    {    
        [Fact]
        public void Dialog_alert_triggered_on_button_click()
        {
            _ = Render<Dialog>();

            var button = this.RootComponent.Find("button[id=\"dialog-show-button\"]");

            button.Click();

            Assert.Contains("Something went wrong!", this.RootComponent.Markup);
        }
    }
}

