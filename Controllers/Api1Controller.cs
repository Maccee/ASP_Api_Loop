using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASP.NET_projektit.Controllers
{
    [ApiController]
    [Route("Api1")]
    public class Api1Controller : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            using var client = new HttpClient(handler);
            var response = await client.GetAsync("https://localhost:7211/api2");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
