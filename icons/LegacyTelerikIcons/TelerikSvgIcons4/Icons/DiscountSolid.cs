using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Discount instead.", false)]
    public class DiscountSolid : SvgIconBase
    {
        public DiscountSolid()
        {
            Name = "discount-solid";
            Content = "<path d=\"M200 256c13.26 0 24-17.91 24-40s-10.74-40-24-40-24 17.91-24 40 10.74 40 24 40m280-.04-30.02-51.97v-60.02l-51.99-30-30.02-51.98h-60.02L255.96 32l-51.97 30.02h-60.02l-30 51.99-51.98 30.02v60.02L32 256.04l30.02 51.97v60.02l51.99 30 30.02 51.98h60.02L256.04 480l51.97-30.02h60.02l30-51.99 51.98-30.02v-60.02zM160 216c0-30.95 17.9-56 40-56s40 25.05 40 56-17.9 56-40 56-40-25.05-40-56m48 136h-16l112-192h16zm104 0c-22.1 0-40-25.05-40-56s17.9-56 40-56 40 25.05 40 56-17.9 56-40 56m0-96c-11.35 0-24 16.45-24 40s12.65 40 24 40 24-16.45 24-40-12.65-40-24-40\" />";
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
