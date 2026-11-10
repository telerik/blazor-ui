using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class InvertColors : SvgIconBase
    {
        public InvertColors()
        {
            Name = "invert-colors";
            Content = "<path d=\"m320 32-64 48 64 48V96h64v64h-32l48 64 48-64h-32V64h-96zM32 64v192h192V64zm192 192v192h192V256zM64 96h128v128H64z\" />";
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
