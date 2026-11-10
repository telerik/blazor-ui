using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ZoomOut : SvgIconBase
    {
        public ZoomOut()
        {
            Name = "zoom-out";
            Content = "<path d=\"M288 224H96v-64h192zm192 210.7L434.7 480 320 365.3v-22.7l-26.7-26.7C265.7 338.5 230.4 352 192 352c-88.4 0-160-71.6-160-160S103.6 32 192 32s160 71.6 160 160c0 38.4-13.5 73.7-36.1 101.3l26.7 26.7h22.7zM192 320c70.7 0 128-57.3 128-128S262.7 64 192 64 64 121.3 64 192s57.3 128 128 128\" />";
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
