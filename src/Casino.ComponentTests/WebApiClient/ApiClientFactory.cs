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

        public IUserApi BuildUserApi()
        {
            var serialiser = new NewtonsoftJsonContentSerializer(new Newtonsoft.Json.JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            return RestService.For<IUserApi>(_httpClient, new RefitSettings { ContentSerializer = serialiser });
        }
    }

}
