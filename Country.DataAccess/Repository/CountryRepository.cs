using Country.DataAccess.Database;
using CountryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Country.DataAccess.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private ApplicationDbContext _db;

        public CountryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(CountryLibrary.Country country)
        {
            try
            {

                _db.Countries.Add(BuildCountryRecord(country));
                _db.SaveChanges();
            }
            catch (Exception ex) { }
        }

        public CountryRecord BuildCountryRecord(CountryLibrary.Country country)
        {
            CountryRecord record = new CountryRecord();
            record.Capital = (country.Capital != null
                && country.Capital.Count() > 0) ? country.Capital[0] : "";
            record.Name = country.Name.common;
            record.Borders = (country.Borders != null) ?
                String.Join(",", country.Borders) : "";
            return record;
        }
    }
}
