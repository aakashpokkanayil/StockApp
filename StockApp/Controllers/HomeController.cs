using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockApp.Interfaces;
using StockApp.Models;

namespace StockApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFinnHubService _myservice;
        private readonly IMapper _mapper;

        public HomeController(IFinnHubService myservice,IMapper mapper)
        {
            _myservice = myservice;
            _mapper = mapper;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            FinnHubResponse? finnhubResposne = await _myservice.GetStocksQuoteAsync(string.Empty);
            Stock stock=_mapper.Map<Stock>(finnhubResposne);

            return View(stock);
        }

    }
}
