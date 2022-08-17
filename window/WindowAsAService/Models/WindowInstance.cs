using Telerik.Blazor.Components;

namespace WindowAsAService.Models
{
    public class WindowInstance
    {
        public bool Visible { get; set; } = true;

        public string Title { get; set; }

        public string Content { get; set; }

        public string Width { get; set; }

        public string Height { get; set; }

        /// <summary>
        /// This is the reference of the TelerikWindow component instance.
        /// It can be used after the first render follwoing the creation.
        /// </summary>
        public TelerikWindow WindowRef { get; set; }
    }
}
