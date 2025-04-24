using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BropertyBrosClientApplication.Services.Providers
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;
        private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;
        private AuthenticationState? cachedAuthState;

        public ApiAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
            jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (cachedAuthState != null)
                return Task.FromResult(cachedAuthState);

            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
        }

        public async Task InitFromClientAsync()
        {
            var savedToken = await localStorage.GetItemAsync<string>("accessToken");

            if (string.IsNullOrWhiteSpace(savedToken))
            {
                cachedAuthState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
            else
            {
                var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);

                if (tokenContent.ValidTo < DateTime.UtcNow)
                {
                    cachedAuthState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }
                else
                {
                    var claims = tokenContent.Claims.ToList();
                    claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
                    var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
                    cachedAuthState = new AuthenticationState(user);
                }
            }

            NotifyAuthenticationStateChanged(Task.FromResult(cachedAuthState));
        }

        public async Task LoggedIn()
        {
            var claims = await GetClaims();
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }


        public async Task LoggedOut()
        {
            await localStorage.RemoveItemAsync("accessToken");
            cachedAuthState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            NotifyAuthenticationStateChanged(Task.FromResult(cachedAuthState));
        }

        private async Task<List<Claim>> GetClaims()
        {
            var savedToken = await localStorage.GetItemAsync<string>("accessToken");

            if (string.IsNullOrWhiteSpace(savedToken))
                return new List<Claim>();

            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));

            return claims;
        }

    }
}

