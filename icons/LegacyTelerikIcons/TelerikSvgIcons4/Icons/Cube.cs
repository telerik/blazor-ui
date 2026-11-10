using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Cube : SvgIconBase
    {
        public Cube()
        {
            Name = "cube";
            Content = "<path d=\"M256 32 32 128v256l208 89.14 16 6.86 16-6.86L480 384V128zm-16 406L64 362.9V160l176 73zm16-233L96 138l160-71.18L416 138zm192 157.9L272 438V233l176-73z\" />";
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
