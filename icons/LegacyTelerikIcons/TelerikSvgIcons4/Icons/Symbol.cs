using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Symbol : SvgIconBase
    {
        public Symbol()
        {
            Name = "symbol";
            Content = "<path d=\"m448 416 32-32v96H320V375.8c11.4-5.1 22.2-11.5 32-19 38.9-29.7 64-76.9 64-130.1C416 136.8 344.4 64 256 64S96 136.8 96 226.7c0 53.2 25.1 100.5 64 130.1 9.8 7.5 20.6 13.9 32 19V480H32v-96l32 32h96v-18.5C84.3 366.7 32 300.6 32 224 32 118 132.3 32 256 32s224 86 224 192c0 76.6-52.3 142.7-128 173.5V416z\" />";
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
