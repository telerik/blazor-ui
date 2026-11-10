using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class BringToBack : SvgIconBase
    {
        public BringToBack()
        {
            Name = "bring-to-back";
            Content = "<path d=\"M128 192h64V64H64v128zM96 96h64v64H96zm192 192h96V128H224v96h-96v160h160zm128 32h-96v128h128V320zm0 96h-64v-64h64z\" />";
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
