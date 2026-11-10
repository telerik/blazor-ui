using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Dropdown : SvgIconBase
    {
        public Dropdown()
        {
            Name = "dropdown";
            Content = "<path d=\"M256 288H96v-32h160zm0 96H96v32h160zm0-64H96v32h160zM96 144h224v-32H96zm320-32h-64l32 32zm64-80v192H320v256H32V32zM288 224H64v224h224zM448 64H64v128h384z\" />";
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
