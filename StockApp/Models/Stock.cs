using System.Text.Json.Serialization;

namespace StockApp.Models
{
    public class Stock
    {
        public string? StockSymbol { get; set; }
        public double CurrentPrice { get; set; }
        public double HighPriceOfTheDay { get; set; }
        public double LowPriceOfTheDay { get; set; }
        public double OpenPriceOfTheDay { get; set; }
    }
}
