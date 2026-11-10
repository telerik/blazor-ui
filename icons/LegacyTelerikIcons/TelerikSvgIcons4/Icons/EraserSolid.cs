using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Eraser instead.", false)]
    public class EraserSolid : SvgIconBase
    {
        public EraserSolid()
        {
            Name = "eraser-solid";
            Content = "<path d=\"m209.34 213.19-22.62-22.62 152.9-152.89c3.13-3.12 7.22-4.68 11.32-4.68s8.18 1.56 11.31 4.68l113.06 113.05c6.25 6.25 6.25 16.38 0 22.63L322.4 326.26l-22.61-22.62M231.64 417l68.13-68.13-135.66-135.68h-.02L50.75 326.52c-24.99 24.98-24.99 65.5-.01 90.48zm-32.08 32.07.07-.07H82.76l.07.07H32.01V481h448v-31.93H199.55zm100.22-146.41-90.43-90.44-.02.02 90.44 90.42z\" />";
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
