using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class FileHorizontal : SvgIconBase
    {
        public FileHorizontal()
        {
            Name = "file-horizontal";
            Content = "<path d=\"M384 64H64c-17.7 0-32 14.3-32 32v320c0 17.7 14.3 32 32 32h384c17.7 0 32-14.3 32-32V160zm64 352H64V96h288v96h96z\" />";
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
