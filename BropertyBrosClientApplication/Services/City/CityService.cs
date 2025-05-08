
using Blazored.LocalStorage;
using BropertyBrosClientApplication.Services.Auth;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

namespace BropertyBrosClientApplication.Services.City
{
    //Author: Arlind
    public class CityService : BaseHttpService, ICityService
    {
        private readonly IClient client;

        public CityService(ILocalStorageService localStorage, IClient client) : base(localStorage, client)
        {
            this.client = client;
        }

        public async Task<ApiResponse<List<CityReadDto>>> GetAllCities()
        {
            var response = new ApiResponse<List<CityReadDto>>
            {
                Data = new List<CityReadDto>(),
                Success = false,
            };

            try
            {
                await GetBearerToken();
                var data = await client.CityAllAsync();
                response = new ApiResponse<List<CityReadDto>>
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
        public async Task<ApiResponse<CityReadDto>> GetCityById(int id)
        {
            var response = new ApiResponse<CityReadDto> { Success = false };

            try
            {
                await GetBearerToken();
                var data = await client.CityGETAsync(id);
                response.Data = data;
                response.Success = true;
            }
            catch (ApiException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return response;
        }

        public async Task<ApiResponse<CityReadDto>> CreateCity(CityCreateDto dto)
        {
            var response = new ApiResponse<CityReadDto> { Success = false };

            try
            {
                await GetBearerToken();
                var created = await client.CityPOSTAsync(dto);
                response.Data = created;
                response.Success = true;
            }
            catch (ApiException ex)
            {
                if (ex.StatusCode == 201) // 201 Created är OK!
                {
                    response.Success = true;
                    return response;
                }

                Debug.WriteLine($"API exception: {ex.StatusCode} - {ex.Message}");
            }



            return response;
        }



        public async Task<ApiResponse<bool>> UpdateCity(int id, CityCreateDto dto)
        {
            var response = new ApiResponse<bool>();

            try
            {
                await GetBearerToken();
                await client.CityPUTAsync(id, dto); 

               
                response.Success = true;
                response.Data = true;
            }
            catch (ApiException ex)
            {
                response.Success = false;
                response.Message = $"API Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"General Error: {ex.Message}";
            }

            return response;
        }




        public async Task<ApiResponse<bool>> DeleteCity(int id)
        {
            var response = new ApiResponse<bool> { Success = false };

            try
            {
                await GetBearerToken();
                await client.CityDELETEAsync(id);
                response.Success = true;
                response.Data = true;
            }
            catch (ApiException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return response;
        }
    }
}
