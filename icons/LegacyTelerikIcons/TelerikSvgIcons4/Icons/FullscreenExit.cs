using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class FullscreenExit : SvgIconBase
    {
        public FullscreenExit()
        {
            Name = "fullscreen-exit";
            Content = "<path d=\"M160 32H96v96H0v64h160zM96 480h64V320H0v64h96zm416-288v-64h-96V32h-64v160zm-96 192h96v-64H352v160h64z\" />";
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
