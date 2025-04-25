using BropertyBrosApi2._0.DTOs;
using System.Net.Http.Json;
using System.Text.Json;

namespace BropertyBrosClientApplication.Services
{
    // Author: Calvin
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("BropertyApi2.0");
        }

        private async Task<T> SendRequestAsync<T>(Func<Task<HttpResponseMessage>> httpRequest)
        {
            var response = await httpRequest();
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        }

        public async Task<AuthResponse> RegisterUserAsync(UserDto userDto)
        {
            return await SendRequestAsync<AuthResponse>(() => _httpClient.PostAsJsonAsync("https://localhost:7151/api/auth/register", userDto));
        }

        public async Task<AuthResponse> LoginUserAsync(LoginUserDto loginUserDto)
        {
            return await SendRequestAsync<AuthResponse>(() => _httpClient.PostAsJsonAsync("https://localhost:7151/api/auth/login", loginUserDto));
        }
    }
}
