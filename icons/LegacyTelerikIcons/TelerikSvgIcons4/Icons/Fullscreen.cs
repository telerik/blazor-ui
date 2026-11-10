using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Fullscreen : SvgIconBase
    {
        public Fullscreen()
        {
            Name = "fullscreen";
            Content = "<path d=\"M0 32h160v64H64v96H0zm64 288H0v160h160v-64H64zM352 32v64h96v96h64V32zm96 384h-96v64h160V320h-64z\" />";
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
