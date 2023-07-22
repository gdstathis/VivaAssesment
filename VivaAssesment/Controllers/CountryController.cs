using Country.DataAccess.CacheMemoryConfig;
using Country.DataAccess.Extensions;
using Country.DataAccess.Repository;
using CountryLibrary.Extensions;
using CountryLibrary.Urls;
using Microsoft.AspNetCore.Mvc;

namespace VivaAssesment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheMemoryConfig _memoryCacheConfig;

        public CountryController(IUnitOfWork unitOfWork, ICacheMemoryConfig memoryCacheConfig)
        {
            _httpClient = HttpClientConfiguration.HttpConfig();
            _unitOfWork = unitOfWork;
            _memoryCacheConfig = memoryCacheConfig;
        }

        /// <summary>
        /// Todo: simplify this method 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            List<Country.DataAccess.Model.Country> countriesData = new List<Country.DataAccess.Model.Country>();

            if (_memoryCacheConfig.CacheHasData())
            {
                return Ok(_memoryCacheConfig.GetCachedData());
            }
            else
            {
                if (_unitOfWork.Country.DbHasCountries())
                {
                    countriesData = _unitOfWork.Country.GetCountries().ToList();
                    _memoryCacheConfig.SetCache(countriesData.ToList());
                }
                else
                {
                    var response = await _httpClient.GetAsync(Urls.UrlOfCountryApi);
                    if (response.IsSuccessStatusCode)
                    {
                        countriesData = await BindCountryFromResponse
                                    .GetCountriesFromRespones(response);
                        _unitOfWork.Country.AddRange(countriesData);
                        _memoryCacheConfig.SetCache(countriesData.ToList());
                    }
                    else
                    {
                        return StatusCode((int)response.StatusCode, $"Failed to retrieve countries: {response.StatusCode}");
                    }
                }
                return Ok(countriesData);
            }
        }
    }
}
