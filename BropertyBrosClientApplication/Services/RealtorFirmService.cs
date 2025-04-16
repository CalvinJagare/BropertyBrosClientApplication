using BropertyBrosClientApplication.DTO.RealtorFirm;
using System.Text.Json;

namespace BropertyBrosClientApplication.Services
{
    //Author: Nayab

    public class RealtorFirmService
    {
        private readonly HttpClient _httpClient;

        public RealtorFirmService(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("BropertyApi2.0");
        }

        private async Task<T> SendRequestAsync<T>(Func<Task<HttpResponseMessage>> httpRequest)
        {
            var response = await httpRequest();
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"API Error: {response.StatusCode}, Details: {errorContent}");
            }
            else
            {
                response.EnsureSuccessStatusCode();
            }
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        }
        public async Task<List<RealtorFirmReadDto>> GetAllRealtorFirmsAsync()
        {
            return await SendRequestAsync<List<RealtorFirmReadDto>>(() => _httpClient.GetAsync("https://localhost:7151/api/RealtorFirm"));
        }
        public async Task<RealtorFirmReadDto> GetRealtorFirmByIdAsync(int id)
        {
            return await SendRequestAsync<RealtorFirmReadDto>(() => _httpClient.GetAsync($"https://localhost:7151/api/RealtorFirm/{id}"));
        }

    }
}
