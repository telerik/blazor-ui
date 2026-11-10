using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class VideoExternal : SvgIconBase
    {
        public VideoExternal()
        {
            Name = "video-external";
            Content = "<path d=\"M256 0C114.6 0 0 114.6 0 256s114.6 256 256 256 256-114.6 256-256S397.4 0 256 0m-64 384V128l192 128z\" />";
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
