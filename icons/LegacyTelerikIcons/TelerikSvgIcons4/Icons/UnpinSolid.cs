using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Unpin instead.", false)]
    public class UnpinSolid : SvgIconBase
    {
        public UnpinSolid()
        {
            Name = "unpin-solid";
            Content = "<path d=\"M284.8 352H272v112c0 9.6-6.4 16-16 16s-16-6.4-16-16V352H128c-16 0-32-16-32-32v-64c0-16 16-32 32-32 9.6 0 16 0 22.4-3.2zM384 224c-35.2 0-64-28.8-64-64v-32c16 0 32-16 32-32V64c0-16-16-32-32-32H192c-16 0-32 16-32 32v28.8l249.6 249.6c3.2-6.4 6.4-12.8 6.4-19.2V256c0-16-16-32-32-32m-9.6 128L192 169.6 54.4 32 32 54.4 457.6 480l22.4-22.4z\" />";
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
