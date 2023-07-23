using Country.DataAccess.CacheMemoryConfig;
using Country.DataAccess.Extensions;
using Country.DataAccess.Extensions.Urls;
using Country.DataAccess.Repository;
using CountryLibrary.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;
using System.Text.Json.Nodes;
using ILogger = NLog.ILogger;

namespace VivaAssesment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheMemoryConfig _memoryCacheConfig;
        private readonly ILogger _logger;

        public CountryController(IUnitOfWork unitOfWork, ICacheMemoryConfig memoryCacheConfig)
        {
            _httpClient = HttpClientConfiguration.HttpConfig();
            _unitOfWork = unitOfWork;
            _memoryCacheConfig = memoryCacheConfig;
            _logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Todo: simplify this method 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCountries")]
        public async Task<IActionResult> GetCountries()
        {
            List<Country.DataAccess.Model.Country> countriesData = new List<Country.DataAccess.Model.Country>();
            try
            {
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
                            var jsonResponse = await response.Content.ReadAsStringAsync();
                            countriesData = JsonConvert.DeserializeObject<List<Country.DataAccess.Model.Country>>(jsonResponse);
                            countriesData = await BindCountryFromResponse
                                        .GetCountriesFromRespones(response);
                            _unitOfWork.Country.AddRange(countriesData);
                            _memoryCacheConfig.SetCache(countriesData.ToList());
                        }
                        else
                        {
                            return BadRequest($"Failed to retrieve countries: {response.StatusCode}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, nameof(GetCountries));
                return BadRequest("An error has been occured. Please check log file");
            }

            return Ok(countriesData);
        }
    }
}
