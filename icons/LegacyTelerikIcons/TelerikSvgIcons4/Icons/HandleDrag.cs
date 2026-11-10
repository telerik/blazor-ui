using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class HandleDrag : SvgIconBase
    {
        public HandleDrag()
        {
            Name = "handle-drag";
            Content = "<path d=\"M160 64h64v384h-64zm96 0v384h64V64z\" />";
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
