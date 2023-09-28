namespace TCMB.WebApi.Models
{
    public class ExchangeModel
    {
        public string Currency { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
    }
    public class ExchangeDTO 
    {
        public string Code { get; set; }
        public string Buy { get; set; }
        public string Sell { get; set; }
    }
}
