using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use InfoCircle instead.", false)]
    public class InfoSolid : SvgIconBase
    {
        public InfoSolid()
        {
            Name = "info-solid";
            Content = "<path d=\"M256 32C132.3 32 32 132.3 32 256s100.3 224 224 224 224-100.3 224-224S379.7 32 256 32m-32 96h64v64h-64zm96 256H192v-32h32v-96h-32v-32h96v128h32z\" />";
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
