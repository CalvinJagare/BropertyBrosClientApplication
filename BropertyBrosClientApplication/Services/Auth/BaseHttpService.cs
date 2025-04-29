using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace BropertyBrosClientApplication.Services.Auth
{
    public class BaseHttpService
    {
        private readonly ILocalStorageService localStorage;
        private readonly IClient client;

        public BaseHttpService(ILocalStorageService localStorage, IClient client)
        {
            this.localStorage = localStorage;
            this.client = client;
        }

        protected async Task GetBearerToken()
        {
            var token = await localStorage.GetItemAsync<string>("token");
            if (!string.IsNullOrEmpty(token))
            {
                client.Httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
