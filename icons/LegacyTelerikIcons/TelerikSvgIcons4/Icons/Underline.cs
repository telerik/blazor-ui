using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Underline : SvgIconBase
    {
        public Underline()
        {
            Name = "underline";
            Content = "<path d=\"M128 416h256v32H128zM320 64v224c0 11.6-3.5 16-10.3 20.3-11.8 7.4-31.3 11.7-53.7 11.7s-41.9-4.3-53.7-11.7c-6.8-4.3-10.3-8.7-10.3-20.3V64h-64v224c0 70.4 64.3 96 128 96s128-25.6 128-96V64z\" />";
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
