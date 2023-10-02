using Microsoft.AspNetCore.Mvc;
using TcmbUI.Utils;

namespace TcmbUI.Controllers
{
    public class ExchangesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Nazime()
        {
            return View();
        }
        public IActionResult Exchanges()
        {
            var response = Helper.PostJson("{\"currency\":\"usd\",\"year\":\"2023\",\"month\":\"10\",\"day\":\"02\"}", "https://localhost:44306/api/Converter/Exchange").Result;
            



            return View();
        }

    }
}
