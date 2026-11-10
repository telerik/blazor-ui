using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Grid : SvgIconBase
    {
        public Grid()
        {
            Name = "grid";
            Content = "<path d=\"M32 32h128v128H32zm160 448h128V352H192zm-160 0h128V352H32zm0-160h128V192H32zm160 0h128V192H192zM352 32v128h128V32zm0 288h128V192H352zM192 160h128V32H192zm160 320h128V352H352z\" />";
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
