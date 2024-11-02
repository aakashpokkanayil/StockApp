using Microsoft.Extensions.Options;
using StockApp.Interfaces;
using StockApp.Models;
using StockApp.Options;
using System.Text.Json;

namespace StockApp.Service
{
    public class FinnHubService: IFinnHubService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly FinnHubOptions _options;

        public FinnHubService(IHttpClientFactory httpClientFactory,IOptions<FinnHubOptions> options)
        {
            _httpClientFactory = httpClientFactory;
            _options = options.Value;
        }

        public async Task<FinnHubResponse> GetStocksQuoteAsync(string? stockSymbol)
        {
            stockSymbol = string.IsNullOrEmpty(stockSymbol)? _options.StockSymbol: stockSymbol;
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            // benefit of using is after this block httpClient will be disposed.
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri=
                    new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_options.Token}"),
                    Method = HttpMethod.Get,
                };// we can use factory design pattern to inject HttpRequestMessage refer later.

                HttpResponseMessage httpResponseMessage= await httpClient.SendAsync(httpRequestMessage);
                // send http resuest and accept resposnse.

                // we have to read the response as stream
                Stream stream =  httpResponseMessage.Content.ReadAsStream();
                // now we got a stream so , we need a stream reader to read it.
                StreamReader streamReader = new StreamReader(stream);   
                // read with stream reader will get response as string
                string response =streamReader.ReadToEnd();
                // we have to desirialize response into a dict<string,obj> using jsonserializer
                FinnHubResponse? resposnseDict = 
                    JsonSerializer.Deserialize<FinnHubResponse>(response);
                

                if (resposnseDict == null) throw new InvalidOperationException("Data not exists in FinnHub");
                //if (resposnseDict.ContainsKey("error")) throw new InvalidOperationException("Invalid Input");
                resposnseDict.StockSymbol=stockSymbol;



                return resposnseDict;

            }
        }
    }
}
