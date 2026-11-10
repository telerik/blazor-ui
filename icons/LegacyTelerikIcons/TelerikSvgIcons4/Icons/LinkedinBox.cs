using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Linkedin instead.", false)]
    public class LinkedinBox : SvgIconBase
    {
        public LinkedinBox()
        {
            Name = "linkedin-box";
            Content = "<path d=\"M448 32H64c-17.6 0-32 14.4-32 32v384c0 17.6 14.4 32 32 32h384c17.6 0 32-14.4 32-32V64c0-17.6-14.4-32-32-32M160 416H96V192h64zm-32-256c-17.7 0-32-14.3-32-32s14.3-32 32-32 32 14.3 32 32-14.3 32-32 32m288 256h-64V288c0-17.7-14.3-32-32-32s-32 14.3-32 32v128h-64V192h64v39.7c13.2-18.1 33.4-39.7 56-39.7 39.8 0 72 35.8 72 80z\" />";
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
