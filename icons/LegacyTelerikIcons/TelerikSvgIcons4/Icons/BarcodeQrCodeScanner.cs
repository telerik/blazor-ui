using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use BarcodeScanner instead.", false)]
    public class BarcodeQrCodeScanner : SvgIconBase
    {
        public BarcodeQrCodeScanner()
        {
            Name = "barcode-qr-code-scanner";
            Content = "<path d=\"M256 288h32v128h-32zm64 128h64V288h-64zm128 0V288h-32v128zM32 32h64V0H0v96h32zm0 352H0v96h96v-32H32zM416 0v32h64v64h32V0zm64 448h-64v32h96v-96h-32zm0-224H32v32h448zM288 64h-32v128h32zm96 0h-64v128h64zm64 0h-32v128h32zM64 64h96v96H64zm32 64h32V96H96zm128 32h-32v32h32zm0-96h-32v64h32zM64 320h96v96H64zm32 64h32v-32H96zm96 0v32h32v-64h-32zm0-64h32v-32h-32z\" />";
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
