using Bunit;
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
    public class TelerikTestContext : TestContext
    {
        private IRenderedComponent<TelerikRootComponent>? rootComponent;
        public IRenderedComponent<TelerikRootComponent> RootComponent
            => rootComponent ?? throw new InvalidOperationException("The RootComponent is not available before a component has been rendered with the TestContext.");

        public TelerikTestContext()
        {
            this.JSInterop.Mode = JSRuntimeMode.Loose;

            // you can also register a real one for actual localization to test that too
            var localizerMock = Mock.Create<ITelerikStringLocalizer>();

            // make sure JS Interop is available first
            Services.AddSingleton(this.JSInterop.JSRuntime);

            // add the Telerik Blazor services like in a regular app
            Services.AddTelerikBlazor();
            Services.AddSingleton(localizerMock);
        }

        public override IRenderedFragment Render(RenderFragment renderFragment)
        {
            EnsureRootComponent();
            return base.Render(renderFragment);
        }

        public override IRenderedComponent<TComponent> Render<TComponent>(RenderFragment renderFragment)
        {
            EnsureRootComponent();
            return base.Render<TComponent>(renderFragment);
        }

        public override IRenderedComponent<TComponent> RenderComponent<TComponent>(params ComponentParameter[] parameters)
        {
            EnsureRootComponent();
            return base.RenderComponent<TComponent>(parameters);
        }

        public override IRenderedComponent<TComponent> RenderComponent<TComponent>(Action<ComponentParameterCollectionBuilder<TComponent>> parameterBuilder)
        {
            EnsureRootComponent();
            return base.RenderComponent(parameterBuilder);
        }

        private void EnsureRootComponent()
        {
            if (rootComponent is not null) return;

            // add a Telerik Root Component to hold all Telerik components and other content
            rootComponent = (IRenderedComponent<TelerikRootComponent>)Renderer.RenderComponent<TelerikRootComponent>(new ComponentParameterCollection());

            // provide the Telerik Root Component to the child components that need it (the Telerik components)
            RenderTree.TryAdd<CascadingValue<TelerikRootComponent>>(p =>
            {
                p.Add(parameters => parameters.IsFixed, true);
                p.Add(parameters => parameters.Value, RootComponent.Instance);
            });
        }
    }
}
