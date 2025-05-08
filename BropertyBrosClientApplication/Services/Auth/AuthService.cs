
using Blazored.LocalStorage;
using BropertyBrosClientApplication.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;

namespace BropertyBrosClientApplication.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IClient httpClient;
        private readonly ILocalStorageService localStorage;
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public AuthService(IClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
            this.authenticationStateProvider = authenticationStateProvider;
        }
        public async Task<bool> AuthAsync(LoginUserDto loginModel)
        {
            var response = await httpClient.LoginAsync(loginModel);

            //Store token
            await localStorage.SetItemAsync("token", response.Token);

            //Change auth state of app
            await ((ApiAuthStateProvider)authenticationStateProvider).LoggedIn();

            return true;
        }

        public async Task Logout()
        {
            await localStorage.RemoveItemAsync("token");
            await ((ApiAuthStateProvider)authenticationStateProvider).LoggedOut();
        }
    }
}
