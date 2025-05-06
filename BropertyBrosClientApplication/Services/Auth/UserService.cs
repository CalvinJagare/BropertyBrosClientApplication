using BropertyBrosClientApplication.DTO.User;
using System.Net.Http.Json;

namespace BropertyBrosClientApplication.Services.Auth
{
    public class UserService
    {
        private readonly HttpClient _http;

        public UserService(HttpClient http)
        {
            _http = http;
        }

        public async Task RegisterAsync(UserDto userDto)
        {
            var response = await _http.PostAsJsonAsync("api/users/register", userDto);

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException(await response.Content.ReadAsStringAsync());
        }
    }
}
