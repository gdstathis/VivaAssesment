using Country.DataAccess.Database;
using NLog;

namespace Country.DataAccess.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private ApplicationDbContext _db;
        private readonly ILogger _logger;

        public CountryRepository(ApplicationDbContext db)
        {
            _db = db;
            _logger = LogManager.GetCurrentClassLogger();
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
            catch (Exception ex) { _logger.Error(ex, nameof(Add)); }

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
            catch (Exception ex) { _logger.Error(ex, nameof(AddRange)); }
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
            catch (Exception ex) { _logger.Error(ex, nameof(GetCountries)); }
            return countries;

        }

        /// <summary>
        /// Check if database contains any country
        /// </summary>
        /// <returns></returns>
        public bool DbHasCountries()
        {
            bool result = false;
            try
            {
                result = _db.Countries.Any();
            }
            catch (Exception ex) { _logger.Error(ex, nameof(DbHasCountries)); }
            return result;
        }
    }
}
