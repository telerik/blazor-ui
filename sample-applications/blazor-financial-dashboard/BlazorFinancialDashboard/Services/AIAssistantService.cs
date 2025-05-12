using BlazorFinancialDashboard.Data;

namespace BlazorFinancialDashboard.Services;

public class AIAssistantService
{
    private List<FAQ> Data { get; set; } =
    [
        new FAQ("How do I start saving money?", "Begin by setting a clear savings goal and tracking your expenses. Use the app to create a budget, automate transfers to a savings account, and cut unnecessary spending. Even small, consistent deposits can add up over time!"),
        new FAQ("What’s the best way to start investing with little money?", "Start with low-cost options like ETFs or fractional shares. Many apps allow you to invest with as little as $5. Consider automating small, regular contributions to grow your portfolio over time!"),
        new FAQ("How can I save money without changing my lifestyle?", "Saving money without changing your lifestyle is all about optimizing what you're already doing. Set up an automatic transfer from your checking to your savings account right after each paycheck. Use credit cards with cashback or rewards on purchases you already make. Audit your streaming, app, and service subscriptions. Cancel unused ones or switch to shared family plans. Move your savings to a high-yield online savings account to earn more interest passively."),
        new FAQ("What is the best way to build an emergency fund?", "The best way to build an emergency fund is to treat it like a non-negotiable monthly bill and grow it steadily with a clear goal in mind. Target 3 to 6 months of essential living expenses (housing, food, transportation, insurance, and minimum debt payments).")
    ];

    public async Task<List<FAQ>> Read()
    {
        await Task.CompletedTask;

        return Data;
    }

    public async Task<string> AskAI(string prompt)
    {
        await Task.CompletedTask;

        return $"Sample AI Response for prompt: {prompt} ... You can call an actual model from the AIAssistantService class.";
    }
}
