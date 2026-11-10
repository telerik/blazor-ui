using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Facebook instead.", false)]
    public class FacebookBox : SvgIconBase
    {
        public FacebookBox()
        {
            Name = "facebook-box";
            Content = "<path d=\"M57.6 32C43.6 32 32 43.5 32 57.6v396.8c0 14 11.5 25.6 25.6 25.6h396.8c14 0 25.6-11.5 25.6-25.6V57.6c0-14-11.5-25.6-25.6-25.6zm315.8 65.5c24.1 0 42 2.3 42 2.3L414 155s-18.2-.2-38.1-.2c-21.5 0-24.9 9.9-24.9 26.1V224h64.1l-2.8 59H351v165h-63V283h-44v-59h44v-50.5c0-39.6 25.8-76 85.4-76\" />";
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
