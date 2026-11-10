using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Radiobutton : SvgIconBase
    {
        public Radiobutton()
        {
            Name = "radiobutton";
            Content = "<path d=\"M256 64C150 64 64 150 64 256s86 192 192 192 192-86 192-192S362 64 256 64m0 352c-88.4 0-160-71.6-160-160S167.6 96 256 96s160 71.6 160 160-71.6 160-160 160\" />";
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
