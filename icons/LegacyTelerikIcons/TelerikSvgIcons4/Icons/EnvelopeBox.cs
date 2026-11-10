using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Envelope instead.", false)]
    public class EnvelopeBox : SvgIconBase
    {
        public EnvelopeBox()
        {
            Name = "envelope-box";
            Content = "<path d=\"m377 182.4-88.8 88.8-31.2 29-33.2-29-88.8-88.8c-7.7 2-13.8 8.1-15.8 15.8l73 73-73 73c2 7.7 8.1 13.8 15.8 15.8l73-73 49 44.8 47-44.8 73 73c7.7-2 13.8-8.1 15.8-15.8l-73-73 73-73c-2-7.7-8.1-13.8-15.8-15.8M448 32H64c-17.7 0-32 14.3-32 32v384c0 17.7 14.3 32 32 32h384c17.7 0 32-14.3 32-32V64c0-17.7-14.3-32-32-32m-32 329.6c0 12.4-10 22.4-22.4 22.4H118.4C106 384 96 374 96 361.6V182.4c0-12.4 10-22.4 22.4-22.4h275.2c12.4 0 22.4 10 22.4 22.4z\" />";
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
