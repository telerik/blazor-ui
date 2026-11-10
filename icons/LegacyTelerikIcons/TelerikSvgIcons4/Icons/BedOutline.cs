using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Bed instead.", false)]
    public class BedOutline : SvgIconBase
    {
        public BedOutline()
        {
            Name = "bed-outline";
            Content = "<path d=\"M448 224V64c0-17.6-14.4-32-32-32H96c-17.6 0-32 14.4-32 32v160c-17.6 0-32 14.4-32 32v224h32c.07-.12.09-27.83.09-64H448v64h32V256c0-17.6-14.4-32-32-32M96.06 64h319.88l.06.06V224h-32v-95.92C384 110.36 369.64 96 351.92 96H160c-17.67 0-32 14.33-32 42v86H96.08C96.11 171.07 96 64.06 96 64.06zM352 224H160v-96h191.95l.05.03zm96 160H64.08c-.02-63.44-.08-127.94-.08-127.94l.06-.06h383.88l.06.06z\" />";
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
