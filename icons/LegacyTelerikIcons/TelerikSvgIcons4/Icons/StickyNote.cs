using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class StickyNote : SvgIconBase
    {
        public StickyNote()
        {
            Name = "sticky-note";
            Content = "<path d=\"M160 32v.37l.37-.37zM32 160v.37l.37-.37zM160.37 32 32 160.37V480h448V32zM160 77.63V160H77.63zM448 448H64V192h128V64h256zm-32-288H224v-32h192zm0 224H96v-32h320zm0-65H96v-32h320zm0-62H96v-32h320z\" />";
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
