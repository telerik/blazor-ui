using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Paperclip : SvgIconBase
    {
        public Paperclip()
        {
            Name = "paperclip";
            Content = "<path d=\"M384 128v256h-32V128c0-52.9-43.1-96-96-96s-96 43.1-96 96v288c0 35.3 28.7 64 64 64s64-28.7 64-64V128c0-17.6-14.4-32-32-32s-32 14.4-32 32v256h-32V128c0-35.3 28.7-64 64-64s64 28.7 64 64v288c0 52.9-43.1 96-96 96s-96-43.1-96-96V128C128 57.4 185.4 0 256 0s128 57.4 128 128\" />";
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
