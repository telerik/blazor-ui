namespace BlazorHealthcareApp.Models;

public class VitalDataPoint
{
    public string Month { get; set; } = "";
    public double SystolicBP { get; set; }
    public double DiastolicBP { get; set; }
    public double HeartRate { get; set; }
    public double SpO2 { get; set; }
    public double Temperature { get; set; }
    public double Pulse { get; set; }
}

public class AlertTimeData
{
    public string Month { get; set; } = "";
    public double Critical { get; set; }
    public double Warning { get; set; }
    public double Info { get; set; }
}

public class HealthMetricPoint
{
    public string Month { get; set; } = "";
    public double Glucose { get; set; }
    public double Cholesterol { get; set; }
    public double Hemoglobin { get; set; }
    public double Creatinine { get; set; }
    public double Bilirubin { get; set; }
}

public class AlertCategoryData
{
    public string Category { get; set; } = "";
    public double Value { get; set; }
    public string Color { get; set; } = "";
}
