using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Crop : SvgIconBase
    {
        public Crop()
        {
            Name = "crop";
            Content = "<path d=\"M0 96h64v64H0zm448 256v64h64v-64zm-32-224c0-17.6-14.4-32-32-32H192v64h160v320h64zM96 384c0 17.6 14.4 32 32 32h192v-64H160V32H96z\" />";
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
