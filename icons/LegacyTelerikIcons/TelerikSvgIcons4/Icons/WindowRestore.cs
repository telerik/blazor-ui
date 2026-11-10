using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class WindowRestore : SvgIconBase
    {
        public WindowRestore()
        {
            Name = "window-restore";
            Content = "<path d=\"M448 32v288h-32V128H160V32zM64 192h288v288H64zm32 256h224V288H96z\" />";
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
