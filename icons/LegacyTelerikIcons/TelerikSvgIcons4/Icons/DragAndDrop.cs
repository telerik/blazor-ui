using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class DragAndDrop : SvgIconBase
    {
        public DragAndDrop()
        {
            Name = "drag-and-drop";
            Content = "<path d=\"m32 128 192 112L32 352zm224 96v32h224v-32z\" />";
            ViewBox = "0 0 512 512";
            Variants = new System.Collections.Generic.Dictionary<string, string>
            {
                { "solid", "" },
                { "outline", "" },
                { "duotone", "" }
            };
        }
    }
}
