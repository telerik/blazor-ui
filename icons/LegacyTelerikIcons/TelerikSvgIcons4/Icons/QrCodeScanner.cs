using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class QrCodeScanner : SvgIconBase
    {
        public QrCodeScanner()
        {
            Name = "qr-code-scanner";
            Content = "<path d=\"M512 0v96h-32V32h-64V0zm-32 448h-64v32h96v-96h-32zM64 64h128v128H64zm32 96h64V96H96zM32 32h64V0H0v96h32zm0 224h448v-32H32zm0 128H0v96h96v-32H32zM288 96h-32v32h32zm-64-32v32h32V64zm224 128H320V64h128zm-32-96h-64v64h64zm-128 96v-32h-32v32zm-32-64h-32v32h32zM64 288h128v128H64zm32 96h64v-64H96zm192-64h-32v32h32zm-64-32v32h32v-32zm32 128h32v-32h-32zm-32-64v32h32v-32zm96-64h-32v32h32zm-32 64v32h32v-32zm64 0v-32h-32v32zm-32 64h32v-32h-32zm64-128h-32v32h32zm-32 64v32h32v-32zm64 0v-32h-32v32zm0 64v-32h-32v32zm32-128h-32v32h32zm0 96v-32h-32v32z\" />";
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
