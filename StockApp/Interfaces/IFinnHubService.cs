using StockApp.Models;

namespace StockApp.Interfaces
{
    public interface IFinnHubService
    {
         Task<FinnHubResponse> GetStocksQuoteAsync(string? stockSymbol);
    }
}
