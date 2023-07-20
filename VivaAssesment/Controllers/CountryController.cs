using Country.DataAccess.Repository;
using Country.DataAccess.Urls;
using CountryLibrary;
using CountryLibrary.Extensions;
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
        private readonly IUnitOfWork _unitOfWork;
        public CountryController(IUnitOfWork unitOfWork)
        {
            _httpClient = HttpClientConfiguration.HttpConfig(_httpClient);
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var response = await _httpClient.GetAsync(Urls.UrlOfCountryApi);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var countriesData = JsonConvert.DeserializeObject<List<CountryLibrary.Country>>(jsonResponse);
                foreach (var country in countriesData)
                {
                    _unitOfWork.Country.Add(country);

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
