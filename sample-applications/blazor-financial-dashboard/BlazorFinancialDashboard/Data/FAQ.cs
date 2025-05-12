using System;

namespace BlazorFinancialDashboard.Data;

public class FAQ
{
    public string Question { get; set; }
    public string Answer { get; set; }

    public FAQ(string question, string answer)
    {
        Question = question;
        Answer = answer;
    }
}
