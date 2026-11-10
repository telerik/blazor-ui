using Telerik.SvgIcons;

namespace TelerikSvgIcons4
{
    [System.Obsolete("since v4. Will be removed in v5. Use Devices instead.", false)]
    public class DevicesSolid : SvgIconBase
    {
        public DevicesSolid()
        {
            Name = "devices-solid";
            Content = "<path d=\"M416 96H96c-17.67 0-32 14.33-32 32v224h240V208c0-3.94.72-7.79 2.14-11.49C310.88 184.24 322.88 176 336 176h112v-48c0-17.67-14.33-32-32-32M306.14 411.49l-.03-.06c-1.4-3.67-2.11-7.52-2.11-11.43v-16h-16v8c0 4.42-3.58 8-8 8h-48c-4.42 0-8-3.58-8-8v-8H32c0 17.67 14.33 32 32 32h244.32c-.84-1.43-1.57-2.94-2.18-4.51M464 192H336c-6.78 0-12.62 4.28-14.94 10.28-.68 1.77-1.06 3.7-1.06 5.72v192c0 2.01.38 3.94 1.06 5.72 2.32 6 8.16 10.28 14.94 10.28h128c8.8 0 16-7.2 16-16V208c0-8.8-7.2-16-16-16m-64 216c-2.21 0-4.21-.9-5.66-2.34A8.01 8.01 0 0 1 392 400a7.998 7.998 0 0 1 10.02-7.74c3.44.89 5.98 4.02 5.98 7.74 0 4.42-3.58 8-8 8m64-24H336V208h128z\" />";
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
