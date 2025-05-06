
using Blazored.LocalStorage;
using BropertyBrosClientApplication.Services.Auth;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

namespace BropertyBrosClientApplication.Services
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
    }
}
