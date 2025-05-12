using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorFinancialDashboard.Components;

public class ResponsiveComponent : ComponentBase, IDisposable, IResponsiveComponent
{
    [Inject]
    IJSRuntime? JSRuntime { get; set; }
    
    protected DotNetObjectReference<ResponsiveComponent>? DotNetRef { get; set; }

    protected override void OnInitialized()
    {
        DotNetRef = DotNetObjectReference.Create(this);

        base.OnInitialized();
    }

    public virtual Task OnViewPortResize()
    {
        return Task.CompletedTask;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JSRuntime!.InvokeVoidAsync("viewPortResizeObserver.addComponent", DotNetRef);
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    public void Dispose()
    {
        _ = JSRuntime?.InvokeVoidAsync("viewPortResizeObserver.removeComponent", DotNetRef);

        DotNetRef?.Dispose();
    }
}
