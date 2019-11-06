using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResponsiveChart.Data
{
    public static class WindowResizeDispatcher
    {
        public static event Func<Task> WindowResize;
        public static int? WindowWidth { get; private set; }
        public static int? WindowHeight { get; private set; }

        [JSInvokable]
        public static async Task RaiseWindowResizeEvent(int width, int height)
        {
            WindowWidth = width;
            WindowHeight = height;
            await WindowResize?.Invoke();
        }
    }
}
