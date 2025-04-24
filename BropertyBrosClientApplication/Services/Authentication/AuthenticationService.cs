using Blazored.LocalStorage;
using BropertyBrosClientApplication.Services.Base2;
using BropertyBrosClientApplication.Services.Providers;
using Microsoft.AspNetCore.Components.Authorization;

namespace BropertyBrosClientApplication.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IClient httpClient;
        private readonly ILocalStorageService localStorage;
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public AuthenticationService(IClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> AuthenticateAsync(LoginUserDto loginUserDto)
        {
            var response = await httpClient.LoginAsync(loginUserDto);

            await localStorage.SetItemAsync("accessToken", response.Token);

            await ((ApiAuthenticationStateProvider)authenticationStateProvider).LoggedIn();


            return true;
        }

        public async Task Logout()
        {
            await ((ApiAuthenticationStateProvider)authenticationStateProvider).LoggedOut();
        }
    }   
    
}
