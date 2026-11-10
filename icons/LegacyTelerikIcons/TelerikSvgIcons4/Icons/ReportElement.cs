using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class ReportElement : SvgIconBase
    {
        public ReportElement()
        {
            Name = "report-element";
            Content = "<path d=\"M480 320V192H160v48H96v-80h256V32H32v128h32v320h32v-48h64v48h256V352H160v48H96V272h64v48ZM64 64h256v64H64Zm128 320h192v64H192z\" />";
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
