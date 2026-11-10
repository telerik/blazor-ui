using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Stick : SvgIconBase
    {
        public Stick()
        {
            Name = "stick";
            Content = "<path d=\"M192 96c0-17.7-14.3-32-32-32H96c-17.7 0-32 14.3-32 32v32h128zm128 160c0 35.3-28.7 64-64 64s-64-28.7-64-64v-96H64v96c0 106 86 192 192 192s192-86 192-192v-96H320zm96-192h-64c-17.7 0-32 14.3-32 32v32h128V96c0-17.7-14.3-32-32-32\" />";
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
