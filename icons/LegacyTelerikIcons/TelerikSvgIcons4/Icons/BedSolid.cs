using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Bed instead.", false)]
    public class BedSolid : SvgIconBase
    {
        public BedSolid()
        {
            Name = "bed-solid";
            Content = "<path d=\"M448 224V64c0-17.6-14.4-32-32-32H96c-17.6 0-32 14.4-32 32v160c-17.6 0-32 14.4-32 32v224h32c.07-.12.09-27.83.09-64H448v64h32V256c0-17.6-14.4-32-32-32m-32 0H96.08C96.11 171.07 96 64.06 96 64.06l.06-.06h319.88l.06.06zm-32-95.92V207H128v-79c0-17.67 14.33-32 32-32h191.92c17.72 0 32.08 14.36 32.08 32.08\" />";
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
