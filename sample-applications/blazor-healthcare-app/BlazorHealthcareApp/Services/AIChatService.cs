using BlazorHealthcareApp.Models;

namespace BlazorHealthcareApp.Services;

public class AIChatService
{
    public List<string> GetSuggestions(int? patientId) => patientId switch
    {
        null => new() { "Summary for next patient", "Provide lab results" },
        _    => new() { "Summarize patient history", "Highlight risk" },
    };

    public string GetSuggestionUserText(string suggestion) => suggestion switch
    {
        "Summary for next patient"  => "Can you summarize the next patient?",
        "Provide lab results"       => "Provide lab results for next patient",
        "Summarize patient history" => "Can you summarize the patient list?",
        "Highlight risk"            => "Identify high-risk patients",
        _                           => suggestion,
    };

    public string GetSuggestionResponse(string suggestion, List<PatientModel>? patients) => suggestion switch
    {
        "Summary for next patient"  => "James Wilson (P-104582) is a 45-year-old male admitted for hypertensive crisis. Vitals are stabilizing, but BP remains slightly elevated at 145/95. No known allergies.",
        "Provide lab results"       => "Lab results for James Wilson (collected 03/28/2026): CBC: WBC 11.2 (H), RBC 4.8, Hgb 14.1, Plt 245. CMP: Glucose 98, BUN 18, Creatinine 1.0. CRP: 2.4 mg/L (normal). Chest X-ray: Mild bronchial thickening noted.",
        "Summarize patient history" => BuildPatientSummary(patients),
        "Highlight risk"            => BuildHighRiskResponse(patients),
        _                           => "I'm sorry, I don't have information for that query.",
    };

    public string GetFreeTextResponse(string text, List<PatientModel>? patients)
    {
        var lower = text.ToLowerInvariant();

        if (patients != null)
        {
            if (lower.Contains("risk") || lower.Contains("critical") || lower.Contains("high-risk"))
                return BuildHighRiskResponse(patients);
            if (lower.Contains("summary") || lower.Contains("summarize") || lower.Contains("list") || lower.Contains("overview"))
                return BuildPatientSummary(patients);
            if (lower.Contains("allerg"))
            {
                var withAllergies = patients.Where(p => p.Allergies.Any()).ToList();
                return $"{withAllergies.Count} patients have known allergies: " +
                       string.Join("; ", withAllergies.Select(p => $"{p.Name} ({string.Join(", ", p.Allergies)})")) +
                       ". Verify allergy bands before administering medication.";
            }
            return "I can help with patient summaries, risk analysis, allergy checks, and clinical insights. Try asking about a specific topic!";
        }

        if (lower.Contains("summary") || lower.Contains("next patient") || lower.Contains("summarize"))
            return "James Wilson (P-104582) is a 45-year-old male admitted for hypertensive crisis. Vitals are stabilizing, but BP remains slightly elevated at 145/95. No known allergies.";
        if (lower.Contains("lab") || lower.Contains("result"))
            return "Lab results for James Wilson (collected 03/28/2026): CBC: WBC 11.2 (H), RBC 4.8, Hgb 14.1, Plt 245. CMP: Glucose 98, BUN 18, Creatinine 1.0. CRP: 2.4 mg/L (normal). Chest X-ray: Mild bronchial thickening noted.";
        if (lower.Contains("how many") || lower.Contains("patient") && lower.Contains("today"))
            return "You have 9 patients scheduled today: 3 Complete, 1 In Progress, 3 Upcoming, 2 Cancelled. Next patient: James Wilson at 11:00 AM.";
        if (lower.Contains("allerg"))
            return "2 patients with known allergies today: Ava Patel \u2013 Shellfish allergy (10:30 AM, In Progress), James Wilson \u2013 Penicillin allergy (11:00 AM, Upcoming). Please verify allergy bands before administering medication.";
        return "I can help with patient summaries, lab results, scheduling, and allergy information. Try asking about a specific topic!";
    }

    private static string BuildPatientSummary(List<PatientModel>? patients)
    {
        if (patients == null || patients.Count == 0)
            return "No patient data available.";

        return $"You currently have {patients.Count} patients across multiple wards. " +
               $"{patients.Count(p => p.Status == PatientStatus.Critical)} patients are in critical status, " +
               $"{patients.Count(p => p.Status == PatientStatus.Monitoring)} are being monitored, and " +
               $"{patients.Count(p => p.Status == PatientStatus.Stable)} are stable. " +
               $"Key focus areas: Cardiology ({patients.Count(p => p.Ward == "Cardiology")} patients) " +
               $"and Neurology ({patients.Count(p => p.Ward == "Neurology")} patients).";
    }

    private static string BuildHighRiskResponse(List<PatientModel>? patients)
    {
        if (patients == null) return "No patient data available.";

        var critical = patients.Where(p => p.Status == PatientStatus.Critical).ToList();
        if (!critical.Any()) return "No patients currently in critical status. All patients are stable or being monitored.";

        var lines = critical.Select(p =>
            $"\u2022 {p.Name} ({p.Age}{(p.Gender == "Male" ? "M" : "F")}, {p.Ward}) \u2014 {p.Diagnosis}. " +
            (p.BpSystolic > 140 ? $"BP {p.BpSystolic}/{p.BpDiastolic} (elevated). " : "") +
            (p.HeartRate > 100 ? $"HR {p.HeartRate} bpm (tachycardia). " : "") +
            (p.O2Saturation < 95 ? $"SpO\u2082 {p.O2Saturation}% (low). " : "")
        );

        return $"Based on current vitals and status, {critical.Count} patient(s) show elevated risk levels:\n\n" +
               string.Join("\n", lines) +
               "\n\nRecommend frequent monitoring and immediate clinical review.";
    }
}
