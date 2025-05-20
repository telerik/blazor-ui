namespace BlazorFinancialDashboard.Data;

public class StockPoint
{
    public DateTime Date { get; set; }

    public decimal Open { get; set; }

    public decimal Close { get; set; }

    public decimal High { get; set; }

    public decimal Low { get; set; }

    public decimal Volume { get; set; }

    public StockPoint(DateTime date, decimal open, decimal close, decimal high, decimal low, decimal volume)
    {
        Date = date;
        Open = open;
        Close = close;
        High = high;
        Low = low;
        Volume = volume;
    }

    public StockPoint()
    {

    }
}
