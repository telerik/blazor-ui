using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use TextWrapArrow instead.", false)]
    public class TextWrap : SvgIconBase
    {
        public TextWrap()
        {
            Name = "text-wrap";
            Content = "<path d=\"M480 96v32H96V96zM352 256v224H32V256zm-32 32H64v160h256zm-32 32H96v32h192zm0 96v-32H96v32zM64 64h288V32H32v160h320v-32H64z\" />";
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
