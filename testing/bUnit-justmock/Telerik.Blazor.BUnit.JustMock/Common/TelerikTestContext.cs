using System;
using Bunit;
using Bunit.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Telerik.JustMock;
using Telerik.Blazor.Components;
using Telerik.Blazor.Services;
using Microsoft.JSInterop;

namespace Telerik.Blazor.BUnit.JustMock.Common
{
    public class TelerikTestContext : TestContext
    {
        private IRenderedComponent<TelerikRootComponent>? rootComponent;

        public IRenderedComponent<TelerikRootComponent> RootComponent
            => rootComponent ?? throw new InvalidOperationException("The RootComponent is not available before a component has been rendered with the TestContext.");

        public TelerikTestContext()
        {
            // mock the JS Interop service, you cannot use the one coming from the context
            var jsRuntimeMock = Mock.Create<IJSRuntime>();

            // you can also register a real one for actual localization to test that too
            var localizerMock = Mock.Create<ITelerikStringLocalizer>();

            // make sure JS Interop is available first
            Services.AddSingleton(jsRuntimeMock);
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
