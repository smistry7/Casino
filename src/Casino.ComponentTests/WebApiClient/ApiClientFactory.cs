using Newtonsoft.Json.Serialization;
using Refit;

namespace Casino.ComponentTests.WebApiClient
{
    public class ApiClientFactory
    {
        private readonly HttpClient _httpClient;

        public ApiClientFactory(HttpClient httpClient)
        {
            _httpClient = httpClient;   
        }

        public T BuildApi<T>() where T : ICasinoApi
        {
            var serialiser = new NewtonsoftJsonContentSerializer(new Newtonsoft.Json.JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            return RestService.For<T>(_httpClient, new RefitSettings { ContentSerializer = serialiser });
        }
    }

}
