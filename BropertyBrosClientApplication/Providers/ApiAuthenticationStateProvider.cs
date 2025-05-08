using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BropertyBrosClientApplication.Providers
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;
        private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;

        public ApiAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
            jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //seting up default principal with empty identity for not logged in
            var user = new ClaimsPrincipal(new ClaimsIdentity());

            //Get the saved token from local storage
            var savedToken = await localStorage.GetItemAsync<string>("accessToken");

            //if there is no token, return a new authenticationState with not logged in principal
            if (savedToken == null)
            {
                return new AuthenticationState(user);
            }
            // if saved token is there then read it into tokenContent as JwtSecurityToken
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);

            //if token expired, return that user object with not logged in principal
            if (tokenContent.ValidTo < DateTime.Now)
            {
                return new AuthenticationState(user);
            }
            //if we have not returned by now, we got a savedToken which is valid and then we set the claims and update user
            var claims = await GetClaims();
            user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            
            return new AuthenticationState(user);

        }

        // Method to call when logged in
        public async Task LoggedIn()
        {
            var claims = await GetClaims();
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }

        // Method to call when logged out
        public async Task LoggedOut()
        {
            await localStorage.RemoveItemAsync("accessToken");
            var nobody = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(nobody));
        }
        private async Task<List<Claim>> GetClaims()
        {
            var savedToken = await localStorage.GetItemAsync<string>("accessToken");
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }
    }
}
