using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Delicious : SvgIconBase
    {
        public Delicious()
        {
            Name = "delicious";
            Content = "<path d=\"M256 32h224v224H256zM32 256h224v224H32z\" />";
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
