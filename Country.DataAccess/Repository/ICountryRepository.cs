namespace Country.DataAccess.Repository
{
    public interface ICountryRepository
    {
        void Add(Model.Country country);
        void AddRange(List<Model.Country> countries);
        List<Model.Country> GetCountries();
        bool DbHasCountries();
    }
}
