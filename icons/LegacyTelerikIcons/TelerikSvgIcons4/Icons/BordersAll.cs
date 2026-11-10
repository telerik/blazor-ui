using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class BordersAll : SvgIconBase
    {
        public BordersAll()
        {
            Name = "borders-all";
            Content = "<path d=\"M32 32v416h416V32zm32 32h160v160H64zm0 352V256h160v160zm352 0H256V256h160zm0-192H256V64h160z\" />";
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
