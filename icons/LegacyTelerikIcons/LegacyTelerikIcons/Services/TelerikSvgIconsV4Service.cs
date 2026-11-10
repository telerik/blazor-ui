using System;
using System.Collections.Concurrent;
using System.Reflection;
using Telerik.Blazor.Services;
using Telerik.SvgIcons;
using TelerikSvgIcons4;

namespace LegacyTelerikIcons.Services;

public class TelerikSvgIconsV4Service : ITelerikIconService
{
    private static readonly ConcurrentDictionary<string, PropertyInfo?> Cache = new();

    public object? ReplaceIcon(IconInfo iconInfo)
    {
        var prop = Cache.GetOrAdd(iconInfo.IconName,
            name => typeof(SvgIcon4).GetProperty(name, BindingFlags.Public | BindingFlags.Static));
        return prop?.GetValue(null) as ISvgIcon;
    }
}
