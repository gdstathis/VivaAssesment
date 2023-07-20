using Country.DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
