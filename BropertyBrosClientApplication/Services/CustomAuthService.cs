using BropertyBrosClientApplication.DTO.User;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using System.Net.Http.Json;
using BropertyBrosClientApplication.Providers;


namespace BropertyBrosClientApplication.Services
{
    public class CustomAuthService : ICustomAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;

        public CustomAuthService(IHttpClientFactory clientFactory, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
        {
            _httpClient = clientFactory.CreateClient("BropertyBrosApi2.0");
            _localStorage = localStorage;
            _authStateProvider = authStateProvider;
        }

        public async Task<bool> AuthenticateAsync(LoginUserDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/user/login", loginDto);

            if (!response.IsSuccessStatusCode)
                return false;

            var token = await response.Content.ReadAsStringAsync();

            await _localStorage.SetItemAsync("accessToken", token);

            await ((ApiAuthenticationStateProvider)_authStateProvider).LoggedIn();

            return true;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("accessToken");
            await ((ApiAuthenticationStateProvider)_authStateProvider).LoggedOut();
        }
    }
}
