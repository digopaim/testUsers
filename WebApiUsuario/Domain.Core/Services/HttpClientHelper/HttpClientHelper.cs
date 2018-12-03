

using Domain.Core.Services.HttpClientHelper.Interface;
using System.Net.Http;

namespace Domain.Core.Services.HttpClientHelper
{
    public class HttpClientHelper : IHttpClientHelper
    {
        public string GetAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(url).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}