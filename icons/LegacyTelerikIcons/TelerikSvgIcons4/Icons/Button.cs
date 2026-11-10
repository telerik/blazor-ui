using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Button : SvgIconBase
    {
        public Button()
        {
            Name = "button";
            Content = "<path d=\"m130.1 130.1 36.1 93.9H64c-17.6 0-32-14.4-32-32V64c0-17.6 14.4-32 32-32h384c17.6 0 32 14.4 32 32v128c0 17.6-14.4 32-32 32h-73.8zM480 299 185.8 185.8 299 480l22.6-113.1L434.7 480l45.3-45.3-113.1-113.1z\" />";
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
