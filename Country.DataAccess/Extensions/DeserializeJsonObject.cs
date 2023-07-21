using Newtonsoft.Json;
namespace CountryLibrary.Extensions
{
    public static class DeserializeJsonObject
    {
        /// <summary>
        /// Get as argument a json object and deserialize to 
        /// a list of Country model
        /// </summary>
        /// <param name="jsonObject"></param>
        /// <returns></returns>
        public static List<Country.DataAccess.Model.Country> DeserializeToCountries(string jsonObject)
        {
            return JsonConvert.DeserializeObject<List<Country.DataAccess.Model.Country>>(jsonObject);
        }
    }
}
