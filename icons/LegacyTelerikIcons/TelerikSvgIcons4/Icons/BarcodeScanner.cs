using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class BarcodeScanner : SvgIconBase
    {
        public BarcodeScanner()
        {
            Name = "barcode-scanner";
            Content = "<path d=\"M32 96H0V0h96v32H32zm0 288H0v96h96v-32H32zM416 0v32h64v64h32V0zm64 448h-64v32h96v-96h-32zm-192-32h32V288h-32zm32-352h-32v128h32zm-64 0h-32v128h32zM128 416h64V288h-64zm-64 0h32V288H64zM192 64h-64v128h64zm32 352h32V288h-32zM64 64v128h32V64zm384 0h-32v128h32zm0 352V288h-32v128zm-96 0h32V288h-32zm32-352h-32v128h32zm96 160H32v32h448z\" />";
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
