using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class CheckboxIndeterminate : SvgIconBase
    {
        public CheckboxIndeterminate()
        {
            Name = "checkbox-indeterminate";
            Content = "<path d=\"M128 128h256v256H128zM64 64v384h384V64zm352 352H96V96h320z\" />";
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
