using Country.DataAccess.Extensions;
using Microsoft.Extensions.Caching.Memory;
using NLog;

namespace Country.DataAccess.CacheMemoryConfig
{
    public class CacheMemoryConfig : ICacheMemoryConfig
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger _logger;

        public CacheMemoryConfig(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Check if cache contains countries
        /// </summary>
        /// <returns></returns>
        public bool CacheHasData()
        {
            return _memoryCache.TryGetValue(CacheKeys.key, out var value);
        }

        /// <summary>
        /// Save countries into cache memory
        /// </summary>
        /// <param name="countries"></param>
        public void SetCache(List<Model.Country> countries)
        {
            try
            {
                _memoryCache.Set(CacheKeys.key, countries);
            }
            catch (Exception ex) { _logger.Error(ex, nameof(SetCache)); }
        }

        /// <summary>
        /// Get countries from cache memory
        /// </summary>
        /// <returns></returns>
        public List<Model.Country>? GetCachedData()
        {
            List<Model.Country> countries = new List<Model.Country>();
            try
            {
                countries = _memoryCache.Get<List<Model.Country>>(CacheKeys.key);
            }
            catch (Exception ex) { _logger.Error(ex, nameof(GetCachedData)); }
            return countries;
        }

    }
}
