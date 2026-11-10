using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class OutlineOffset : SvgIconBase
    {
        public OutlineOffset()
        {
            Name = "outline-offset";
            Content = "<path d=\"M448 32H32v448h448V32zm0 416H64V64h384zM160 320v32h192V160H160zm32-128h128v128H192z\" />";
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
