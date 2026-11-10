using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class DropletSlider : SvgIconBase
    {
        public DropletSlider()
        {
            Name = "droplet-slider";
            Content = "<path d=\"M192 384v32c-53 0-96-43-96-96h32c0 35.3 28.7 64 64 64m160-72c0 92.8-71.6 168-160 168S32 404.8 32 312C32 181.3 192 32 192 32s160 149.3 160 280m-32 0c0-46.3-25.3-104.7-73-169-20-27-40.3-49.8-55-65.4-14.7 15.6-34.9 38.5-55 65.4-47.8 64.3-73 122.8-73 169 0 75 57.4 136 128 136s128-61 128-136m128-88h-32v256h32zm0-192h-32v64h32zm-64 96v64h96v-64z\" />";
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
