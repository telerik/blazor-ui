using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Layout : SvgIconBase
    {
        public Layout()
        {
            Name = "layout";
            Content = "<path d=\"M192 416h256v64H192zm0-32h256v-64H192zM32 480h128V128H32zm160-288h256v-64H192zm0 96h256v-64H192zM32 0v96h416V0z\" />";
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
