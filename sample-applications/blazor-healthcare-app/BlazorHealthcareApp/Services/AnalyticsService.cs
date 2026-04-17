using BlazorHealthcareApp.Models;

namespace BlazorHealthcareApp.Services;

public class AnalyticsService
{
    public int GetRiskScore() => 50;

    public int GetRiskScore(int patientId)
    {
        var rng = new Random(patientId * 31);
        return 30 + rng.Next(0, 50);
    }

    public List<VitalDataPoint> GetVitalsData() => GetVitalsData(1);

    public List<VitalDataPoint> GetVitalsData(int patientId)
    {
        var rng = new Random(patientId * 37);
        int Vary(int val) => Math.Max(0, val + rng.Next(-3, 4));
        return new()
        {
            new() { Month = "Jan", SystolicBP = Vary(25), DiastolicBP = Vary(10), HeartRate = Vary(13), SpO2 = Vary(10), Temperature = Vary(8),  Pulse = Vary(2)  },
            new() { Month = "Feb", SystolicBP = Vary(24), DiastolicBP = Vary(14), HeartRate = Vary(15), SpO2 = Vary(15), Temperature = Vary(7),  Pulse = Vary(9)  },
            new() { Month = "Mar", SystolicBP = Vary(27), DiastolicBP = Vary(20), HeartRate = Vary(25), SpO2 = Vary(15), Temperature = Vary(10), Pulse = Vary(11) },
            new() { Month = "Apr", SystolicBP = Vary(25), DiastolicBP = Vary(18), HeartRate = Vary(20), SpO2 = Vary(20), Temperature = Vary(8),  Pulse = Vary(13) },
            new() { Month = "May", SystolicBP = Vary(30), DiastolicBP = Vary(13), HeartRate = Vary(17), SpO2 = Vary(16), Temperature = Vary(13), Pulse = Vary(12) },
        };
    }

    public List<AlertTimeData> GetAlertsOverTime() => GetAlertsOverTime(1);

    public List<AlertTimeData> GetAlertsOverTime(int patientId)
    {
        var rng = new Random(patientId * 41);
        int Vary(int val) => Math.Max(0, val + rng.Next(-2, 3));
        return new()
        {
            new() { Month = "Jan", Critical = Vary(5),  Warning = Vary(4),  Info = Vary(18) },
            new() { Month = "Feb", Critical = Vary(8),  Warning = Vary(7),  Info = Vary(11) },
            new() { Month = "Mar", Critical = Vary(7),  Warning = Vary(10), Info = Vary(5)  },
            new() { Month = "Apr", Critical = Vary(10), Warning = Vary(3),  Info = Vary(17) },
            new() { Month = "May", Critical = Vary(7),  Warning = Vary(5),  Info = Vary(15) },
            new() { Month = "Jun", Critical = Vary(4),  Warning = Vary(2),  Info = Vary(8)  },
            new() { Month = "Jul", Critical = Vary(7),  Warning = Vary(6),  Info = Vary(15) },
            new() { Month = "Aug", Critical = Vary(8),  Warning = Vary(8),  Info = Vary(12) },
            new() { Month = "Sep", Critical = Vary(9),  Warning = Vary(3),  Info = Vary(20) },
            new() { Month = "Oct", Critical = Vary(4),  Warning = Vary(3),  Info = Vary(6)  },
        };
    }

    public List<HealthMetricPoint> GetHealthMetrics() => GetHealthMetrics(1);

    public List<HealthMetricPoint> GetHealthMetrics(int patientId)
    {
        var rng = new Random(patientId * 59);
        double Vary(double val) => Math.Round(val + (rng.NextDouble() * 10 - 5), 1);
        return new()
        {
            new() { Month = "Oct", Glucose = Vary(95),  Cholesterol = Vary(180), Hemoglobin = Vary(13.5), Creatinine = Vary(1.0), Bilirubin = Vary(0.8) },
            new() { Month = "Nov", Glucose = Vary(98),  Cholesterol = Vary(185), Hemoglobin = Vary(13.2), Creatinine = Vary(1.1), Bilirubin = Vary(0.9) },
            new() { Month = "Dec", Glucose = Vary(102), Cholesterol = Vary(192), Hemoglobin = Vary(13.8), Creatinine = Vary(1.0), Bilirubin = Vary(0.7) },
            new() { Month = "Jan", Glucose = Vary(105), Cholesterol = Vary(198), Hemoglobin = Vary(14.0), Creatinine = Vary(1.2), Bilirubin = Vary(0.8) },
            new() { Month = "Feb", Glucose = Vary(108), Cholesterol = Vary(202), Hemoglobin = Vary(13.6), Creatinine = Vary(1.1), Bilirubin = Vary(0.9) },
            new() { Month = "Mar", Glucose = Vary(110), Cholesterol = Vary(208), Hemoglobin = Vary(14.2), Creatinine = Vary(1.0), Bilirubin = Vary(0.7) },
            new() { Month = "Apr", Glucose = Vary(112), Cholesterol = Vary(212), Hemoglobin = Vary(13.9), Creatinine = Vary(1.1), Bilirubin = Vary(0.8) },
        };
    }

    public List<AlertCategoryData> GetAlertsByCategory() => GetAlertsByCategory(1);

    public List<AlertCategoryData> GetAlertsByCategory(int patientId)
    {
        var rng = new Random(patientId * 53);
        int Vary(int val) => Math.Max(1, val + rng.Next(-5, 6));
        return new()
        {
            new() { Category = "Arrhythmia",           Value = Vary(12), Color = "#FF6358" },
            new() { Category = "Hypertension",         Value = Vary(18), Color = "#FFE162" },
            new() { Category = "High Cholesterol",     Value = Vary(25), Color = "#4CD180" },
            new() { Category = "Medication Adherence", Value = Vary(34), Color = "#4B5FFA" },
            new() { Category = "Inflammation",         Value = Vary(43), Color = "#AC58FF" },
            new() { Category = "Cardiac Risk",         Value = Vary(51), Color = "#FF5892" },
        };
    }
}
