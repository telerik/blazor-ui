using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use RulerTriangle instead.", false)]
    public class RulerTriangleSolid : SvgIconBase
    {
        public RulerTriangleSolid()
        {
            Name = "ruler-triangle-solid";
            Content = "<path d=\"M480 479 32 31v80h32v16H32v32h32v16H32v32h32v16H32v32h32v16H32v32h32v16H32v32h32v16H32v32h32v16H32v64h64v-32h16v32h32v-32h16v32h32v-32h16v32h32v-32h16v32h32v-32h16v32h32v-32h16v32h32v-32h16v32zm-368-80V210.42L302.94 399z\" />";
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
