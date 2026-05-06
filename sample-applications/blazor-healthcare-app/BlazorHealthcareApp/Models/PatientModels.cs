namespace BlazorHealthcareApp.Models;

public class PatientModel
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Initials { get; set; } = "";
    public string ImageUrl { get; set; } = "";
    public int Age { get; set; }
    public PatientStatus Status { get; set; }
    public string StatusText => Status.ToString();
    public string Gender { get; set; } = "";
    public string BloodType { get; set; } = "";
    public string Ward { get; set; } = "";
    public string Diagnosis { get; set; } = "";

    // Vitals
    public int HeartRate { get; set; }
    public int BpSystolic { get; set; }
    public int BpDiastolic { get; set; }
    public decimal Temperature { get; set; }
    public int O2Saturation { get; set; }

    // Detail
    public List<string> Allergies { get; set; } = new();
    public List<LabResult> LabResults { get; set; } = new();
    public List<Medication> Medications { get; set; } = new();
    public List<Visit> RecentVisits { get; set; } = new();
}

public class PatientDetailModel : PatientModel
{
    public int RespiratoryRate { get; set; }

    // Admission
    public string Department { get; set; } = "";
    public string Room { get; set; } = "";
    public DateTime AdmissionDate { get; set; }
    public string AssignedNurse { get; set; } = "";
}

public class LabResult
{
    public string Test { get; set; } = "";
    public string Value { get; set; } = "";
    public string RefRange { get; set; } = "";
    public bool IsNormal { get; set; }
}

public class LabResultRow
{
    public string Test { get; set; } = "";
    public string Result { get; set; } = "";
    public string Reference { get; set; } = "";
    public PatientStatus Status { get; set; }
    public string Note { get; set; } = "";
}

public class Medication
{
    public string Name { get; set; } = "";
    public string Dosage { get; set; } = "";
}

public class Visit
{
    public DateTime Date { get; set; }
    public string Reason { get; set; } = "";
    public string Doctor { get; set; } = "";
}
