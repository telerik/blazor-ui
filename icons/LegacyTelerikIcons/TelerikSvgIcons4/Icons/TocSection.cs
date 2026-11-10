using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class TocSection : SvgIconBase
    {
        public TocSection()
        {
            Name = "toc-section";
            Content = "<path d=\"M96 32c-17.7 0-32 14.3-32 32v384c0 17.7 14.3 32 32 32h320c17.7 0 32-14.3 32-32V64c0-17.7-14.3-32-32-32zm320 416H96V64h320zm-32-288H224v-32h160zm-64 64h-96v-32h96zm0 64h-96v-32h96zm64 64H224v-32h160z\" />";
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
