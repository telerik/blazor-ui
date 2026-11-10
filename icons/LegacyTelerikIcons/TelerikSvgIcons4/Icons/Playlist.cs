using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Playlist : SvgIconBase
    {
        public Playlist()
        {
            Name = "playlist";
            Content = "<path d=\"M0 256h320v64H0zM512 64H0V0h512zm-128 64.8V397c-13.4-8-30-12.8-48-12.8-44.2 0-80 28.7-80 64s35.8 64 80 64 80-28.7 80-64V193h96v-65zM0 128v64h320v-64z\" />";
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
