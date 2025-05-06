using Blazored.LocalStorage;
using BropertyBrosClientApplication.DTO.Properties;
using BropertyBrosClientApplication.Services.Auth;
using System.Diagnostics;
using System.Text.Json;

namespace BropertyBrosClientApplication.Services.Property
{
    //Author: Daniel
    //Co-author: Emil
    public class PropertyService : BaseHttpService, IPropertyService
    {
        private readonly IClient client;

        public PropertyService(ILocalStorageService localStorage, IClient client) : base(localStorage, client)
        {
            this.client = client;
        }

        public async Task<ApiResponse<PropertyReadDto>> CreatePropertyAsync(PropertyCreateDto propertyCreateDto)
        {
            var response = new ApiResponse<PropertyReadDto>
            {
                Data = new PropertyReadDto(),
                Success = false,
            };
            try
            {
                await GetBearerToken();
                var result = await client.PropertyPOSTAsync(propertyCreateDto);
                response = new ApiResponse<PropertyReadDto>
                {
                    Data = result,
                    Success = true,
                };
            }
            catch (ApiException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return response;
        }

        public async Task<ApiResponse<Task>> DeletePropertyAsync(int id)
        {
            var response = new ApiResponse<Task>
            {
                Data = null,
                Success = false,
            };

            try
            {
                await GetBearerToken();
                var data = client.PropertyDELETEAsync(id);
                response = new ApiResponse<Task>
                {
                    Data = data,
                    Success = true,
                };
            }
            catch (ApiException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return response;
        }

        public async Task<ApiResponse<List<PropertyReadDto>>> GetAllPropertiesAsync()
        {
            var response = new ApiResponse<List<PropertyReadDto>>
            {
                Data = new List<PropertyReadDto>(),
                Success = false,
            };
            try
            {
                await GetBearerToken();
                var data = await client.PropertyAllAsync();
                response = new ApiResponse<List<PropertyReadDto>>
                {
                    Data = data.ToList(),
                    Success = true,
                };
            }
            catch (ApiException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return response;
        }

        public async Task<ApiResponse<List<PropertyReadDto>>> GetPropertiesByRealtorAsync(int id)
        {
            var reponse = new ApiResponse<List<PropertyReadDto>>
            {
                Data = new List<PropertyReadDto>(),
                Success = false,
            };
            try
            {
                await GetBearerToken();
                var data = await client.GetPropertiesByRealtorAsync(id);
                reponse = new ApiResponse<List<PropertyReadDto>>
                {
                    Data = data.ToList(),
                    Success = true,
                };
            }
            catch (ApiException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return reponse;
        }

        public async Task<ApiResponse<List<PropertyReadDto>>> GetPropertiesBySearchAsync(PropertySearchDto propertySearchDto)
        {
            var reponse = new ApiResponse<List<PropertyReadDto>>
            {
                Data = new List<PropertyReadDto>(),
                Success = false,
            };
            try
            {
                await GetBearerToken();
                var data = await client.GetPropertiesBySearchAsync(propertySearchDto);
                reponse = new ApiResponse<List<PropertyReadDto>>
                {
                    Data = data.ToList(),
                    Success = true,
                };
            }
            catch (ApiException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return reponse;
        }

        public async Task<ApiResponse<PropertyReadDto>> GetPropertyByIdAsync(int id)
        {
            var response = new ApiResponse<PropertyReadDto>
            {
                Data = new PropertyReadDto(),
                Success = false,
            };

            try
            {
                await GetBearerToken();
                var data = await client.PropertyGETAsync(id);
                response = new ApiResponse<PropertyReadDto>
                {
                    Data = data,
                    Success = true,
                };
            }
            catch (ApiException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return response;
        }

        public async Task<ApiResponse<bool>> UpdatePropertyAsync(int id, PropertyCreateDto propertyUpdateDto)
        {
            var reponse = new ApiResponse<bool>
            {
                Data = false,
                Success = false,
            };
            try
            {
                await GetBearerToken();
                var data = client.PropertyPUTAsync(id, propertyUpdateDto);
                reponse = new ApiResponse<bool>
                {
                    Data = true,
                    Success = true,
                };
            }
            catch (ApiException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return reponse;
        }
    }
}
