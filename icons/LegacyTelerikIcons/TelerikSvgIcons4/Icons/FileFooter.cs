using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class FileFooter : SvgIconBase
    {
        public FileFooter()
        {
            Name = "file-footer";
            Content = "<path d=\"M416 32H96c-17.7 0-32 14.3-32 32v384c0 17.7 14.3 32 32 32h320c17.7 0 32-14.3 32-32V64c0-17.7-14.3-32-32-32m0 416H96V64h320zm-32-224H128v-32h256zm0-96H128v32h256zm0 160H128v96h256z\" />";
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
