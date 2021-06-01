using System;

namespace AddRemoveTiles.Components.Tiles
{
    public class ResizeContext
    {
        public event EventHandler OnResizeInvoked;

        public void NotifyResizeInvoked()
        {
            OnResizeInvoked.Invoke(null, new EventArgs());
        }
    }
}
