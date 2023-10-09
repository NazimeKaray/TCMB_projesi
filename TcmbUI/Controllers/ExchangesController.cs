using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TcmbUI.Utils;
using TcmbUI.Models;

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
        [HttpPost]
        public IActionResult Exchanges(string iDate, string iCurrency)
        {
            var response = Helper.PostJson("{\"currency\":\"usd\",\"year\":\"2023\",\"month\":\"10\",\"day\":\"02\"}", "https://localhost:44306/api/Converter/Exchange").Result;
            ViewBag.Exchanges=response;
            var data = JsonConvert.DeserializeObject<ExchangesViewModel>(response);
            return View(data);
        }
        //[HttpGet]
        ////public IActionResult Exchanges()
        ////{
        ////    return View();
        ////}

    }
}
