using Newtonsoft.Json;
namespace Country.DataAccess.Extensions
{
    public static class DeserializeJsonObject
    {
        public static List<Country.DataAccess.Model.Country> DeserializeToCountries(string jsonObject)
        {
            return JsonConvert.DeserializeObject<List<Model.Country>>(jsonObject);
        }
    }
}
