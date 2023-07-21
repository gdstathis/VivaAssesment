using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
namespace CountryLibrary.Extensions
{
    public static class DeserializeJsonObject
    {
        public static List<Country.DataAccess> DeserializeToCountries(string jsonObject)
        {
            return JsonConvert.DeserializeObject<List<Model.Country>>(jsonObject);
        }
    }
}
