namespace elyra.Models;

public enum AiQueryIntent
{
    Unknown = 0,
    FailedAboveAmount = 1,
    WhyFailuresIncreased = 2,
    TopRiskyMerchants = 3,
    WorstTransactions = 4,
    ColumnTransactionIdView = 5,
    ColumnMerchantView = 6,
    ColumnAmountView = 7,
    ColumnCurrencyView = 8,
    ColumnStatusView = 9,
    ColumnPaymentRailView = 10,
    ColumnRiskScoreView = 11,
    ColumnTimestampView = 12
}
