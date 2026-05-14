namespace elyra.Models;

public class KpiMetric
{
    public string Label { get; init; } = string.Empty;

    public string Value { get; init; } = string.Empty;

    public string Delta { get; init; } = string.Empty;

    public bool Positive { get; init; }

    public int ProgressPercent { get; init; }
}
