using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class TableBody : SvgIconBase
    {
        public TableBody()
        {
            Name = "table-body";
            Content = "<path d=\"M32 32v416h416V32zm256 32v96h-96V64zm128 256v64L224 192h64zM64 64h96v96H64zm0 128h96v96H64zm0 224v-96h96v96zm128 0v-64l64 64zm128 0L192 288v-64l192 192zm96-160-64-64h64zm0-96h-96V64h96z\" />";
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
