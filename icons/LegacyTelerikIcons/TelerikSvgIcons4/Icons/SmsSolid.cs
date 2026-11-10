using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Sms instead.", false)]
    public class SmsSolid : SvgIconBase
    {
        public SmsSolid()
        {
            Name = "sms-solid";
            Content = "<path d=\"M64 32h384c17.6 0 32 14.4 32 32v288c0 17.6-14.4 32-32 32H128l-96 96V64c0-17.6 14.4-32 32-32m80 144c-17.67 0-32 14.33-32 32s14.33 32 32 32 32-14.33 32-32-14.33-32-32-32m112 0c-17.67 0-32 14.33-32 32s14.33 32 32 32 32-14.33 32-32-14.33-32-32-32m112 0c-17.67 0-32 14.33-32 32s14.33 32 32 32 32-14.33 32-32-14.33-32-32-32\" />";
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
