using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Graph : SvgIconBase
    {
        public Graph()
        {
            Name = "graph";
            Content = "<path d=\"M64 448h416v32H32V32h32zm128-192-96 96v64h384V160L288 320zM416 64l14.2 14.2L288 192l-96-64-96 96v64l96-96 96 64 174.5-145.4L480 128V64z\" />";
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
