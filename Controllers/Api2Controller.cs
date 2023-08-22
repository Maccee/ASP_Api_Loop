using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASP.NET_projektit.Controllers;

[ApiController]
[Route("Api2")]
public class Api2Controller : ControllerBase
{
    private readonly IHttpClientFactory _clientFactory;

    public Api2Controller(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
        var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.Accept.Clear();

        // Add this if the handler is created to bypass SSL validation
        client = new HttpClient(handler);

        // Introduce a delay of 1 second
        await Task.Delay(1000);

        try
        {
            Console.WriteLine("kutsutaan api1");
            var response = await client.GetAsync("https://localhost:7211/api1");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            else
            {
                return BadRequest($"Failed with status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }
}
