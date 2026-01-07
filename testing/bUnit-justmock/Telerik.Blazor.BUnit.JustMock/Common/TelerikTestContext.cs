using Bunit;
using Bunit.Rendering;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using Telerik.Blazor.Components;
using Telerik.Blazor.Services;
using Telerik.JustMock;

namespace Telerik.Blazor.BUnit.JustMock.Common
{
    /// <summary>
    /// TestContext using a CascadingValue of type <see cref="TelerikRootComponent"/>, rather than the actual implementation.
    /// </summary>
    public class TelerikTestContext : BunitContext
    {
        private IRenderedComponent<TelerikRootComponent>? rootComponent;
        public IRenderedComponent<TelerikRootComponent> RootComponent
            => rootComponent ?? throw new InvalidOperationException("The RootComponent is not available before a component has been rendered with the TestContext.");

        public TelerikTestContext()
        {
            JSInterop.SetupVoid(x => x.Identifier.StartsWith("TelerikBlazor", StringComparison.InvariantCultureIgnoreCase));
            JSInterop.Setup<string>(x => x.Identifier.StartsWith("TelerikBlazor", StringComparison.InvariantCultureIgnoreCase)).SetResult(string.Empty);
            JSInterop.Setup<bool>(x => x.Identifier.StartsWith("TelerikBlazor", StringComparison.InvariantCultureIgnoreCase)).SetResult(default);
            JSInterop.Setup<double>(x => x.Identifier.StartsWith("TelerikBlazor", StringComparison.InvariantCultureIgnoreCase)).SetResult(default);

            // you can also register a real one for actual localization to test that too
            var localizerMock = Mock.Create<ITelerikStringLocalizer>();

            // add the Telerik Blazor services like in a regular app
            Services.AddTelerikBlazor();
            Services.AddSingleton(localizerMock);
        }

        public override IRenderedComponent<ContainerFragment> Render(RenderFragment renderFragment)
        {
            EnsureRootComponent();
            return base.Render(renderFragment);
        }

        public override IRenderedComponent<TComponent> Render<TComponent>(RenderFragment renderFragment)
        {
            EnsureRootComponent();
            return base.Render<TComponent>(renderFragment);
        }

        public override IRenderedComponent<TComponent> Render<TComponent>(Action<ComponentParameterCollectionBuilder<TComponent>> parameterBuilder)
        {
            EnsureRootComponent();
            return base.Render(parameterBuilder);
        }

        private void EnsureRootComponent()
        {
            if (rootComponent is not null) return;

            // add a Telerik Root Component to hold all Telerik components and other content
            rootComponent = (IRenderedComponent<TelerikRootComponent>)Renderer.Render<TelerikRootComponent>();

            // provide the Telerik Root Component to the child components that need it (the Telerik components)
            RenderTree.TryAdd<CascadingValue<TelerikRootComponent>>(p =>
            {
                p.Add(parameters => parameters.IsFixed, true);
                p.Add(parameters => parameters.Value, RootComponent.Instance);
            });
        }
    }
}
