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

    public List<HealthMetricPoint> GetHealthMetrics() => new()
    {
        new() { Month = "Oct", Glucose = 95,  Cholesterol = 180, Hemoglobin = 13.5, Creatinine = 1.0, Bilirubin = 0.8 },
        new() { Month = "Nov", Glucose = 98,  Cholesterol = 185, Hemoglobin = 13.2, Creatinine = 1.1, Bilirubin = 0.9 },
        new() { Month = "Dec", Glucose = 102, Cholesterol = 192, Hemoglobin = 13.8, Creatinine = 1.0, Bilirubin = 0.7 },
        new() { Month = "Jan", Glucose = 105, Cholesterol = 198, Hemoglobin = 14.0, Creatinine = 1.2, Bilirubin = 0.8 },
        new() { Month = "Feb", Glucose = 108, Cholesterol = 202, Hemoglobin = 13.6, Creatinine = 1.1, Bilirubin = 0.9 },
        new() { Month = "Mar", Glucose = 110, Cholesterol = 208, Hemoglobin = 14.2, Creatinine = 1.0, Bilirubin = 0.7 },
        new() { Month = "Apr", Glucose = 112, Cholesterol = 212, Hemoglobin = 13.9, Creatinine = 1.1, Bilirubin = 0.8 },
    };

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
