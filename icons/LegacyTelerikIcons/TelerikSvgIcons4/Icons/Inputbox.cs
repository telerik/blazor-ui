using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class Inputbox : SvgIconBase
    {
        public Inputbox()
        {
            Name = "inputbox";
            Content = "<path d=\"M32 160v192c13-.07 448 0 448 0V160zm416 160H64V192h384zM96 240h272v32H96zm320-32v96h-16v-96z\" />";
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
