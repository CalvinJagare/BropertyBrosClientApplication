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

        public async Task<List<CategoryReadDto>> GetAllCategoryAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7151/api/Category");
            var content = await response.Content.ReadAsStringAsync();
            var categoryReadDtos = JsonSerializer.Deserialize<List<CategoryReadDto>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return categoryReadDtos!;
        }

        public async Task<CategoryReadDto> GetCategoryByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7151/api/Category/{id}");
            var content = await response.Content.ReadAsStringAsync();
            var categoryReadDto = JsonSerializer.Deserialize<CategoryReadDto>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return categoryReadDto!;
        }

        public async Task<CategoryReadDto> CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7151/api/Category", categoryCreateDto);
            var content = await response.Content.ReadAsStringAsync();
            var createdCategoryReadDto = JsonSerializer.Deserialize<CategoryReadDto>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return createdCategoryReadDto!;
        }

        public async Task<CategoryReadDto> UpdateCategoryAsync(int id, CategoryCreateDto categoryUpdateDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7151/api/Category/{id}", categoryUpdateDto);
            var content = await response.Content.ReadAsStringAsync();
            var updatedCategoryReadDto = JsonSerializer.Deserialize<CategoryReadDto>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return updatedCategoryReadDto!;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7151/api/Category/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to delete category");
            }
        }
    }
}
