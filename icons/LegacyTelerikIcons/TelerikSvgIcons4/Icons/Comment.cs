using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Comment : SvgIconBase
    {
        public Comment()
        {
            Name = "comment";
            Content = "<path d=\"M448 32H64c-17.6 0-32 14.4-32 32v416l96-96h320c17.6 0 32-14.4 32-32V64c0-17.6-14.4-32-32-32m0 319.942a1 1 0 0 1-.058.058H114.745L64 402.745V64.057a1 1 0 0 1 .057-.057h383.885q.031.027.058.057z\" />";
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
