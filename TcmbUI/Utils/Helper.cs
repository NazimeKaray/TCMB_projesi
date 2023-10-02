using System.Net.Http; 
using System.Text;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;

namespace TcmbUI.Utils
{
    public static class Helper
    {
        public async static Task<string> PostJson(string json, string url )
        {
            try 
            {
                using (var content = new StringContent(json, Encoding.UTF8))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    using (var client = new HttpClient() { Timeout = new TimeSpan(0,0,30) }) 
                    {
                        var response = await client.PostAsync(url, content);
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
                
            }
            return "";

        }
    }
}
