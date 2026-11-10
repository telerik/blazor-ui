using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class AlignRight : SvgIconBase
    {
        public AlignRight()
        {
            Name = "align-right";
            Content = "<path d=\"M64 192h384v32H64zm384-96V64H64v32zm-288 64h288v-32H160zM64 320v32h384v-32zm96-32h288v-32H160zm0 96v32h288v-32z\" />";
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
