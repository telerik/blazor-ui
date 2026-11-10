using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use File instead.", false)]
    public class FileFlash : SvgIconBase
    {
        public FileFlash()
        {
            Name = "file-flash";
            Content = "<path d=\"M352 191.3V237c-21 .2-46.6-3.2-69.6 45H320v45h-47.9s-37.4 91.1-111.9 90.1c-.6-10 0-30.8 0-45 49.3-7.6 65.4-62.1 76.8-89.4 26.5-82.8 73.9-92 93.4-92.1 5.6 0 21.6.7 21.6.7m96-63.3v320c0 17.7-14.3 32-32 32H96c-17.7 0-32-14.3-32-32V64c0-17.7 14.3-32 32-32h256zm-32 32h-96V64H96v384h320z\" />";
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
