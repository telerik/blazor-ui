using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use QuestionCircle instead.", false)]
    public class QuestionSolid : SvgIconBase
    {
        public QuestionSolid()
        {
            Name = "question-solid";
            Content = "<path d=\"M256 32C132.3 32 32 132.3 32 256s100.3 224 224 224 224-100.3 224-224S379.7 32 256 32m32 384h-64v-64h64zm23.4-143c-15.1 13.3-23.4 20.7-23.4 47h-64c0-55.2 27.1-79.2 45.1-95 13.8-12.1 18.9-16.7 18.9-33 0-17.6-14.4-32-32-32s-32 14.4-32 32h-64c0-53 43-96 96-96s96 43 96 96c0 45.2-23.4 65.9-40.6 81\" />";
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
