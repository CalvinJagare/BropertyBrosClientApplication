using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using BropertyBrosClientApplication.Providers;

namespace BropertyBrosClientApplication.Services.Authentication
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly IClient httpClient;
        private readonly ILocalStorageService localStorage;
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public AuthentificationService(IClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
            this.authenticationStateProvider = authenticationStateProvider;
        }
        public async Task<bool> AuthenticateAsync(LoginUserDto loginModel)
        {
            var response = await httpClient.LoginAsync(loginModel);

            //Store Token
            await localStorage.SetItemAsync("accessToken", response.Token);

            // change auth state of app, must make sure that its iur apiAuth provider is used.
            await ((ApiAuthenticationStateProvider)authenticationStateProvider).LoggedIn();

            return true;
        }

        public async Task Logout()
        {
          await ((ApiAuthenticationStateProvider)authenticationStateProvider).LoggedOut();
        }
    }
}
