using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Group : SvgIconBase
    {
        public Group()
        {
            Name = "group";
            Content = "<path d=\"M32 256h192v192H32zm0-32h192V32H32zm224 224h192V256H256zm0-416v192h192V32z\" />";
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
