using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class PentagonShape : SvgIconBase
    {
        public PentagonShape()
        {
            Name = "pentagon-shape";
            Content = "<path d=\"m462.52 210.39-64 215.08-.12.34a31.9 31.9 0 0 1-11.57 16.06 31.95 31.95 0 0 1-18.83 6.14H144c-6.77 0-13.36-2.15-18.83-6.14a31.95 31.95 0 0 1-11.57-16.06l-.12-.34-64-215.08a31.97 31.97 0 0 1 .08-19.45c2.04-6.32 6-11.85 11.32-15.81L236.72 38.51l.36-.28A31.83 31.83 0 0 1 256 32c6.81 0 13.44 2.18 18.92 6.23l.36.28 175.84 136.62c5.32 3.96 9.28 9.49 11.32 15.81a31.97 31.97 0 0 1 .08 19.45\" />";
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
