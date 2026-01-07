using Bunit;
using BUnit_Sample.Pages;
using Telerik.Blazor.BUnit.JustMock.Common;
using Telerik.Blazor.Components;
using Xunit;

namespace Telerik.Blazor.BUnit.JustMock
{
    public class TextBoxPage : TelerikTestContext
    {
        [Fact]
        public void OnInput_updates_value()
        {
            var expected = "this is the new textbox value";
            var textBoxPage = Render<TextBox>();

            var textBox = textBoxPage.FindComponent<TelerikTextBox>();

            // Override the default DebounceDelay so oninput event is executed immediately, 
            // as we do not want to have a deliberate delay in our unit tests.
            textBox.Render(parameters => parameters.Add(p => p.DebounceDelay, 0));

            var textBoxElement = textBoxPage.Find("#tested-textbox");

            textBoxElement.Input(expected);

            Assert.Equal(expected, textBox.Instance.Value);
        }
    }
}
