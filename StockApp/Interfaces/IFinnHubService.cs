using StockApp.Models;

namespace StockApp.Interfaces
{
    public interface IFinnHubService
    {
         Task<FinnHubResponseDTO> GetStocksQuoteAsync(string? stockSymbol);
    }
}
