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
    /// TestContext using an actual <see cref="TelerikRootComponent"/> that wraps the rendered content from the CUT. 
    /// Useful when the test depends on a certain logic contained within the RootComponent, such as when testing Dialogs.
    /// </summary>
    public class TelerikTestContextWithActualRoot : TestContext
    {
        private IRenderedComponent<TelerikRootComponent>? rootComponent;
        private RenderFragment rootFragment;

        public IRenderedComponent<TelerikRootComponent> RootComponent
            => rootComponent ?? throw new InvalidOperationException("The RootComponent is not available before a component has been rendered with the TestContext.");

        public TelerikTestContextWithActualRoot()
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
            EnsureRootComponent(renderFragment);
            return base.Render(rootFragment);
        }

        public override IRenderedComponent<TComponent> Render<TComponent>(RenderFragment renderFragment)
        {
            EnsureRootComponent(renderFragment);
            return base.Render<TComponent>(rootFragment);
        }

        public override IRenderedComponent<TComponent> RenderComponent<TComponent>(params ComponentParameter[] parameters)
        {
            return base.RenderComponent<TComponent>(parameters);
        }

        public override IRenderedComponent<TComponent> RenderComponent<TComponent>(Action<ComponentParameterCollectionBuilder<TComponent>> parameterBuilder)
        {
            return base.RenderComponent(parameterBuilder);
        }

        public void EnsureRootComponent(RenderFragment fragment)
        {
            if (rootComponent is not null) return;

            // Initialize a parameter collection with ChildContent prop, which contains the currently tested
            // fragment. This way anything we test will correctly be a descendant of the TelerikRootComponent.
            var cpc = new ComponentParameterCollection();
            cpc.Add(ComponentParameter.CreateParameter("ChildContent", fragment));

            // Save a copy of the root fragment
            rootFragment = cpc.ToRenderFragment<TelerikRootComponent>();

            // Render the root component and assign it to a field so it can be used when testing
            rootComponent = base.Render<TelerikRootComponent>(rootFragment);
        }
    }
}
