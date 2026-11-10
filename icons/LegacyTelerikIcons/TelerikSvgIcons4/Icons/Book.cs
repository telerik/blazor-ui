using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Book : SvgIconBase
    {
        public Book()
        {
            Name = "book";
            Content = "<path d=\"M448 480V96h-32v352H128c-17.6 0-32-14.4-32-32s14.4-32 32-32h256V32H128c-35.2 0-64 28.8-64 64v320c0 23.6 12.9 44.2 32 55.3 9.4 5.5 20.4 8.7 32 8.7zM128 64h224v288H128zm192 64H160V96h160zm0 128H160v-32h160zm-32-64H160v-32h128z\" />";
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
