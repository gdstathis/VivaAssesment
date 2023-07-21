using Country.DataAccess.Repository;
using Microsoft.Extensions.Caching.Memory;

namespace Country.DataAccess.CacheMemoryConfig
{
    public class CacheMemoryConfig : ICacheMemoryConfig
    {
        private const string _key = "countries";
        private readonly IMemoryCache _memoryCache;
        private readonly IUnitOfWork _unitOfWork;

        public CacheMemoryConfig(IMemoryCache memoryCache, IUnitOfWork unitOfWork)
        {
            _memoryCache = memoryCache;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Check if cache contains countries
        /// </summary>
        /// <returns></returns>
        public bool CacheHasData()
        {
            return _memoryCache.TryGetValue(_key, out var value);
        }

        /// <summary>
        /// Save countries into cache memory
        /// </summary>
        /// <param name="countries"></param>
        public void SetCache(List<Model.Country> countries)
        {
            try
            {
                _memoryCache.Set(_key, countries);
            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// Get countries from cache memory
        /// </summary>
        /// <returns></returns>
        public List<Model.Country> GetCachedData()
        {
            List<Model.Country> countries = new List<Model.Country>();
            try
            {
                countries=_memoryCache.Get<List<Model.Country>>(_key);
            }
            catch (Exception ex) { }
            return countries;
        }

    }
}
