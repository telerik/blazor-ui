using BlazorHealthcareApp.Models;

namespace BlazorHealthcareApp.Services;

public class HomeService
{
    public List<Appointment> GetTodaysAppointments() => new()
    {
        new() { Time = "09:00 AM", PatientName = "Daniel Thompson",  Reason = "Persistent lower back pain after lifting boxes",    Status = "Complete",    Room = "204 (Floor 2)" },
        new() { Time = "09:30 AM", PatientName = "Sophia Martinez",  Reason = "Recurring migraines with sensitivity to light",     Status = "Complete",    Room = "456 (Floor 4)" },
        new() { Time = "10:00 AM", PatientName = "Michael O'Connor", Reason = "Follow-up appointment for elevated blood pressure",  Status = "Complete",    Room = "79A (Floor 0)" },
        new() { Time = "10:30 AM", PatientName = "Ava Patel",        Reason = "Allergic reaction causing skin rash",                Status = "In Progress", Room = "456 (Floor 4)" },
        new() { Time = "11:00 AM", PatientName = "James Wilson",     Reason = "Knee pain after a basketball injury",                Status = "Upcoming",    Room = "456 (Floor 4)" },
        new() { Time = "11:30 AM", PatientName = "Emily Chen",       Reason = "Ongoing fatigue and dizziness",                     Status = "Cancelled",   Room = "456 (Floor 4)" },
        new() { Time = "12:00 PM", PatientName = "Alexander Novak",  Reason = "Persistent cough and chest congestion",             Status = "Upcoming",    Room = "204 (Floor 2)" },
        new() { Time = "12:30 PM", PatientName = "Isabella Rossi",   Reason = "Annual physical exam",                              Status = "Upcoming",    Room = "456 (Floor 4)" },
        new() { Time = "1:00 PM",  PatientName = "Benjamin Carter",  Reason = "Stomach pain and acid reflux symptoms",             Status = "Cancelled",   Room = "204 (Floor 2)" },
    };

    public List<DailyAlert> GetDailyAlerts() => new()
    {
        new() { Text = "CRP elevated \u2013 Sophia Martinez",          Timestamp = "15 min ago" },
        new() { Text = "Blood pressure high \u2013 James Carter",      Timestamp = "15 min ago" },
        new() { Text = "Glucose levels elevated \u2013 Daniel Rivera", Timestamp = "15 min ago" },
        new() { Text = "High cholesterol detected \u2013 Ava Thompson",Timestamp = "15 min ago" },
    };

    public List<string> GetPatientNames() => new()
    {
        "James Wilson (P-104582)",
        "Ava Patel (P-103201)",
        "Emily Chen (P-105887)",
        "Alexander Novak (P-102445)",
    };

    public List<string> GetLabTests() => new()
    {
        "Complete blood count (CBC)",
        "Comprehensive metabolic panel (CMP)",
        "Basic metabolic panel (BMP)",
        "Lipid panel",
        "Thyroid function test",
        "Hemoglobin A1C",
        "Urinalysis",
        "Chest X-Ray",
        "MRI",
    };

    public List<string> GetNurseRecipients() => new()
    {
        "oliviaparker@email.com",
        "sarah.jones@email.com",
        "mike.chen@email.com",
        "lisa.rodriguez@email.com",
    };

    public (string Subject, string Body) GetNurseMessageTemplate(string nurse) => nurse switch
    {
        "oliviaparker@email.com"  => ("Patient Update – James Wilson",           "Hi Olivia,\n\nPlease prepare Room 456 for James Wilson's 11:00 AM appointment. He has a Penicillin allergy — ensure the chart is flagged.\n\nThank you."),
        "sarah.jones@email.com"   => ("Lab Results Follow-Up – Sophia Martinez", "Hi Sarah,\n\nSophia Martinez's CRP levels came back elevated. Please schedule a follow-up blood draw for tomorrow morning and update her chart.\n\nThanks."),
        "mike.chen@email.com"     => ("Medication Review – Ava Patel",           "Hi Mike,\n\nAva Patel is currently in Room 456 with an allergic reaction. Please verify her current medications and confirm no shellfish-derived compounds are in her treatment plan.\n\nAppreciate it."),
        "lisa.rodriguez@email.com"=> ("Discharge Prep – Daniel Thompson",        "Hi Lisa,\n\nDaniel Thompson's appointment is complete. Please prepare his discharge summary and ensure the referral to physical therapy is included.\n\nThank you."),
        _                         => ("", ""),
    };
}
