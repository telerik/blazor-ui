using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class InfoCircle : SvgIconBase
    {
        public InfoCircle()
        {
            Name = "info-circle";
            Content = "<path d=\"M288 352h32v32H192v-32h32v-96h-32v-32h96zm0-224h-64v64h64zm192 128c0 123.7-100.3 224-224 224S32 379.7 32 256 132.3 32 256 32s224 100.3 224 224m-32 0c0-106-86-192-192-192S64 150 64 256s86 192 192 192 192-86 192-192\" />";
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
