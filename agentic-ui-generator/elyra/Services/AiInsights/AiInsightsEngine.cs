using System.Globalization;
using elyra.Models;

namespace elyra.Services.AiInsights;

public static class AiInsightsEngine
{
    public static AiInsightMessage SummarizeCurrentView(IReadOnlyList<TransactionRecord> rows, DateTime now)
    {
        if (rows.Count == 0)
        {
            return new AiInsightMessage
            {
                Timestamp = now,
                Title = "Current View Summary",
                Severity = "info",
                Message = "There are no transactions in the current view. Clear filters or broaden the query to generate a summary."
            };
        }

        var successCount = rows.Count(x => x.Status == "Successful");
        var failedCount = rows.Count(x => x.Status == "Failed");
        var pendingCount = rows.Count(x => x.Status == "Pending");
        var failureRate = (double)failedCount / rows.Count * 100d;
        var averageAmount = rows.Average(x => x.Amount);
        var highRiskCount = rows.Count(x => x.RiskScore >= 70);
        var topDeclineReason = rows
            .Where(x => x.Status == "Failed" && x.DeclineReason != "None")
            .GroupBy(x => x.DeclineReason)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault() ?? "no dominant decline reason";
        var topSegment = rows
            .GroupBy(x => x.CustomerSegment)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault() ?? "Retail";

        var topMerchantByVolume = rows
            .GroupBy(x => x.Merchant)
            .Select(g => new { Merchant = g.Key, Volume = g.Sum(x => x.Amount) })
            .OrderByDescending(x => x.Volume)
            .First();

        var topMerchantByCount = rows
            .GroupBy(x => x.Merchant)
            .Select(g => new { Merchant = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .First();

        var message =
            $"Current view contains {rows.Count} transactions: {successCount} successful, {failedCount} failed, {pendingCount} pending " +
            $"(failure rate {failureRate.ToString("N1", CultureInfo.InvariantCulture)}%). " +
            $"Average amount is £{averageAmount.ToString("N2", CultureInfo.InvariantCulture)} with {highRiskCount} high-risk transactions. " +
            $"Top merchant by volume is {topMerchantByVolume.Merchant}, while top merchant by count is {topMerchantByCount.Merchant}. " +
            $"Most common decline reason is {topDeclineReason}, and the dominant customer segment is {topSegment}.";

        return new AiInsightMessage
        {
            Timestamp = now,
            Title = "Current View Summary",
            Severity = "info",
            Message = message
        };
    }

    public static AiAnomalyResult DetectAnomalies(IReadOnlyList<TransactionRecord> rows, DateTime now)
    {
        if (rows.Count == 0)
        {
            return new AiAnomalyResult
            {
                Insight = new AiInsightMessage
                {
                    Timestamp = now,
                    Title = "Anomaly Scan",
                    Severity = "info",
                    Message = "No rows are available for anomaly detection in the current view."
                }
            };
        }

        var findings = new List<string>();
        var flaggedIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        var recentWindowStart = rows.Max(x => x.Timestamp).AddHours(-4);
        var repeatedFailures = rows
            .Where(x => x.Status == "Failed" && x.Timestamp >= recentWindowStart)
            .GroupBy(x => x.Merchant)
            .Where(g => g.Count() >= 2)
            .Select(g => new { Merchant = g.Key, Count = g.Count(), Ids = g.Select(x => x.TransactionId) })
            .ToList();

        if (repeatedFailures.Count > 0)
        {
            var top = repeatedFailures.OrderByDescending(x => x.Count).First();
            var topRows = rows.Where(x => x.Merchant == top.Merchant && x.Status == "Failed").ToList();
            var avgRetry = topRows.Count == 0 ? 0 : topRows.Average(x => x.RetryCount);
            findings.Add($"Repeated failures detected for {top.Merchant} ({top.Count} in recent window, avg retry {avgRetry:N1}).");
            foreach (var id in repeatedFailures.SelectMany(x => x.Ids))
            {
                flaggedIds.Add(id);
            }
        }

        var railDistribution = rows
            .GroupBy(x => x.PaymentRail)
            .Select(g => new { Rail = g.Key, Count = g.Count(), Share = (double)g.Count() / rows.Count })
            .OrderByDescending(x => x.Count)
            .First();

        if (railDistribution.Count >= 3 && railDistribution.Share >= 0.60d)
        {
            findings.Add(
                $"Potential payment rail spike on {railDistribution.Rail} ({railDistribution.Count}/{rows.Count} transactions, {railDistribution.Share:P0}).");

            foreach (var id in rows.Where(x => x.PaymentRail == railDistribution.Rail).Select(x => x.TransactionId))
            {
                flaggedIds.Add(id);
            }
        }

        var highRiskFailedCluster = rows
            .Where(x => x.Status == "Failed" && x.RiskScore >= 75 && x.Amount >= 3000m)
            .ToList();

        if (highRiskFailedCluster.Count >= 2)
        {
            var dominantIssuerCode = highRiskFailedCluster
                .GroupBy(x => x.IssuerResponseCode)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault() ?? "N/A";
            var dominantChannel = highRiskFailedCluster
                .GroupBy(x => x.Channel)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault() ?? "mixed";
            findings.Add(
                $"High-risk failed cluster found: {highRiskFailedCluster.Count} failed payments above £3,000 with risk >= 75 (issuer code {dominantIssuerCode}, channel {dominantChannel}).");

            foreach (var id in highRiskFailedCluster.Select(x => x.TransactionId))
            {
                flaggedIds.Add(id);
            }
        }

        if (findings.Count == 0)
        {
            findings.Add("No critical anomalies were detected for the current filtered view.");
        }

        return new AiAnomalyResult
        {
            Insight = new AiInsightMessage
            {
                Timestamp = now,
                Title = "Anomaly Scan",
                Severity = flaggedIds.Count > 0 ? "warning" : "info",
                Message = string.Join(" ", findings)
            },
            FlaggedTransactionIds = flaggedIds
        };
    }
}
