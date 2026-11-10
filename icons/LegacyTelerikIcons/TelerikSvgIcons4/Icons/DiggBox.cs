using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Digg instead.", false)]
    public class DiggBox : SvgIconBase
    {
        public DiggBox()
        {
            Name = "digg-box";
            Content = "<path d=\"M448 32H64c-17.7 0-32 14.3-32 32v384c0 17.7 14.3 32 32 32h384c17.7 0 32-14.3 32-32V64c0-17.7-14.3-32-32-32M160 203.5V352H64V192h64v-64h32zM212 352h-32V192h32zm0-192h-32v-32h32zm119 153.7V416h-96v-32h64v-32h-64V192h96zm117 0V416h-96v-32h64v-32h-64V192h96zM96 224h32v96H96zm171 0h32v96h-32zm117 0h32v96h-32z\" />";
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
