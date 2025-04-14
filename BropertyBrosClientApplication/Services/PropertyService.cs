﻿using BropertyBrosApi2._0.DTOs.Properties;
using System.Text.Json;

namespace BropertyBrosClientApplication.Services
{
    //Author: Daniel, Calvin
    public class PropertyService
    {
        private readonly HttpClient _httpClient;

        public PropertyService(IHttpClientFactory clientFactory)
        {
            this._httpClient = clientFactory.CreateClient("BropertyApi2.0");
        }

        private async Task<T> SendRequestAsync<T>(Func<Task<HttpResponseMessage>> httpRequest)
        {
            var respone = await httpRequest();
            respone.EnsureSuccessStatusCode();
            var content = await respone.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        }

        public async Task<List<PropertyReadDto>> GetAllPropertyAsync()
        {
            return await SendRequestAsync<List<PropertyReadDto>>(() => _httpClient.GetAsync("https://localhost:7151/api/Property"));
        }

        public async Task<PropertyReadDto> GetPropertyByIdAsync(int id)
        {
            return await SendRequestAsync<PropertyReadDto>(() => _httpClient.GetAsync($"https://localhost:7151/api/Property/{id}"));
        }

        public async Task<PropertyReadDto> CreatePropertyAsync(PropertyCreateDto propertyCreateDto)
        {
            return await SendRequestAsync<PropertyReadDto>(() => _httpClient.PostAsJsonAsync("https://localhost:7151/api/Property", propertyCreateDto));
        }

        public async Task<PropertyReadDto> UpdatePropertyAsync(int id, PropertyCreateDto propertyUpdateDto)
        {
            return await SendRequestAsync<PropertyReadDto>(() => _httpClient.PutAsJsonAsync($"https://localhost:7151/api/Property/{id}", propertyUpdateDto));
        }
        public async Task DeletePropertyAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7151/api/Property/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
