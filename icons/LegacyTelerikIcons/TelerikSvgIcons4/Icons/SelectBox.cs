using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class SelectBox : SvgIconBase
    {
        public SelectBox()
        {
            Name = "select-box";
            Content = "<path d=\"M384 352H128v-32h256zm0 32H128v32h256zm0-128H128v32h256zm96-192v128c0 17.6-14.4 32-32 32v224c0 17.7-14.3 32-32 32H96c-17.7 0-32-14.3-32-32V224c-17.6 0-32-14.4-32-32V64c0-17.6 14.4-32 32-32h384c17.6 0 32 14.4 32 32M352 96l32 64 32-64zm64 128H96v224h320z\" />";
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
