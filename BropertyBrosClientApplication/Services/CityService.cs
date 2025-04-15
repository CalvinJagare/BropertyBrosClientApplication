using BropertyBrosApi2._0.DTOs.City;
using BropertyBrosClientApplication.DTO.City;
using System.Net.Http.Json;
using System.Text.Json;

namespace BropertyBrosClientApplication.Services
{
    //Author: Arlind
    public class CityService
    {
        private readonly HttpClient _httpClient;

        public CityService(IHttpClientFactory clientFactory)
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

        public async Task<List<CityReadDto>> GetAllCitiesAsync()
        {
            return await SendRequestAsync<List<CityReadDto>>(() => _httpClient.GetAsync("https://localhost:7151/api/City"));
        }

        public async Task<CityReadDto> GetCityByIdAsync(int id)
        {
            return await SendRequestAsync<CityReadDto>(() => _httpClient.GetAsync($"https://localhost:7151/api/City/{id}"));
        }

        public async Task<CityReadDto> CreateCityAsync(CityCreateDto cityCreateDto)
        {
            return await SendRequestAsync<CityReadDto>(() => _httpClient.PostAsJsonAsync("https://localhost:7151/api/City", cityCreateDto));
        }

        public async Task<CityReadDto> UpdateCityAsync(int id, CityCreateDto cityUpdateDto)
        {
            return await SendRequestAsync<CityReadDto>(() => _httpClient.PutAsJsonAsync($"https://localhost:7151/api/City/{id}", cityUpdateDto));
        }

        public async Task DeleteCityAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7151/api/City/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
