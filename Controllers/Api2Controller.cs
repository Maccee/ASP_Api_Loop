using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASP.NET_projektit.Controllers
{
    [ApiController]
    [Route("Api2")]
    public class Api2Controller : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            
            Console.WriteLine("Api2Controller's Get method was called.");

            await Task.Delay(1000);

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            using var client = new HttpClient(handler);
            Console.WriteLine("Calling Api1.");
            var response = await client.GetAsync("https://localhost:7211/api1");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
