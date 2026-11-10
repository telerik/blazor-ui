using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    public class QuestionCircle : SvgIconBase
    {
        public QuestionCircle()
        {
            Name = "question-circle";
            Content = "<path d=\"M352 192c0 45.2-23.4 65.9-40.6 81-15.1 13.3-23.4 20.7-23.4 47h-64c0-55.2 27.1-79.2 45.1-95 13.8-12.1 18.9-16.7 18.9-33 0-17.6-14.4-32-32-32s-32 14.4-32 32h-64c0-53 43-96 96-96s96 43 96 96M224 416h64v-64h-64zm256-160c0 123.7-100.3 224-224 224S32 379.7 32 256 132.3 32 256 32s224 100.3 224 224m-32 0c0-106-86-192-192-192S64 150 64 256s86 192 192 192 192-86 192-192\" />";
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
