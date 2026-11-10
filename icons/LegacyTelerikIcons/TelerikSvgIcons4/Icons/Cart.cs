using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Cart : SvgIconBase
    {
        public Cart()
        {
            Name = "cart";
            Content = "<path d=\"M192 368c0 26.51-21.49 48-48 48s-48-21.49-48-48 21.49-48 48-48 48 21.49 48 48m144-48c-26.51 0-48 21.49-48 48s21.49 48 48 48 48-21.49 48-48-21.49-48-48-48M128 96V64H32v32h64v192h288v-32H128zm32 128h256v-32H160zm0-96v32h288v-32z\" />";
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
