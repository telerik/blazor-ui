using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Banknote instead.", false)]
    public class BanknoteSolid : SvgIconBase
    {
        public BanknoteSolid()
        {
            Name = "banknote-solid";
            Content = "<path d=\"M32 128v256h448V128zm384 181.33c-4.86 0-9.41 1.31-13.33 3.59a26.66 26.66 0 0 0-9.75 9.75 26.4 26.4 0 0 0-3.59 13.33H122.67c0-4.86-1.31-9.41-3.59-13.33a26.66 26.66 0 0 0-9.75-9.75A26.4 26.4 0 0 0 96 309.33V202.67c4.86 0 9.41-1.31 13.33-3.59a26.66 26.66 0 0 0 9.75-9.75c2.28-3.92 3.59-8.47 3.59-13.33h266.66c0 4.86 1.31 9.41 3.59 13.33a26.66 26.66 0 0 0 9.75 9.75c3.92 2.28 8.47 3.59 13.33 3.59zM366.84 208H145.16A59 59 0 0 1 128 225.16v61.68A59 59 0 0 1 145.16 304h221.68A59 59 0 0 1 384 286.84v-61.68A59 59 0 0 1 366.84 208M256 288c-17.67 0-32-14.33-32-32s14.33-32 32-32 32 14.33 32 32-14.33 32-32 32\" />";
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
