using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class CheckboxChecked : SvgIconBase
    {
        public CheckboxChecked()
        {
            Name = "checkbox-checked";
            Content = "<path d=\"M64 64v384h384V64zm352 352H96V96h320zm-77.3-269.3L384 192 224 352l-96-96 45.3-45.3 50.7 50.7z\" />";
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
