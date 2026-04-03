using BlazorHealthcareApp.Models;

namespace BlazorHealthcareApp.Services;

public class PatientService
{
    // ========== IMAGE MAP (keyed by first name) ==========
    private static readonly Dictionary<string, string> FirstNameImageMap = new(StringComparer.OrdinalIgnoreCase)
    {
        // Males
        { "James",     "images/james-wilson.jpg" },
        { "Daniel",    "images/albert-dera.jpg" },
        { "Michael",   "images/charlie-green.jpg" },
        { "Alexander", "images/chuko-cribb.jpg" },
        { "Benjamin",  "images/derick-mckinney.jpg" },
        { "Lucas",     "images/duman-photography.jpg" },
        { "Ethan",     "images/gabriel-silverio.jpg" },
        { "William",   "images/ian-dooley.jpg" },
        { "Jack",      "images/jeffery-erhunse.jpg" },
        { "Henry",     "images/jimmy-fermin.jpg" },
        { "Samuel",    "images/raamin-ka.jpg" },
        { "Nathan",    "images/vince-fleming.jpg" },
        { "Ryan",      "images/vladislav-nikonov.jpg" },
        { "Dylan",     "images/albert-dera.jpg" },
        { "Oscar",     "images/charlie-green.jpg" },
        // Females
        { "Sophia",    "images/sophia-martinez.jpg" },
        { "Ava",       "images/brooke-cagle.jpg" },
        { "Emily",     "images/jake-nackos.jpg" },
        { "Isabella",  "images/jonathan-borba.jpg" },
        { "Olivia",    "images/leilani-angel.jpg" },
        { "Mia",       "images/prince-akachi.jpg" },
        { "Charlotte", "images/rafaella-mendes.jpg" },
        { "Amelia",    "images/vicky-hladynets.jpg" },
        { "Grace",     "images/aiony-haust.jpg" },
        { "Lily",      "images/brooke-cagle.jpg" },
        { "Chloe",     "images/jake-nackos.jpg" },
        { "Zoe",       "images/jonathan-borba.jpg" },
        { "Hannah",    "images/leilani-angel.jpg" },
        { "Victoria",  "images/prince-akachi.jpg" },
        { "Ella",      "images/rafaella-mendes.jpg" },
    };

    public string GetImageUrl(string fullName)
    {
        var firstName = fullName.Split(' ')[0];
        return FirstNameImageMap.TryGetValue(firstName, out var url) ? url : "";
    }

