using Country.DataAccess.Database;
using Country.DataAccess.Extensions;
using Country.DataAccess.Repository;
using CountryLibrary.Extensions;
using CountryLibrary.Urls;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using System.Net.Http;

namespace CountryTestProject
{
    public class CountryRepoTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;

        public CountryRepoTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "VivaDb")
                .Options;
            _db = new ApplicationDbContext(options);
            _unitOfWork = new UnitOfWork(_db);
        }

        [Fact]
        public void CountryAdd_CorrectResult()
        {
            Country.DataAccess.Model.Country country = new Country.DataAccess.Model.Country()
            {
                Capital = { "GR" },
                Name = new Country.DataAccess.Model.CountryProps.Name() { Common = "Greece" },
                Borders = { "test" }
            };
            _unitOfWork.Country.Add(country);
            var numberOfCountries = _unitOfWork.Country.GetCountries();
            Assert.Single(numberOfCountries);
            Assert.NotEmpty(numberOfCountries);
            Assert.NotEqual(250, numberOfCountries.Count());
        }

        [Fact]
        public void AddRangeCountries_CorrectResult()
        {
            var countriesData = DeserializeJsonObject.DeserializeToCountries(TestResponse.test);

            _unitOfWork.Country.AddRange(countriesData);
            var numberOfCountries = _unitOfWork.Country.GetCountries();
            Assert.Equal(3, numberOfCountries.Count());
        }
    }
}