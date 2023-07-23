namespace Country.DataAccess.Extensions
{
    public static class BindCountryFromResponse
    {
        public static async Task<List<Country.DataAccess.Model.Country>> GetCountriesFromRespones(HttpResponseMessage? response)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var countriesData = DeserializeJsonObject.DeserializeToCountries(jsonResponse);
            return countriesData;
        }
    }
}
