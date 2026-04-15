using BlazorHealthcareApp.Models;

namespace BlazorHealthcareApp.Services;

public class AnalyticsService
{
    public int GetRiskScore() => 50;

    public List<VitalDataPoint> GetVitalsData() => new()
    {
        new() { Month = "Jan", SystolicBP = 25, DiastolicBP = 10, HeartRate = 13, SpO2 = 10, Temperature = 8,  Pulse = 2  },
        new() { Month = "Feb", SystolicBP = 24, DiastolicBP = 14, HeartRate = 15, SpO2 = 15, Temperature = 7,  Pulse = 9  },
        new() { Month = "Mar", SystolicBP = 27, DiastolicBP = 20, HeartRate = 33, SpO2 = 15, Temperature = 10, Pulse = 11 },
        new() { Month = "Apr", SystolicBP = 25, DiastolicBP = 18, HeartRate = 20, SpO2 = 20, Temperature = 8,  Pulse = 13 },
        new() { Month = "May", SystolicBP = 30, DiastolicBP = 13, HeartRate = 17, SpO2 = 16, Temperature = 13, Pulse = 12 },
    };

    public List<AlertTimeData> GetAlertsOverTime() => new()
    {
        new() { Month = "Jan", Critical = 5,  Warning = 4, Info = 18 },
        new() { Month = "Feb", Critical = 8,  Warning = 7, Info = 11 },
        new() { Month = "Mar", Critical = 7,  Warning = 10, Info = 5 },
        new() { Month = "Apr", Critical = 10, Warning = 3, Info = 17 },
        new() { Month = "May", Critical = 7,  Warning = 5, Info = 15 },
        new() { Month = "Jun", Critical = 4,  Warning = 2, Info = 8  },
        new() { Month = "Jul", Critical = 7,  Warning = 6, Info = 15 },
        new() { Month = "Aug", Critical = 8,  Warning = 8, Info = 12 },
        new() { Month = "Sep", Critical = 9,  Warning = 3, Info = 20 },
        new() { Month = "Oct", Critical = 4,  Warning = 3, Info = 6  },
    };

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

    public List<AlertCategoryData> GetAlertsByCategory() => new()
    {
        new() { Category = "Arrhythmia",           Value = 12, Color = "#FF6358" },
        new() { Category = "Hypertension",         Value = 18, Color = "#FFE162" },
        new() { Category = "High Cholesterol",     Value = 25, Color = "#4CD180" },
        new() { Category = "Medication Adherence", Value = 34, Color = "#4B5FFA" },
        new() { Category = "Inflammation",         Value = 43, Color = "#AC58FF" },
        new() { Category = "Cardiac Risk",         Value = 51, Color = "#FF5892" },
    };
}
