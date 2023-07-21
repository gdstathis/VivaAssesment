namespace Country.DataAccess.Repository
{
    public interface IUnitOfWork
    {
        ICountryRepository Country { get; }
        void Save();
    }
}
