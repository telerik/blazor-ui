using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use QrCode instead.", false)]
    public class QrCodeOutline : SvgIconBase
    {
        public QrCodeOutline()
        {
            Name = "qr-code-outline";
            Content = "<path d=\"M192 224v32h-32v-32zm-64 64h32v-32h-32zm-32-64v32h32v-32zm-32 64h32v-32H64zm128 0h32v-32h-32zm64-64h-32v32h32zm32-32h-32v32h32zm-64-32v32h32v-32zm64-32h-32v32h32zm-64-32v32h32V96zm64-32h-32v32h32zm32 192v-32h-32v32zm-96 32v32h32v-32zm64-32h-32v32h32zm0 64h-32v32h32zm-64 32v32h32v-32zm32 32v32h32v-32zm-32 64h32v-32h-32zm64-96v32h32v-32zm32-32v-32h-32v32zm32-32v-32h-32v32zm32-64h-32v32h32zm32 64v-32h-32v32zm32-64h-32v32h32zm-64 96v-32h-32v32zm-32 32v-32h-32v32zm0 32h32v-32h-32zm32-32h32v-32h-32zm64-32v-32h-32v32zm-128 64v32h32v-32zm-32 64h32v-32h-32zm64 0h32v-32h-32zm32-32h32v-32h-32zm64-32v-32h-32v32zm0 64v-32h-32v32zM512 0v512H0V0zm-32 32H32v448h448zm-32 160H320V64h128zm-32-32-.5-64H352v64zm-224 32H64V64h128zm-32-32-.5-64H96v64zm32 288H64V320h128zm-32-32-.5-64H96v64z\" />";
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
