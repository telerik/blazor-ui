using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class PlusCircle : SvgIconBase
    {
        public PlusCircle()
        {
            Name = "plus-circle";
            Content = "<path d=\"M256 32C132.3 32 32 132.3 32 256s100.3 224 224 224 224-100.3 224-224S379.7 32 256 32m32 256v96h-64v-96h-96v-64h96v-96h64v96h96v64z\" />";
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
