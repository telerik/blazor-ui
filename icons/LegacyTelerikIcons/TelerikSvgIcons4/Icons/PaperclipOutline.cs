using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Paperclip instead.", false)]
    public class PaperclipOutline : SvgIconBase
    {
        public PaperclipOutline()
        {
            Name = "paperclip-outline";
            Content = "<path d=\"M208 344V128c0-8.837 7.163-16 16-16s16 7.163 16 16v216c0 13.255 10.745 24 24 24s24-10.745 24-24V128c0-35.346-28.654-64-64-64s-64 28.654-64 64v216c0 57.438 46.562 104 104 104s104-46.562 104-104V128c0-8.837 7.163-16 16-16s16 7.163 16 16v216c0 75.111-60.889 136-136 136s-136-60.889-136-136V128c0-53.02 42.981-96 96-96s96 42.98 96 96v216c0 30.928-25.072 56-56 56s-56-25.072-56-56\" />";
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
