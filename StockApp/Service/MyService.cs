using StockApp.Interfaces;

namespace StockApp.Service
{
    public class MyService: IMyservice
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MyService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task GetStocksAsync()
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            // benefit of using is after this block httpClient will be disposed.
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri=
                    new Uri("https://finnhub.io/api/v1/quote?symbol=AAPL&token=csi9nspr01qpalorrirgcsi9nspr01qpalorris0"),
                    Method = HttpMethod.Get,
                };// we can use factory design pattern to inject HttpRequestMessage refer later.

                HttpResponseMessage httpResponseMessage= await httpClient.SendAsync(httpRequestMessage);
                // send http resuest and accept resposnse.

                // we have to read the response as stream
                Stream stream = await httpResponseMessage.Content.ReadAsStreamAsync();
                // now we got a stream so , we need a stream reader to read it.
                StreamReader streamReader = new StreamReader(stream);   
                // read with stream reader will get response as string
                string response =streamReader.ReadToEnd();





            }
        }
    }
}
