using Bunit;
using Moq;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Telerik.Blazor.Components;
using Telerik.Blazor.Services;

namespace Telerik.Blazor.BUnit.Common
{
    public static class TestContextExtensions
    {
        public static void AddTelerikBlazor(this TelerikTestContext context)
        {
            var jsRuntimeMock = new Mock<IJSRuntime>();
            var localizerMock = new Mock<ITelerikStringLocalizer>(); // you can also register a real one for actual localization to test that too

            context.Services.AddSingleton(jsRuntimeMock.Object);
            context.Services.AddSingleton(localizerMock.Object);

            context.Services.AddTelerikBlazor();

            context.RootComponent = context.RenderComponent<TelerikRootComponent>();

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
