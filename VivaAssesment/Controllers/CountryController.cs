using CountryLibrary;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace VivaAssesment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly HttpClient _httpClient;

        public CountryController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var apiUrl = "https://restcountries.com/v3.1/all";
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var countriesData = JsonConvert.DeserializeObject<List<Country>>(jsonResponse);
                return Ok(countriesData);
            }
            else
            {
                return StatusCode((int)response.StatusCode, $"Failed to retrieve countries: {response.StatusCode}");
            }
        }
    }
}
