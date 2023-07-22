using Newtonsoft.Json;
namespace Country.DataAccess.Extensions
{
    public static class DeserializeJsonObject
    {
        /// <summary>
        /// Get a json as string and concert it to a list of countries
        /// </summary>
        /// <param name="jsonObject"></param>
        /// <returns></returns>
        public static List<Country.DataAccess.Model.Country> DeserializeToCountries(string jsonObject)
        {
            return JsonConvert.DeserializeObject<List<Model.Country>>(jsonObject);
        }
    }
}
