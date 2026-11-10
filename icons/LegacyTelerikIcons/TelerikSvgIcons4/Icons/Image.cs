using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Image : SvgIconBase
    {
        public Image()
        {
            Name = "image";
            Content = "<path d=\"M304 160c26.5 0 48 21.5 48 48s-21.5 48-48 48-48-21.5-48-48 21.5-48 48-48m144-96H64c-17.6 0-32 14.4-32 32v320c0 17.6 14.4 32 32 32h384c17.6 0 32-14.4 32-32V96c0-17.6-14.4-32-32-32m-.1 272-64-64-80 80L176 224 64 336V96.1l.1-.1h383.8l.1.1z\" />";
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
