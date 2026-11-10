using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use User instead.", false)]
    public class UserOutline : SvgIconBase
    {
        public UserOutline()
        {
            Name = "user-outline";
            Content = "<path d=\"M256 224c53.02 0 96-42.98 96-96s-42.98-96-96-96-96 42.98-96 96 42.98 96 96 96m0-32c-35.348 0-64-28.654-64-64s28.652-64 64-64 64 28.654 64 64-28.652 64-64 64M96 480c-17.7 0-32-14.301-32-32 0-106 86-192 192-192s192 86 192 192c0 17.699-14.301 32-32 32zm160-192c-88.367 0-160 71.635-160 160h320c0-88.365-71.633-160-160-160\" />";
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
