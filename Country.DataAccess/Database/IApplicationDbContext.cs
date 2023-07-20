using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Country.DataAccess.Database
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<CountryLibrary.CountryRecord> Countries { get; set; }
    }
}
