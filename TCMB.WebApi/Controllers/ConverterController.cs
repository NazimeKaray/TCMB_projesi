using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using TCMB.WebApi.Models;

namespace TCMB.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private readonly ILogger<ConverterController> _logger;

        public ConverterController(ILogger<ConverterController> logger)
        {
            _logger = logger;
        }

        [HttpGet("getToday")]
        public IActionResult GetToday() 
        {
            string url = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xml= XDocument.Load(url);
            return Ok(xml.ToString());
        }

        [HttpGet("getPast")]
        public IActionResult GetPast( string year, string month, string day)
        {
            string url = string.Format("https://www.tcmb.gov.tr/kurlar/{0}{1}/{2}{1}{0}.xml",year,month,day);
            XmlDocument doc=new XmlDocument();
            XmlTextReader rdr = new XmlTextReader(url);
            doc.Load(rdr);
            return Ok(doc.InnerXml);

        }
        [HttpPost("getType")]
        public IActionResult GetType(ExchangeModel model)
        {
            string url = string.Format("https://www.tcmb.gov.tr/kurlar/{0}{1}/{2}{1}{0}.xml", model.Year, model.Month, model.Day);
            XmlDocument doc = new XmlDocument();
            XmlTextReader rdr = new XmlTextReader(url);
            doc.Load(rdr);
            XmlNodeList code= doc.SelectNodes("/Tarih_Date/Currency/@Kod");
            XmlNodeList Buy = doc.SelectNodes("/Tarih_Date/Currency/ForexBuying");
            XmlNodeList Sell = doc.SelectNodes("/Tarih_Date/Currency/ForexSelling");
            var ExchangeDTO=new ExchangeDTO();
            for (int i = 0; i<code.Count; i++){

                if (model.Currency.ToUpper() == code[i].InnerText)
                {
                    ExchangeDTO.Code = code[i].InnerText;
                    ExchangeDTO.Buy = Buy[i].InnerText;
                    ExchangeDTO.Sell=Sell[i].InnerText;
                }
                
            }

            return Ok(ExchangeDTO);
        }


    }
}
