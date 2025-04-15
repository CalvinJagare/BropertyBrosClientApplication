using BropertyBrosClientApplication.DTO.Realtor;
using System.Net.Http.Json;
using System.Text.Json;

namespace BropertyBrosClientApplication.Services
{
    //Author: Calvin
    public class RealtorService
    {
        private readonly HttpClient _httpClient;

        public RealtorService(IHttpClientFactory clientFactory)
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

        public async Task<List<RealtorReadDto>> GetAllRealtorsAsync()
        {
            return await SendRequestAsync<List<RealtorReadDto>>(() => _httpClient.GetAsync("https://localhost:7151/api/Realtor"));
        }

        public async Task<RealtorReadDto> GetRealtorByIdAsync(int id)
        {
            return await SendRequestAsync<RealtorReadDto>(() => _httpClient.GetAsync($"https://localhost:7151/api/Realtor/{id}"));
        }

        public async Task<RealtorReadDto> CreateRealtorAsync(RealtorCreateDto realtorCreateDto)
        {
            return await SendRequestAsync<RealtorReadDto>(() => _httpClient.PostAsJsonAsync("https://localhost:7151/api/Realtor", realtorCreateDto));
        }

        public async Task<RealtorReadDto> UpdateRealtorAsync(int id, RealtorCreateDto realtorUpdateDto)
        {
            return await SendRequestAsync<RealtorReadDto>(() => _httpClient.PutAsJsonAsync($"https://localhost:7151/api/Realtor/{id}", realtorUpdateDto));
        }

        public async Task DeleteRealtorAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7151/api/Realtor/{id}");
            response.EnsureSuccessStatusCode();
        }

    }
}
