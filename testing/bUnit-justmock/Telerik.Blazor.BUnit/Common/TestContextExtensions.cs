using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Telerik.Blazor.Components;
using Telerik.Blazor.Services;
using Telerik.JustMock;

namespace Telerik.Blazor.BUnit.Common
{
    public static class TestContextExtensions
    {
        public static void AddTelerikBlazor(this TelerikTestContext context)
        {
            // mock the JS Interop service, you cannot use the one coming from the context
            var jsRuntimeMock = Mock.Create<IJSRuntime>();
            

            // you can also register a real one for actual localization to test that too
            var localizerMock = Mock.Create<ITelerikStringLocalizer>();

            context.Services.AddSingleton(jsRuntimeMock);
            context.Services.AddSingleton(localizerMock);

            // add the Telerik Blazor services like in a regular app
            context.Services.AddTelerikBlazor();

            // add a Telerik Root Component to hold all Telerik components and other content
            context.RootComponent = context.RenderComponent<TelerikRootComponent>();

            // provide the Telerik Root Component to the child components that need it (the Telerik components)
            context.RenderTree.TryAdd<CascadingValue<TelerikRootComponent>>(p =>
            {
                p.Add(parameters => parameters.IsFixed, true);
                p.Add(parameters => parameters.Value, context.RootComponent.Instance);
            });
        }
    }

    /// <summary>
    /// Creating a context to store the RootComponent. Alternatively in the tests you might have:
    /// var myRootComponent = context.RenderComponent<TelerikRootComponent>(p => p.AddChildContent<Index>());
    /// This will be required only when you'd like to access content injected in the RootComponent (ex. popups and window)
    /// </summary>
    public class TelerikTestContext : TestContext
    {
        public IRenderedComponent<TelerikRootComponent> RootComponent { get; set; }
    }
}
