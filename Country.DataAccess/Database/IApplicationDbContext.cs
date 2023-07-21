using Microsoft.EntityFrameworkCore;

namespace Country.DataAccess.Database
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<Model.Country> Countries { get; set; }
    }
}
