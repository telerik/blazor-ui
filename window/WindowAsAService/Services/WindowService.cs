using Telerik.Blazor.Components;
using WindowAsAService.Components;
using WindowAsAService.Models;

namespace WindowAsAService.Services
{
    public class WindowService
    {
        public WindowBuilder BuilderRef { get; set; }

        public List<WindowInstance> Instances { get; set; } = new();

        public WindowInstance Add(string content, string title)
        {
            var windowInstance = new WindowInstance { Content = content, Title = title };
            Instances.Add(windowInstance);
            BuilderRef.Refresh();

            return windowInstance;
        }
        public WindowInstance Add(string content, string title, string width, string height)
        {
            var windowInstance = new WindowInstance { Content = content, Title = title, Width = width, Height = height };
            Instances.Add(windowInstance);
            BuilderRef.Refresh();

            return windowInstance;
        }

        public void Remove(TelerikWindow windowRef)
        {
            Instances.RemoveAll(x => x.WindowRef == windowRef);
            BuilderRef.Refresh();
        }
    }
}
