using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Calculator : SvgIconBase
    {
        public Calculator()
        {
            Name = "calculator";
            Content = "<path d=\"M64 64v384h384V64zm96 352H96v-64h64zm0-96H96v-64h64zm96 96h-64v-64h64zm0-96h-64v-64h64zm160 96h-96V256h96zm0-224H96V96h320z\" />";
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
