namespace RemoteValidationWasm.Shared;

public class WeatherForecast
{
    public int Id { get; set; }

    public DateTime Date { get; set; } = DateTime.Today;

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
