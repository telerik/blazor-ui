namespace BlazorHealthcareApp.Services;

public class StaffService
{
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
        "oliviaparker@email.com"  => ("Patient Update – James Wilson",           "Hi Olivia,\n\nPlease prepare Room 456 for James Wilson's 11:00 AM appointment. He has a Penicillin allergy – ensure the chart is flagged.\n\nThank you."),
        "sarah.jones@email.com"   => ("Lab Results Follow-Up – Sophia Martinez", "Hi Sarah,\n\nSophia Martinez's CRP levels came back elevated. Please schedule a follow-up blood draw for tomorrow morning and update her chart.\n\nThanks."),
        "mike.chen@email.com"     => ("Medication Review – Ava Patel",           "Hi Mike,\n\nAva Patel is currently in Room 456 with an allergic reaction. Please verify her current medications and confirm no shellfish-derived compounds are in her treatment plan.\n\nAppreciate it."),
        "lisa.rodriguez@email.com"=> ("Discharge Prep – Daniel Thompson",        "Hi Lisa,\n\nDaniel Thompson's appointment is complete. Please prepare his discharge summary and ensure the referral to physical therapy is included.\n\nThank you."),
        _                         => ("", ""),
    };
}
