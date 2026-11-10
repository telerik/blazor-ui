using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class CustomIcon : SvgIconBase
    {
        public CustomIcon()
        {
            Name = "custom-icon";
            Content = "<path d=\"M352 249H196.6q.9 35.7 19.8 55.2c18.9 19.5 30 18.8 52 19.4 4.9.1-1.1 28.8-12.4 28.8-30.9 0-51.6-9.7-69.3-29.1-17.8-19.4-26.7-46.8-26.7-82 0-33.3 9.7-60.4 29.1-81.4s43.5-31.4 72.4-31.4c28.8 0 51.1 9.1 66.9 27.2S352 199 352 231.1zm-36-29.9c-.1-19.8-5.1-35.2-14.7-46.2-9.7-11-23.1-16.5-40.3-16.5-16.6 0-30.7 5.8-42.4 17.3-11.6 11.6-18.8 26.7-21.5 45.3zM448 384V64c0-17.7-14.3-32-32-32H96c-17.7 0-32 14.3-32 32v384c0 17.7 14.3 32 32 32h256zm-32-32h-96v96H96V64h320z\" />";
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