    public List<PatientModel> GetPatients()
    {
        return new List<PatientModel>
        {
            new() { Id = 1, Name = "James Wilson", Initials = "JW", Age = 44, Status = "Monitoring", Gender = "Male", BloodType = "A+", Ward = "General", Diagnosis = "Persistent cough",
                ImageUrl = GetImageUrl("James Wilson"),
                HeartRate = 76, BpSystolic = 128, BpDiastolic = 82, Temperature = 98.8m, O2Saturation = 97,
                Allergies = new() { "Penicillin" },
                LabResults = new() { new() { Test = "WBC", Value = "11.2 K/uL", RefRange = "4.5-11.0", IsNormal = false }, new() { Test = "CRP", Value = "2.4 mg/L", RefRange = "0-10", IsNormal = true }, new() { Test = "Glucose", Value = "98 mg/dL", RefRange = "70-100", IsNormal = true } },
                Medications = new() { new() { Name = "Dextromethorphan", Dosage = "30mg twice daily" }, new() { Name = "Guaifenesin", Dosage = "400mg every 4h" } },
                RecentVisits = new() { new() { Date = "Mar 28", Reason = "Lab work — CBC, CMP", Doctor = "Dr. Carter" }, new() { Date = "Mar 20", Reason = "Initial visit — cough evaluation", Doctor = "Dr. Carter" } }
            },
            new() { Id = 2, Name = "Sophia Martinez", Initials = "SM", Age = 31, Status = "Stable", Gender = "Female", BloodType = "O+", Ward = "Neurology", Diagnosis = "Migraines",
                ImageUrl = GetImageUrl("Sophia Martinez"),
                HeartRate = 72, BpSystolic = 118, BpDiastolic = 76, Temperature = 98.4m, O2Saturation = 99,
                Allergies = new(),
                LabResults = new() { new() { Test = "CBC", Value = "Normal", RefRange = "—", IsNormal = true }, new() { Test = "TSH", Value = "2.1 mIU/L", RefRange = "0.4-4.0", IsNormal = true } },
                Medications = new() { new() { Name = "Sumatriptan", Dosage = "50mg as needed" }, new() { Name = "Topiramate", Dosage = "25mg daily" } },
                RecentVisits = new() { new() { Date = "Mar 26", Reason = "Migraine review", Doctor = "Dr. Patel" }, new() { Date = "Mar 10", Reason = "Neurology consult", Doctor = "Dr. Patel" } }
            },
            new() { Id = 3, Name = "Daniel Thompson", Initials = "DT", Age = 58, Status = "Critical", Gender = "Male", BloodType = "B+", Ward = "Cardiology", Diagnosis = "Acute MI",
                ImageUrl = GetImageUrl("Daniel Thompson"),
                HeartRate = 108, BpSystolic = 152, BpDiastolic = 94, Temperature = 99.2m, O2Saturation = 92,
                Allergies = new() { "Aspirin", "Iodine" },
                LabResults = new() { new() { Test = "Troponin", Value = "2.8 ng/mL", RefRange = "0-0.04", IsNormal = false }, new() { Test = "BNP", Value = "890 pg/mL", RefRange = "0-100", IsNormal = false }, new() { Test = "D-Dimer", Value = "0.8 ug/mL", RefRange = "0-0.5", IsNormal = false } },
                Medications = new() { new() { Name = "Heparin", Dosage = "IV drip per protocol" }, new() { Name = "Metoprolol", Dosage = "25mg twice daily" }, new() { Name = "Atorvastatin", Dosage = "80mg daily" } },
                RecentVisits = new() { new() { Date = "Mar 29", Reason = "Emergency admission — chest pain", Doctor = "Dr. Reeves" }, new() { Date = "Feb 15", Reason = "Cardiology follow-up", Doctor = "Dr. Reeves" } }
            },
            new() { Id = 4, Name = "Ava Patel", Initials = "AP", Age = 27, Status = "Stable", Gender = "Female", BloodType = "AB+", Ward = "General", Diagnosis = "Allergic dermatitis",
                ImageUrl = GetImageUrl("Ava Patel"),
                HeartRate = 68, BpSystolic = 112, BpDiastolic = 72, Temperature = 98.2m, O2Saturation = 99,
                Allergies = new() { "Shellfish", "Latex" },
                LabResults = new() { new() { Test = "IgE", Value = "245 IU/mL", RefRange = "0-100", IsNormal = false }, new() { Test = "Eosinophils", Value = "8%", RefRange = "1-4", IsNormal = false } },
                Medications = new() { new() { Name = "Cetirizine", Dosage = "10mg daily" }, new() { Name = "Hydrocortisone cream", Dosage = "1% topical" } },
                RecentVisits = new() { new() { Date = "Mar 27", Reason = "Skin rash follow-up", Doctor = "Dr. Carter" }, new() { Date = "Mar 18", Reason = "Allergy testing", Doctor = "Dr. Brooks" } }
            },
            new() { Id = 5, Name = "Michael O'Connor", Initials = "MO", Age = 62, Status = "Monitoring", Gender = "Male", BloodType = "O-", Ward = "Cardiology", Diagnosis = "Hypertension",
                ImageUrl = GetImageUrl("Michael O'Connor"),
                HeartRate = 82, BpSystolic = 148, BpDiastolic = 92, Temperature = 98.6m, O2Saturation = 96,
                Allergies = new() { "Sulfa drugs" },
                LabResults = new() { new() { Test = "Creatinine", Value = "1.4 mg/dL", RefRange = "0.7-1.3", IsNormal = false }, new() { Test = "Potassium", Value = "4.2 mEq/L", RefRange = "3.5-5.0", IsNormal = true }, new() { Test = "Cholesterol", Value = "242 mg/dL", RefRange = "0-200", IsNormal = false } },
                Medications = new() { new() { Name = "Lisinopril", Dosage = "20mg daily" }, new() { Name = "Amlodipine", Dosage = "5mg daily" } },
                RecentVisits = new() { new() { Date = "Mar 25", Reason = "BP monitoring", Doctor = "Dr. Carter" }, new() { Date = "Mar 12", Reason = "Medication adjustment", Doctor = "Dr. Carter" } }
            },
            new() { Id = 6, Name = "Emily Chen", Initials = "EC", Age = 35, Status = "Monitoring", Gender = "Female", BloodType = "A-", Ward = "General", Diagnosis = "Chronic fatigue",
                ImageUrl = GetImageUrl("Emily Chen"),
                HeartRate = 88, BpSystolic = 110, BpDiastolic = 70, Temperature = 98.0m, O2Saturation = 98,
                Allergies = new(),
                LabResults = new() { new() { Test = "TSH", Value = "6.2 mIU/L", RefRange = "0.4-4.0", IsNormal = false }, new() { Test = "Ferritin", Value = "12 ng/mL", RefRange = "20-200", IsNormal = false }, new() { Test = "Vitamin D", Value = "18 ng/mL", RefRange = "30-100", IsNormal = false } },
                Medications = new() { new() { Name = "Levothyroxine", Dosage = "50mcg daily" }, new() { Name = "Ferrous sulfate", Dosage = "325mg daily" } },
                RecentVisits = new() { new() { Date = "Mar 24", Reason = "Fatigue follow-up", Doctor = "Dr. Carter" }, new() { Date = "Mar 8", Reason = "Initial evaluation", Doctor = "Dr. Carter" } }
            },
            new() { Id = 7, Name = "Alexander Novak", Initials = "AN", Age = 52, Status = "Stable", Gender = "Male", BloodType = "B-", Ward = "Pulmonology", Diagnosis = "COPD",
                ImageUrl = GetImageUrl("Alexander Novak"),
                HeartRate = 78, BpSystolic = 124, BpDiastolic = 80, Temperature = 98.4m, O2Saturation = 94,
                Allergies = new() { "Codeine" },
                LabResults = new() { new() { Test = "FEV1", Value = "62%", RefRange = ">80%", IsNormal = false }, new() { Test = "ABG pH", Value = "7.38", RefRange = "7.35-7.45", IsNormal = true } },
                Medications = new() { new() { Name = "Tiotropium", Dosage = "18mcg inhaled daily" }, new() { Name = "Albuterol", Dosage = "PRN inhaler" } },
                RecentVisits = new() { new() { Date = "Mar 22", Reason = "Pulmonary function test", Doctor = "Dr. Hernandez" }, new() { Date = "Mar 5", Reason = "COPD management review", Doctor = "Dr. Hernandez" } }
            },
            new() { Id = 8, Name = "Isabella Rossi", Initials = "IR", Age = 40, Status = "Stable", Gender = "Female", BloodType = "O+", Ward = "General", Diagnosis = "Annual physical",
                ImageUrl = GetImageUrl("Isabella Rossi"),
                HeartRate = 70, BpSystolic = 116, BpDiastolic = 74, Temperature = 98.6m, O2Saturation = 99,
                Allergies = new(),
                LabResults = new() { new() { Test = "CBC", Value = "Normal", RefRange = "—", IsNormal = true }, new() { Test = "Lipid Panel", Value = "Normal", RefRange = "—", IsNormal = true } },
                Medications = new() { new() { Name = "Multivitamin", Dosage = "1 tablet daily" } },
                RecentVisits = new() { new() { Date = "Mar 29", Reason = "Annual physical exam", Doctor = "Dr. Carter" } }
            },
            new() { Id = 9, Name = "Benjamin Carter", Initials = "BC", Age = 47, Status = "Monitoring", Gender = "Male", BloodType = "A+", Ward = "Gastroenterology", Diagnosis = "GERD",
                ImageUrl = GetImageUrl("Benjamin Carter"),
                HeartRate = 74, BpSystolic = 126, BpDiastolic = 80, Temperature = 98.6m, O2Saturation = 98,
                Allergies = new() { "NSAIDs" },
                LabResults = new() { new() { Test = "H. Pylori", Value = "Negative", RefRange = "Negative", IsNormal = true }, new() { Test = "Lipase", Value = "42 U/L", RefRange = "0-60", IsNormal = true } },
                Medications = new() { new() { Name = "Omeprazole", Dosage = "20mg daily" }, new() { Name = "Famotidine", Dosage = "20mg as needed" } },
                RecentVisits = new() { new() { Date = "Mar 23", Reason = "GERD follow-up", Doctor = "Dr. Lopez" }, new() { Date = "Mar 1", Reason = "Upper GI endoscopy", Doctor = "Dr. Lopez" } }
            },
            new() { Id = 10, Name = "Olivia Grant", Initials = "OG", Age = 29, Status = "Stable", Gender = "Female", BloodType = "B+", Ward = "Orthopedics", Diagnosis = "ACL tear",
                ImageUrl = GetImageUrl("Olivia Grant"),
                HeartRate = 66, BpSystolic = 114, BpDiastolic = 72, Temperature = 98.2m, O2Saturation = 99,
                Allergies = new(),
                LabResults = new() { new() { Test = "CRP", Value = "1.2 mg/L", RefRange = "0-10", IsNormal = true }, new() { Test = "CBC", Value = "Normal", RefRange = "—", IsNormal = true } },
                Medications = new() { new() { Name = "Ibuprofen", Dosage = "400mg every 6h" }, new() { Name = "Acetaminophen", Dosage = "500mg as needed" } },
                RecentVisits = new() { new() { Date = "Mar 28", Reason = "Pre-op assessment", Doctor = "Dr. Kim" }, new() { Date = "Mar 15", Reason = "MRI review — ACL tear confirmed", Doctor = "Dr. Kim" } }
            },
            new() { Id = 11, Name = "Lucas Rivera", Initials = "LR", Age = 71, Status = "Critical", Gender = "Male", BloodType = "AB-", Ward = "ICU", Diagnosis = "Sepsis",
                ImageUrl = GetImageUrl("Lucas Rivera"),
                HeartRate = 112, BpSystolic = 88, BpDiastolic = 56, Temperature = 101.8m, O2Saturation = 89,
                Allergies = new() { "Vancomycin" },
                LabResults = new() { new() { Test = "Lactate", Value = "4.2 mmol/L", RefRange = "0.5-2.0", IsNormal = false }, new() { Test = "WBC", Value = "18.6 K/uL", RefRange = "4.5-11.0", IsNormal = false }, new() { Test = "Procalcitonin", Value = "8.4 ng/mL", RefRange = "0-0.5", IsNormal = false } },
                Medications = new() { new() { Name = "Meropenem", Dosage = "1g IV every 8h" }, new() { Name = "Norepinephrine", Dosage = "IV drip per protocol" }, new() { Name = "Normal Saline", Dosage = "IV fluid resuscitation" } },
                RecentVisits = new() { new() { Date = "Mar 29", Reason = "ICU admission — septic shock", Doctor = "Dr. Reeves" } }
            },
            new() { Id = 12, Name = "Mia Johansson", Initials = "MJ", Age = 24, Status = "Stable", Gender = "Female", BloodType = "O+", Ward = "General", Diagnosis = "Tonsillitis",
                ImageUrl = GetImageUrl("Mia Johansson"),
                HeartRate = 80, BpSystolic = 110, BpDiastolic = 68, Temperature = 100.2m, O2Saturation = 98,
                Allergies = new(),
                LabResults = new() { new() { Test = "Rapid Strep", Value = "Positive", RefRange = "Negative", IsNormal = false }, new() { Test = "WBC", Value = "12.1 K/uL", RefRange = "4.5-11.0", IsNormal = false } },
                Medications = new() { new() { Name = "Amoxicillin", Dosage = "500mg three times daily" }, new() { Name = "Ibuprofen", Dosage = "400mg every 6h" } },
                RecentVisits = new() { new() { Date = "Mar 28", Reason = "Sore throat evaluation", Doctor = "Dr. Carter" } }
            },
            new() { Id = 13, Name = "Ethan Brooks", Initials = "EB", Age = 56, Status = "Monitoring", Gender = "Male", BloodType = "A+", Ward = "Cardiology", Diagnosis = "Atrial fibrillation",
                ImageUrl = GetImageUrl("Ethan Brooks"),
                HeartRate = 96, BpSystolic = 136, BpDiastolic = 86, Temperature = 98.4m, O2Saturation = 96,
                Allergies = new() { "Amiodarone" },
                LabResults = new() { new() { Test = "INR", Value = "2.8", RefRange = "2.0-3.0", IsNormal = true }, new() { Test = "TSH", Value = "1.8 mIU/L", RefRange = "0.4-4.0", IsNormal = true } },
                Medications = new() { new() { Name = "Warfarin", Dosage = "5mg daily" }, new() { Name = "Diltiazem", Dosage = "120mg daily" } },
                RecentVisits = new() { new() { Date = "Mar 26", Reason = "INR check", Doctor = "Dr. Reeves" }, new() { Date = "Mar 14", Reason = "ECG monitoring", Doctor = "Dr. Reeves" } }
            },
            new() { Id = 14, Name = "Charlotte Adams", Initials = "CA", Age = 38, Status = "Stable", Gender = "Female", BloodType = "B+", Ward = "General", Diagnosis = "Iron deficiency anemia",
                ImageUrl = GetImageUrl("Charlotte Adams"),
                HeartRate = 84, BpSystolic = 108, BpDiastolic = 68, Temperature = 98.0m, O2Saturation = 98,
                Allergies = new(),
                LabResults = new() { new() { Test = "Hemoglobin", Value = "10.2 g/dL", RefRange = "12-16", IsNormal = false }, new() { Test = "Ferritin", Value = "8 ng/mL", RefRange = "20-200", IsNormal = false }, new() { Test = "Iron", Value = "35 ug/dL", RefRange = "60-170", IsNormal = false } },
                Medications = new() { new() { Name = "Ferrous sulfate", Dosage = "325mg twice daily" }, new() { Name = "Vitamin C", Dosage = "500mg daily" } },
                RecentVisits = new() { new() { Date = "Mar 25", Reason = "Anemia follow-up", Doctor = "Dr. Carter" }, new() { Date = "Mar 10", Reason = "Initial blood work review", Doctor = "Dr. Carter" } }
            },
            new() { Id = 15, Name = "William Tanaka", Initials = "WT", Age = 65, Status = "Monitoring", Gender = "Male", BloodType = "O-", Ward = "Endocrinology", Diagnosis = "Type 2 Diabetes",
                ImageUrl = GetImageUrl("William Tanaka"),
                HeartRate = 78, BpSystolic = 142, BpDiastolic = 88, Temperature = 98.6m, O2Saturation = 97,
                Allergies = new() { "Metformin" },
                LabResults = new() { new() { Test = "HbA1c", Value = "8.2%", RefRange = "4-5.6", IsNormal = false }, new() { Test = "Fasting Glucose", Value = "186 mg/dL", RefRange = "70-100", IsNormal = false }, new() { Test = "Creatinine", Value = "1.1 mg/dL", RefRange = "0.7-1.3", IsNormal = true } },
                Medications = new() { new() { Name = "Glipizide", Dosage = "10mg twice daily" }, new() { Name = "Insulin Glargine", Dosage = "20 units at bedtime" } },
                RecentVisits = new() { new() { Date = "Mar 24", Reason = "Diabetes management review", Doctor = "Dr. Nguyen" }, new() { Date = "Mar 3", Reason = "HbA1c lab draw", Doctor = "Dr. Nguyen" } }
            },
            new() { Id = 16, Name = "Amelia Foster", Initials = "AF", Age = 33, Status = "Stable", Gender = "Female", BloodType = "AB+", Ward = "Dermatology", Diagnosis = "Psoriasis",
                ImageUrl = GetImageUrl("Amelia Foster"),
                HeartRate = 70, BpSystolic = 112, BpDiastolic = 74, Temperature = 98.4m, O2Saturation = 99,
                Allergies = new(),
                LabResults = new() { new() { Test = "ESR", Value = "22 mm/hr", RefRange = "0-20", IsNormal = false }, new() { Test = "CRP", Value = "3.1 mg/L", RefRange = "0-10", IsNormal = true } },
                Medications = new() { new() { Name = "Adalimumab", Dosage = "40mg SC biweekly" }, new() { Name = "Triamcinolone cream", Dosage = "0.1% topical" } },
                RecentVisits = new() { new() { Date = "Mar 22", Reason = "Psoriasis flare review", Doctor = "Dr. Brooks" }, new() { Date = "Feb 28", Reason = "Biologic therapy check", Doctor = "Dr. Brooks" } }
            },
            new() { Id = 17, Name = "Jack Sullivan", Initials = "JS", Age = 73, Status = "Critical", Gender = "Male", BloodType = "A-", Ward = "ICU", Diagnosis = "Pneumonia",
                ImageUrl = GetImageUrl("Jack Sullivan"),
                HeartRate = 104, BpSystolic = 96, BpDiastolic = 62, Temperature = 102.4m, O2Saturation = 88,
                Allergies = new() { "Penicillin", "Sulfa drugs" },
                LabResults = new() { new() { Test = "WBC", Value = "19.4 K/uL", RefRange = "4.5-11.0", IsNormal = false }, new() { Test = "Procalcitonin", Value = "5.2 ng/mL", RefRange = "0-0.5", IsNormal = false }, new() { Test = "PaO2", Value = "58 mmHg", RefRange = "80-100", IsNormal = false } },
                Medications = new() { new() { Name = "Levofloxacin", Dosage = "750mg IV daily" }, new() { Name = "Supplemental O2", Dosage = "4L nasal cannula" }, new() { Name = "Acetaminophen", Dosage = "650mg every 6h" } },
                RecentVisits = new() { new() { Date = "Mar 29", Reason = "ICU transfer — worsening pneumonia", Doctor = "Dr. Hernandez" }, new() { Date = "Mar 27", Reason = "Admission — community-acquired pneumonia", Doctor = "Dr. Carter" } }
            },
            new() { Id = 18, Name = "Grace Kim", Initials = "GK", Age = 42, Status = "Stable", Gender = "Female", BloodType = "O+", Ward = "General", Diagnosis = "Seasonal allergies",
                ImageUrl = GetImageUrl("Grace Kim"),
                HeartRate = 72, BpSystolic = 118, BpDiastolic = 76, Temperature = 98.6m, O2Saturation = 99,
                Allergies = new() { "Pollen", "Dust mites" },
                LabResults = new() { new() { Test = "IgE", Value = "180 IU/mL", RefRange = "0-100", IsNormal = false }, new() { Test = "CBC", Value = "Normal", RefRange = "—", IsNormal = true } },
                Medications = new() { new() { Name = "Loratadine", Dosage = "10mg daily" }, new() { Name = "Fluticasone nasal spray", Dosage = "2 sprays daily" } },
                RecentVisits = new() { new() { Date = "Mar 20", Reason = "Allergy management visit", Doctor = "Dr. Carter" } }
            },
            new() { Id = 19, Name = "Henry Wallace", Initials = "HW", Age = 80, Status = "Monitoring", Gender = "Male", BloodType = "B-", Ward = "Neurology", Diagnosis = "Parkinson's disease",
                ImageUrl = GetImageUrl("Henry Wallace"),
                HeartRate = 68, BpSystolic = 132, BpDiastolic = 78, Temperature = 97.8m, O2Saturation = 96,
                Allergies = new(),
                LabResults = new() { new() { Test = "Vitamin B12", Value = "310 pg/mL", RefRange = "200-900", IsNormal = true }, new() { Test = "Folate", Value = "8.2 ng/mL", RefRange = "2.7-17", IsNormal = true } },
                Medications = new() { new() { Name = "Carbidopa-Levodopa", Dosage = "25/100mg three times daily" }, new() { Name = "Pramipexole", Dosage = "0.5mg three times daily" } },
                RecentVisits = new() { new() { Date = "Mar 21", Reason = "Tremor assessment", Doctor = "Dr. Patel" }, new() { Date = "Feb 28", Reason = "Medication titration", Doctor = "Dr. Patel" } }
            },
            new() { Id = 20, Name = "Lily Nakamura", Initials = "LN", Age = 19, Status = "Stable", Gender = "Female", BloodType = "A+", Ward = "General", Diagnosis = "Mononucleosis",
                ImageUrl = GetImageUrl("Lily Nakamura"),
                HeartRate = 82, BpSystolic = 106, BpDiastolic = 66, Temperature = 100.6m, O2Saturation = 98,
                Allergies = new(),
                LabResults = new() { new() { Test = "Monospot", Value = "Positive", RefRange = "Negative", IsNormal = false }, new() { Test = "WBC", Value = "13.4 K/uL", RefRange = "4.5-11.0", IsNormal = false }, new() { Test = "Liver Enzymes", Value = "Mildly elevated", RefRange = "Normal", IsNormal = false } },
                Medications = new() { new() { Name = "Acetaminophen", Dosage = "500mg every 6h" } },
                RecentVisits = new() { new() { Date = "Mar 27", Reason = "Fatigue and sore throat", Doctor = "Dr. Carter" } }
            },
            new() { Id = 21, Name = "Samuel Torres", Initials = "ST", Age = 55, Status = "Stable", Gender = "Male", BloodType = "O+", Ward = "Orthopedics", Diagnosis = "Hip replacement recovery",
                ImageUrl = GetImageUrl("Samuel Torres"),
                HeartRate = 74, BpSystolic = 122, BpDiastolic = 78, Temperature = 98.4m, O2Saturation = 98,
                Allergies = new() { "Codeine" },
                LabResults = new() { new() { Test = "CBC", Value = "Normal", RefRange = "—", IsNormal = true }, new() { Test = "CRP", Value = "5.8 mg/L", RefRange = "0-10", IsNormal = true } },
                Medications = new() { new() { Name = "Enoxaparin", Dosage = "40mg SC daily" }, new() { Name = "Tramadol", Dosage = "50mg every 6h" } },
                RecentVisits = new() { new() { Date = "Mar 26", Reason = "Post-op day 3 — hip replacement", Doctor = "Dr. Kim" }, new() { Date = "Mar 23", Reason = "Surgery — total hip arthroplasty", Doctor = "Dr. Kim" } }
            },
            new() { Id = 22, Name = "Chloe Anderson", Initials = "CA", Age = 48, Status = "Monitoring", Gender = "Female", BloodType = "AB+", Ward = "Oncology", Diagnosis = "Breast cancer — stage II",
                ImageUrl = GetImageUrl("Chloe Anderson"),
                HeartRate = 86, BpSystolic = 120, BpDiastolic = 76, Temperature = 98.8m, O2Saturation = 97,
                Allergies = new() { "Contrast dye" },
                LabResults = new() { new() { Test = "CA 15-3", Value = "38 U/mL", RefRange = "0-30", IsNormal = false }, new() { Test = "WBC", Value = "3.8 K/uL", RefRange = "4.5-11.0", IsNormal = false }, new() { Test = "Hemoglobin", Value = "11.4 g/dL", RefRange = "12-16", IsNormal = false } },
                Medications = new() { new() { Name = "Tamoxifen", Dosage = "20mg daily" }, new() { Name = "Ondansetron", Dosage = "8mg as needed" } },
                RecentVisits = new() { new() { Date = "Mar 25", Reason = "Chemotherapy cycle 3", Doctor = "Dr. Liu" }, new() { Date = "Mar 11", Reason = "Chemotherapy cycle 2", Doctor = "Dr. Liu" } }
            },
            new() { Id = 23, Name = "Nathan Perry", Initials = "NP", Age = 36, Status = "Stable", Gender = "Male", BloodType = "B+", Ward = "General", Diagnosis = "Lower back pain",
                ImageUrl = GetImageUrl("Nathan Perry"),
                HeartRate = 72, BpSystolic = 120, BpDiastolic = 78, Temperature = 98.6m, O2Saturation = 99,
                Allergies = new(),
                LabResults = new() { new() { Test = "ESR", Value = "14 mm/hr", RefRange = "0-20", IsNormal = true }, new() { Test = "CBC", Value = "Normal", RefRange = "—", IsNormal = true } },
                Medications = new() { new() { Name = "Naproxen", Dosage = "500mg twice daily" }, new() { Name = "Cyclobenzaprine", Dosage = "10mg at bedtime" } },
                RecentVisits = new() { new() { Date = "Mar 24", Reason = "Back pain evaluation", Doctor = "Dr. Carter" } }
            },
            new() { Id = 24, Name = "Zoe Mitchell", Initials = "ZM", Age = 83, Status = "Monitoring", Gender = "Female", BloodType = "O-", Ward = "Cardiology", Diagnosis = "Congestive heart failure",
                ImageUrl = GetImageUrl("Zoe Mitchell"),
                HeartRate = 92, BpSystolic = 138, BpDiastolic = 84, Temperature = 98.2m, O2Saturation = 93,
                Allergies = new() { "ACE inhibitors" },
                LabResults = new() { new() { Test = "BNP", Value = "620 pg/mL", RefRange = "0-100", IsNormal = false }, new() { Test = "Creatinine", Value = "1.6 mg/dL", RefRange = "0.7-1.3", IsNormal = false }, new() { Test = "Sodium", Value = "132 mEq/L", RefRange = "136-145", IsNormal = false } },
                Medications = new() { new() { Name = "Furosemide", Dosage = "40mg daily" }, new() { Name = "Carvedilol", Dosage = "12.5mg twice daily" }, new() { Name = "Spironolactone", Dosage = "25mg daily" } },
                RecentVisits = new() { new() { Date = "Mar 26", Reason = "CHF exacerbation", Doctor = "Dr. Reeves" }, new() { Date = "Mar 10", Reason = "Cardiology follow-up", Doctor = "Dr. Reeves" } }
            },
            new() { Id = 25, Name = "Ryan Cooper", Initials = "RC", Age = 45, Status = "Stable", Gender = "Male", BloodType = "A+", Ward = "General", Diagnosis = "Anxiety disorder",
                ImageUrl = GetImageUrl("Ryan Cooper"),
                HeartRate = 88, BpSystolic = 124, BpDiastolic = 80, Temperature = 98.6m, O2Saturation = 99,
                Allergies = new(),
                LabResults = new() { new() { Test = "TSH", Value = "2.4 mIU/L", RefRange = "0.4-4.0", IsNormal = true }, new() { Test = "CBC", Value = "Normal", RefRange = "—", IsNormal = true } },
                Medications = new() { new() { Name = "Sertraline", Dosage = "100mg daily" }, new() { Name = "Lorazepam", Dosage = "0.5mg as needed" } },
                RecentVisits = new() { new() { Date = "Mar 22", Reason = "Medication review", Doctor = "Dr. Carter" }, new() { Date = "Feb 20", Reason = "Anxiety management", Doctor = "Dr. Carter" } }
            },
            new() { Id = 26, Name = "Hannah Moore", Initials = "HM", Age = 60, Status = "Stable", Gender = "Female", BloodType = "B-", Ward = "Rheumatology", Diagnosis = "Rheumatoid arthritis",
                ImageUrl = GetImageUrl("Hannah Moore"),
                HeartRate = 74, BpSystolic = 126, BpDiastolic = 80, Temperature = 98.4m, O2Saturation = 98,
                Allergies = new() { "Sulfasalazine" },
                LabResults = new() { new() { Test = "RF", Value = "64 IU/mL", RefRange = "0-14", IsNormal = false }, new() { Test = "Anti-CCP", Value = "82 U/mL", RefRange = "0-20", IsNormal = false }, new() { Test = "ESR", Value = "38 mm/hr", RefRange = "0-20", IsNormal = false } },
                Medications = new() { new() { Name = "Methotrexate", Dosage = "15mg weekly" }, new() { Name = "Folic acid", Dosage = "1mg daily" }, new() { Name = "Prednisone", Dosage = "5mg daily" } },
                RecentVisits = new() { new() { Date = "Mar 20", Reason = "RA flare assessment", Doctor = "Dr. Singh" }, new() { Date = "Feb 18", Reason = "Lab monitoring", Doctor = "Dr. Singh" } }
            },
            new() { Id = 27, Name = "Dylan Murphy", Initials = "DM", Age = 22, Status = "Stable", Gender = "Male", BloodType = "O+", Ward = "Orthopedics", Diagnosis = "Fractured wrist",
                ImageUrl = GetImageUrl("Dylan Murphy"),
                HeartRate = 68, BpSystolic = 118, BpDiastolic = 72, Temperature = 98.6m, O2Saturation = 99,
                Allergies = new(),
                LabResults = new() { new() { Test = "CBC", Value = "Normal", RefRange = "—", IsNormal = true } },
                Medications = new() { new() { Name = "Acetaminophen", Dosage = "500mg every 6h" } },
                RecentVisits = new() { new() { Date = "Mar 28", Reason = "Cast application — distal radius fracture", Doctor = "Dr. Kim" } }
            },
            new() { Id = 28, Name = "Victoria Hughes", Initials = "VH", Age = 50, Status = "Monitoring", Gender = "Female", BloodType = "A-", Ward = "Nephrology", Diagnosis = "Chronic kidney disease",
                ImageUrl = GetImageUrl("Victoria Hughes"),
                HeartRate = 80, BpSystolic = 146, BpDiastolic = 90, Temperature = 98.4m, O2Saturation = 97,
                Allergies = new() { "NSAIDs" },
                LabResults = new() { new() { Test = "GFR", Value = "42 mL/min", RefRange = ">60", IsNormal = false }, new() { Test = "Creatinine", Value = "2.1 mg/dL", RefRange = "0.7-1.3", IsNormal = false }, new() { Test = "Potassium", Value = "5.4 mEq/L", RefRange = "3.5-5.0", IsNormal = false } },
                Medications = new() { new() { Name = "Losartan", Dosage = "50mg daily" }, new() { Name = "Sodium bicarbonate", Dosage = "650mg twice daily" }, new() { Name = "Epoetin alfa", Dosage = "4000 units SC weekly" } },
                RecentVisits = new() { new() { Date = "Mar 24", Reason = "CKD stage 3b review", Doctor = "Dr. Nguyen" }, new() { Date = "Mar 5", Reason = "Lab monitoring", Doctor = "Dr. Nguyen" } }
            },
            new() { Id = 29, Name = "Oscar Fernandez", Initials = "OF", Age = 68, Status = "Stable", Gender = "Male", BloodType = "AB+", Ward = "General", Diagnosis = "Osteoarthritis",
                ImageUrl = GetImageUrl("Oscar Fernandez"),
                HeartRate = 70, BpSystolic = 130, BpDiastolic = 82, Temperature = 98.2m, O2Saturation = 98,
                Allergies = new(),
                LabResults = new() { new() { Test = "Uric Acid", Value = "6.2 mg/dL", RefRange = "3.4-7.0", IsNormal = true }, new() { Test = "CBC", Value = "Normal", RefRange = "—", IsNormal = true } },
                Medications = new() { new() { Name = "Celecoxib", Dosage = "200mg daily" }, new() { Name = "Glucosamine", Dosage = "1500mg daily" } },
                RecentVisits = new() { new() { Date = "Mar 22", Reason = "Joint pain follow-up", Doctor = "Dr. Carter" }, new() { Date = "Feb 15", Reason = "Knee X-ray review", Doctor = "Dr. Kim" } }
            },
            new() { Id = 30, Name = "Ella Patterson", Initials = "EP", Age = 26, Status = "Stable", Gender = "Female", BloodType = "O+", Ward = "General", Diagnosis = "Urinary tract infection",
                ImageUrl = GetImageUrl("Ella Patterson"),
                HeartRate = 76, BpSystolic = 110, BpDiastolic = 70, Temperature = 99.8m, O2Saturation = 99,
                Allergies = new() { "Trimethoprim" },
                LabResults = new() { new() { Test = "Urinalysis", Value = "WBC +++", RefRange = "Negative", IsNormal = false }, new() { Test = "Urine Culture", Value = "E. coli", RefRange = "No growth", IsNormal = false } },
                Medications = new() { new() { Name = "Nitrofurantoin", Dosage = "100mg twice daily" }, new() { Name = "Phenazopyridine", Dosage = "200mg three times daily" } },
                RecentVisits = new() { new() { Date = "Mar 28", Reason = "UTI symptoms — dysuria, frequency", Doctor = "Dr. Carter" } }
            },
        };
    }

