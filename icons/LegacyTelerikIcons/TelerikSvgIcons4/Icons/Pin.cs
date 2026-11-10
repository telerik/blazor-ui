using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Pin : SvgIconBase
    {
        public Pin()
        {
            Name = "pin";
            Content = "<path d=\"M320 256V96c0-17.6-14.4-32-32-32h-96c-17.6 0-32 14.4-32 32v160H96v32h128v160h32V288h128v-32zm-128 0V96h64v160z\" />";
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
