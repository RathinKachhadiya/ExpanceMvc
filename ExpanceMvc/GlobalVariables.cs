using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ExpanceMvc
{
    public static class GlobalVariables
    {
        public static HttpClient ExpanceApiClient = new HttpClient();

        static GlobalVariables()
        {
            ExpanceApiClient.BaseAddress = new Uri("https://localhost:44303/api/");
            ExpanceApiClient.DefaultRequestHeaders.Clear();
            ExpanceApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
