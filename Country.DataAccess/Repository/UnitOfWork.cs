using Country.DataAccess.Database;

namespace Country.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _db;
        public ICountryRepository Country { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Country = new CountryRepository(_db);
        }
        /// <summary>
        /// Save the changes of the database when an 
        /// entity modified/deleted/added
        /// </summary>
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
