using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.WebUI.Models;

namespace RapidApi.WebUI.Controllers
{
    public class GasController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://gas-price.p.rapidapi.com/europeanCountries"),
                Headers =
    {
        { "x-rapidapi-key", "e87c6df87cmshcd0612b2e50cc14p1ab93djsnce86952f3d1f" },
        { "x-rapidapi-host", "gas-price.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var jsonBody = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GassPriceViewModel>(jsonBody);
                return View(values.results);
            }
        }
    }
}
