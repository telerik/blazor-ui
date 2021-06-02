using System;
using Microsoft.AspNetCore.Components;

namespace AddRemoveTiles.Components.Tiles
{
    public abstract class ChartTileContentBase : ComponentBase, IDisposable
    {
        [CascadingParameter]
        public ResizeContext ResizeContext { get; set; }

        protected override void OnInitialized()
        {
            if (ResizeContext != null)
            {
                ResizeContext.OnResizeInvoked += Resize;
            }

            base.OnInitialized();
        }

        public void Dispose()
        {
            if (ResizeContext != null)
            {
                ResizeContext.OnResizeInvoked -= Resize;
            }
        }

        public abstract void Resize(object sender, EventArgs e);
    }
}
