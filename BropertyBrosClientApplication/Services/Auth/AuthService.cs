
using Blazored.LocalStorage;

namespace BropertyBrosClientApplication.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IClient httpClient;
        private readonly ILocalStorageService localStorage;

        public AuthService(IClient httpClient, ILocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
        }
        public async Task<bool> AuthAsync(LoginUserDto loginModel)
        {
            var response = await httpClient.LoginAsync(loginModel);

            //Store token
            await localStorage.SetItemAsync("token", response.Token);

            //Change auth state of app
            //Add Apiauthstateprovider

            return true;
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }
    }
}
