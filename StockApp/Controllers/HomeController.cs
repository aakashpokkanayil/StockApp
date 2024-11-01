using Microsoft.AspNetCore.Mvc;
using StockApp.Interfaces;

namespace StockApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMyservice _myservice;

        public HomeController(IMyservice myservice)
        {
            _myservice = myservice;
        }
        [Route("/")]
        public IActionResult Index()
        {
            _myservice.GetStocksAsync();
            return View();
        }

    }
}