    public PatientDetailModel? GetPatientDetail(int id)
    {
        var nurses = new[] { "Olivia Parker", "Sarah Jones", "Mike Chen", "Lisa Rodriguez", "Emma White" };
        var departments = new Dictionary<string, string>
        {
            { "General", "Internal Medicine" }, { "Cardiology", "Cardiology" }, { "Neurology", "Neurology" },
            { "Pulmonology", "Pulmonology" }, { "Orthopedics", "Orthopedics" }, { "ICU", "Critical Care" },
            { "Gastroenterology", "Gastroenterology" }, { "Endocrinology", "Endocrinology" },
            { "Dermatology", "Dermatology" }, { "Oncology", "Oncology" }, { "Rheumatology", "Rheumatology" },
            { "Nephrology", "Nephrology" }
        };

        var patient = GetPatients().FirstOrDefault(p => p.Id == id);
        if (patient is null) return null;

        var rng = new Random(id * 7);
        var rooms = new[] { "101", "204", "304", "456", "79A", "312", "508" };
        var dept = departments.GetValueOrDefault(patient.Ward, patient.Ward);

        return new PatientDetailModel
        {
            Id = patient.Id,
            Name = patient.Name,
            Initials = patient.Initials,
            ImageUrl = patient.ImageUrl,
            Age = patient.Age,
            Status = patient.Status,
            Gender = patient.Gender,
            BloodType = patient.BloodType,
            Ward = patient.Ward + " Unit B",
            Diagnosis = patient.Diagnosis,
            HeartRate = patient.HeartRate,
            BpSystolic = patient.BpSystolic,
            BpDiastolic = patient.BpDiastolic,
            Temperature = patient.Temperature,
            O2Saturation = patient.O2Saturation,
            RespiratoryRate = 14 + rng.Next(0, 6),
            Department = dept,
            Room = rooms[rng.Next(rooms.Length)],
            AdmissionDate = "Mar " + (5 + rng.Next(0, 24)) + ", 2026",
            AssignedNurse = nurses[rng.Next(nurses.Length)],
            Allergies = patient.Allergies,
            LabResults = patient.LabResults,
            Medications = patient.Medications,
            RecentVisits = patient.RecentVisits,
        };
    }
}
