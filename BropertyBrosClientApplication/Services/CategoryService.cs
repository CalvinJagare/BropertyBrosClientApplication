using BropertyBrosClientApplication.DTO.CategoryDto;
using System.Net.Http.Json;
using System.Text.Json;

namespace BropertyBrosClientApplication.Services
{
    //Author: Calvin
    public class CategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(IHttpClientFactory clientFactory)
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

        public async Task<List<CategoryReadDto>> GetAllCategoryAsync()
        {
            return await SendRequestAsync<List<CategoryReadDto>>(() => _httpClient.GetAsync("https://localhost:7151/api/Category"));
        }

        public async Task<CategoryReadDto> GetCategoryByIdAsync(int id)
        {
            return await SendRequestAsync<CategoryReadDto>(() => _httpClient.GetAsync($"https://localhost:7151/api/Category/{id}"));
        }

        public async Task<CategoryReadDto> CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
        {
            return await SendRequestAsync<CategoryReadDto>(() => _httpClient.PostAsJsonAsync("https://localhost:7151/api/Category", categoryCreateDto));
        }

        public async Task<CategoryReadDto> UpdateCategoryAsync(int id, CategoryCreateDto categoryUpdateDto)
        {
            return await SendRequestAsync<CategoryReadDto>(() => _httpClient.PutAsJsonAsync($"https://localhost:7151/api/Category/{id}", categoryUpdateDto));
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7151/api/Category/{id}");
            response.EnsureSuccessStatusCode();
        }

    }
}
