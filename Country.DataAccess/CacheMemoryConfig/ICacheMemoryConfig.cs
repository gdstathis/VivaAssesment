namespace Country.DataAccess.CacheMemoryConfig
{
    public interface ICacheMemoryConfig
    {
        bool CacheHasData();
        void SetCache(List<Model.Country> countries);
        List<Model.Country>? GetCachedData();
    }
}
