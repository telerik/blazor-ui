using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class PaneFreeze : SvgIconBase
    {
        public PaneFreeze()
        {
            Name = "pane-freeze";
            Content = "<path d=\"M32 32v416h416V32zm256 32 96 96h-64l-96-96zm-128 0 96 96h-64L96 64zM64 96l96 96v64l-96-96zm0 128 96 96v64l-96-96zm0 192v-64l64 64zm224 0h-96v-96h96zm0-128h-96v-96h96zm128 128h-96v-96h96zm0-128h-96v-96h96zM352 64h64v64z\" />";
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
