using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Ungroup : SvgIconBase
    {
        public Ungroup()
        {
            Name = "ungroup";
            Content = "<path d=\"M32 256h192v192H32zm32-64h128V64H64zm224 224h128V288H288zM256 32v192h192V32z\" />";
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
