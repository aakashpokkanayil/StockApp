using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace StockApp.Models
{
    public class FinnHubResponseDTO
    {
        [JsonPropertyName("c")]
        public double CurrentPrice { get; set; }
        [JsonPropertyName("h")]
        public double HighPriceOfTheDay { get; set; }
        [JsonPropertyName ("l")]
        public double LowPriceOfTheDay { get; set; }
        [JsonPropertyName("o")]
        public double OpenPriceOfTheDay { get; set; }
        [JsonIgnore()]
        public string? StockSymbol { get; set; }
    }
}
