using Country.DataAccess.Database;

namespace Country.DataAccess.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private ApplicationDbContext _db;

        public CountryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Save country record in database
        /// </summary>
        /// <param name="country"></param>
        public void Add(Model.Country country)
        {
            try
            {
                _db.Countries.Add(country);
                _db.SaveChanges();
            }
            catch (Exception ex) { }

        }

        /// <summary>
        /// Add multiple records of country in database
        /// </summary>
        /// <param name="countries"></param>
        public void AddRange(List<Model.Country> countries)
        {
            try
            {
                foreach (Model.Country country in countries)
                {
                    Add(country);
                }
            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// Retrieve all countries from database
        /// </summary>
        /// <returns></returns>
        public List<Model.Country> GetCountries()
        {
            List<Model.Country> countries = new List<Model.Country>();
            try
            {
                countries = _db.Countries.ToList();
            }
            catch (Exception ex) { }
            return countries;

        }

        /// <summary>
        /// Check if database contains any country
        /// </summary>
        /// <returns></returns>
        public bool DbHasCountries()
        {
            return _db.Countries.Any();
        }
    }
}
