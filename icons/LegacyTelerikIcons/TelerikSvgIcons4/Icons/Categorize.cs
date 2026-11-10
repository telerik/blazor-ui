using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Categorize : SvgIconBase
    {
        public Categorize()
        {
            Name = "categorize";
            Content = "<path d=\"M32 32v192l160-96zm0 448V288l160 96zM192 64h288v32H192zm0 96h288v32H192zm0 160h288v32H192zm0 96h288v32H192z\" />";
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
