using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BropertyBrosClientApplication.Providers
{
    public class ApiAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;
        private readonly JwtSecurityTokenHandler jwtSecurityToken;

        public ApiAuthStateProvider(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
            jwtSecurityToken = new JwtSecurityTokenHandler();
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity());

            string savedToken = null;
            try
            {
                savedToken = await localStorage.GetItemAsync<string>("token");
            }
            catch
            {
                return new AuthenticationState(user);
            }

            if (savedToken == null)
            {
                return new AuthenticationState(user);
            }

            var tokenContent = jwtSecurityToken.ReadJwtToken(savedToken);

            if (tokenContent.ValidTo < DateTime.Now.ToUniversalTime())
            {
                return new AuthenticationState(user);
            }

            var claims = await GetClaims();
            user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));

            return new AuthenticationState(user);
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
            await localStorage.RemoveItemAsync("token");
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }

        private async Task<IEnumerable<Claim>?> GetClaims()
        {
            var savedToken = await localStorage.GetItemAsync<string>("token");
            var tokenContent = jwtSecurityToken.ReadJwtToken(savedToken);
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }
    }
}
