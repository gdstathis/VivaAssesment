using System.Net.Http.Headers;

namespace CountryLibrary.Extensions
{
    public static class HttpClientConfiguration
    {
        public static HttpClient HttpConfig()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
