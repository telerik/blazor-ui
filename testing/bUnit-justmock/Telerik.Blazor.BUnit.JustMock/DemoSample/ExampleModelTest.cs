using System;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using Bunit;
using BUnit_Sample.Model;
using BUnit_Sample.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Telerik.Blazor.BUnit.JustMock.Common;
using Telerik.Blazor.Components;
using Telerik.Blazor.Services;
using Xunit;

namespace Telerik.Blazor.BUnit.JustMock
{
    public class ExampleModelTest //: TelerikTestContext
    {
        //one way to bootstrap the test is to inherit the bUnit test context
        //and use the extension method in the test constructor
        //public ExampleModelTest()
        //{
        //    // Bootstrap the test
        //    this.AddTelerikBlazor();
        //}
      
        [Fact]
        public void Name_Initial_Value()
        {
            //bootstrap the test
            using var ctx = new TelerikTestContext();
            ctx.AddTelerikBlazor();
            //use that context to render components
            var formPage = ctx.RenderComponent<ExampleForm>();

            var form = formPage.FindComponent<TelerikForm>();
            
            var formItem = form.FindComponent<FormItem>();
            var textboxComponent = formItem.FindComponent<TelerikTextBox>();

            var tbText = textboxComponent.Instance.Value;

            Assert.Equal("Jane", tbText);

            //you can take the Value of the component in-memory instance instead of trying to 
            //go through the DOM or RenderTree markup - there won't be a value attribute there because
            //JS Interop does not really exist in the unit testing setup - it cannot run JS - 
            //it is mocked but that only prevents null reference exceptions.
            //for unit testing you can test the unit of the component - its Parameter, not its DOM attributes
            //some components may need to do things with JS for performance or other reasons (e.g., there is no Blazor API)
            //and such things cannot be tested through the render tree that this type of unit testing can do

            //for example the commended approach below will never be true

            //var name = textboxComponent.Find("#Name");

            //IHtmlInputElement input = ((AngleSharpWrappers.ElementWrapper)name).WrappedElement as IHtmlInputElement;

            //// here the Attributes do not contain the "value" attribute for a TelerikTextbox
            //// and so the .Value field will not have data, and the test will always fail
            //Assert.Equal("Jane", input.Value);
        }
    }
}
