using Country.DataAccess.Repository;
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
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _httpClient = new HttpClient();
            _countryRepository = countryRepository;
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
                var countriesData = JsonConvert.DeserializeObject<List<CountryLibrary.Country>>(jsonResponse);
                foreach (var country in countriesData)
                {

                    _countryRepository.Insert(country);

                }
                return Ok(countriesData);
            }
            else
            {
                return StatusCode((int)response.StatusCode, $"Failed to retrieve countries: {response.StatusCode}");
            }
        }
    }
}
