using elyra.Models;

namespace elyra.Services.DemoData;

public static class TransactionDataFactory
{
    private static readonly string[] Merchants =
    [
        "Brixton Grocers Ltd", "Camden Mobility Co", "Leeds Home Energy", "Edinburgh Travel Hub",
        "Bristol Care Pharmacy", "Manchester Tech Supplies", "Norwich Fresh Market", "Sheffield Telecom Retail",
        "Oxford Digital Press", "Glasgow Urban Transit", "Liverpool Fashion Wharf", "Cardiff Bistro Collective",
        "Brighton Health Foods", "Birmingham Design Studio", "Yorkshire Kitchen Goods", "Reading Fitness Group",
        "Milton Keynes Retail Park", "Leicester Learning Hub", "Newcastle Mobility Service", "Southampton Marine Gear"
    ];

    private static readonly string[] Rails = ["Faster Payments", "Card Acquirer", "Open Banking", "BACS"];
    private static readonly string[] Segments = ["Retail", "SMB", "Enterprise", "Marketplace"];
    private static readonly string[] Channels = ["Web", "Mobile", "POS", "API"];
    private static readonly string[] Countries = ["GB", "IE", "NL", "DE", "FR"];
    private static readonly string[] DeclineReasons = ["Insufficient funds", "Issuer unavailable", "3DS challenge failed", "Suspected fraud", "Velocity limit"];
    private static readonly string[] IssuerCodes = ["05", "51", "54", "57", "62", "91"];

    public static List<TransactionRecord> GenerateSeedData(DateTime now, int size = 520)
    {
        var random = new Random(20260416);
        var records = new List<TransactionRecord>(size);
        var startSequence = 184200;

        for (var i = 0; i < size; i++)
        {
            var seq = startSequence + i + 1;
            records.Add(CreateTransaction(now, random, seq, injectAnomalyBias: i % 27 == 0));
        }

        return records
            .OrderByDescending(x => x.Timestamp)
            .ToList();
    }

    public static TransactionRecord CreateLiveTransaction(DateTime now, int sequence)
    {
        var random = new Random(unchecked((int)(now.Ticks + sequence)));
        return CreateTransaction(now, random, sequence, injectAnomalyBias: sequence % 7 == 0);
    }

    private static TransactionRecord CreateTransaction(DateTime now, Random random, int sequence, bool injectAnomalyBias)
    {
        var merchant = Merchants[random.Next(Merchants.Length)];
        var rail = Rails[random.Next(Rails.Length)];
        var baseStatusRoll = random.Next(100);
        var status = baseStatusRoll switch
        {
            < 72 => "Successful",
            < 90 => "Failed",
            _ => "Pending"
        };

        if (injectAnomalyBias && random.NextDouble() < 0.65)
        {
            status = "Failed";
            rail = "Card Acquirer";
        }

        var amount = Math.Round((decimal)(random.NextDouble() * 7800d + 35d), 2);
        var riskScore = status == "Failed"
            ? random.Next(45, 98)
            : random.Next(6, 78);

        if (injectAnomalyBias)
        {
            amount = Math.Round(amount + 1700m, 2);
            riskScore = Math.Min(99, riskScore + 12);
        }

        var retryCount = status == "Failed" ? random.Next(1, 4) : random.Next(0, 2);
        var declineReason = status == "Failed"
            ? DeclineReasons[random.Next(DeclineReasons.Length)]
            : "None";
        var issuerResponseCode = status == "Failed"
            ? IssuerCodes[random.Next(IssuerCodes.Length)]
            : "00";

        var minutesAgo = random.Next(2, 60 * 24 * 10);
        var timestamp = now.AddMinutes(-minutesAgo);

        return new TransactionRecord
        {
            TransactionId = $"TXN-2024-{sequence:000000}",
            Merchant = merchant,
            Amount = amount,
            Currency = "GBP",
            Status = status,
            PaymentRail = rail,
            RiskScore = riskScore,
            DeclineReason = declineReason,
            RetryCount = retryCount,
            IssuerResponseCode = issuerResponseCode,
            CustomerSegment = Segments[random.Next(Segments.Length)],
            Country = Countries[random.Next(Countries.Length)],
            Channel = Channels[random.Next(Channels.Length)],
            ProcessingTimeSeconds = Math.Round((decimal)(random.NextDouble() * 2.8d + 0.6d), 2),
            Timestamp = timestamp
        };
    }
}
