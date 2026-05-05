using BlazorHealthcareApp.Models;

namespace BlazorHealthcareApp.Services;

public class AlertService
{
    public List<DailyAlert> GetDailyAlerts() => new()
    {
        new()
        {
            Id = 1,
            Text = "CRP elevated – Sophia Martinez",
            Timestamp = DateTime.Now.AddMinutes(-15),
            Patient = "Sophia Martinez",
            PatientId = "P-105328",
            Condition = "CRP Elevated",
            Value = "12.5 mg/L",
            NormalRange = "0-10 mg/L",
            Priority = "High",
            Details = "C-reactive protein (CRP) levels are significantly elevated, indicating possible inflammation or infection. Recent lab results show a marked increase from the last test.",
            Recommendations = new() {
                "Order additional inflammatory markers panel",
                "Review recent medical history for infection symptoms",
                "Schedule follow-up appointment within 48 hours",
                "Consider antibiotic treatment if infection is suspected"
            }
        },
        new()
        {
            Id = 2,
            Text = "Blood pressure high – James Carter",
            Timestamp = DateTime.Now.AddMinutes(-15),
            Patient = "James Carter",
            PatientId = "P-104582",
            Condition = "Blood Pressure High",
            Value = "165/98 mmHg",
            NormalRange = "120/80 mmHg",
            Priority = "High",
            Details = "Blood pressure readings are consistently elevated above normal range. Patient has history of hypertension but readings have increased despite current medication.",
            Recommendations = new() {
                "Review current antihypertensive medication dosage",
                "Check for medication compliance",
                "Order ECG and kidney function tests",
                "Consider adjusting or adding medication",
                "Advise lifestyle modifications (diet, exercise, stress management)"
            }
        },
        new()
        {
            Id = 3,
            Text = "Glucose levels elevated – Daniel Rivera",
            Timestamp = DateTime.Now.AddMinutes(-15),
            Patient = "Daniel Rivera",
            PatientId = "P-103847",
            Condition = "Glucose Elevated",
            Value = "185 mg/dL",
            NormalRange = "70-100 mg/dL",
            Priority = "Medium",
            Details = "Fasting glucose levels are above the normal range, suggesting possible pre-diabetic or diabetic condition. Patient has a family history of type 2 diabetes.",
            Recommendations = new() {
                "Order HbA1c test for long-term glucose assessment",
                "Refer to endocrinology for further evaluation",
                "Discuss dietary modifications and exercise plan",
                "Schedule follow-up in 2 weeks"
            }
        },
        new()
        {
            Id = 4,
            Text = "High cholesterol detected – Ava Thompson",
            Timestamp = DateTime.Now.AddMinutes(-15),
            Patient = "Ava Thompson",
            PatientId = "P-106291",
            Condition = "High Cholesterol",
            Value = "268 mg/dL",
            NormalRange = "<200 mg/dL",
            Priority = "Medium",
            Details = "Total cholesterol is significantly elevated. LDL cholesterol is also above target range. Patient is currently not on any lipid-lowering medication.",
            Recommendations = new() {
                "Initiate statin therapy after risk assessment",
                "Order comprehensive lipid panel",
                "Advise heart-healthy diet and regular exercise",
                "Schedule follow-up lipid check in 6 weeks"
            }
        },
        new()
        {
            Id = 5,
            Text = "Low hemoglobin – Maria Gonzalez",
            Timestamp = DateTime.Now.AddMinutes(-10),
            Patient = "Maria Gonzalez",
            PatientId = "P-107455",
            Condition = "Low Hemoglobin",
            Value = "9.8 g/dL",
            NormalRange = "12-16 g/dL",
            Priority = "High",
            Details = "Hemoglobin levels are below the normal range, indicating anemia. Patient reports fatigue and occasional dizziness over the past two weeks.",
            Recommendations = new() {
                "Order iron studies and reticulocyte count",
                "Check for signs of gastrointestinal bleeding",
                "Consider iron supplementation",
                "Schedule follow-up CBC in 1 week"
            }
        },
    };
}
