using Blazored.LocalStorage;
using BropertyBrosClientApplication.Services.Auth;
using BropertyBrosClientApplication.Services.RealtorFirm;
using System.Diagnostics;

namespace BropertyBrosClientApplication.Services
{
    // Author: Calvin
    public class RealtorFirmService : BaseHttpService, IRealtorFirmService
    {
        private readonly IClient client;

        public RealtorFirmService(ILocalStorageService localStorage, IClient client) : base(localStorage, client)
        {
            this.client = client;
        }

        public async Task<ApiResponse<List<RealtorFirmReadDto>>> GetAllRealtorFirms()
        {
            var response = new ApiResponse<List<RealtorFirmReadDto>>
            {
                Data = new List<RealtorFirmReadDto>(),
                Success = false,
            };

            try
            {
                await GetBearerToken();
                var data = await client.RealtorFirmAllAsync();
                response = new ApiResponse<List<RealtorFirmReadDto>>
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

        public async Task<ApiResponse<RealtorFirmReadDto>> GetRealtorFirmById(int id)
        {
            var response = new ApiResponse<RealtorFirmReadDto>
            {
                Data = null,
                Success = false,
            };

            try
            {
                await GetBearerToken();
                var data = await client.RealtorFirmGETAsync(id);
                response = new ApiResponse<RealtorFirmReadDto>
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

        public async Task<ApiResponse<RealtorFirmReadDto>> CreateRealtorFirm(RealtorFirmCreateDto realtorFirmCreateDto)
        {
            var response = new ApiResponse<RealtorFirmReadDto>
            {
                Data = null,
                Success = false,
            };

            try
            {
                await GetBearerToken();
                var data = await client.RealtorFirmPOSTAsync(realtorFirmCreateDto);
                response = new ApiResponse<RealtorFirmReadDto>
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

        public async Task<ApiResponse<bool>> UpdateRealtorFirm(int id, RealtorFirmCreateDto realtorFirmUpdateDto)
        {
            var response = new ApiResponse<bool>
            {
                Data = false,
                Success = false,
            };

            try
            {
                await GetBearerToken();
                await client.RealtorFirmPUTAsync(id, realtorFirmUpdateDto);
                response = new ApiResponse<bool>
                {
                    Data = true,
                    Success = true,
                };
            }
            catch (ApiException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return response;
        }

        public async Task<ApiResponse<bool>> DeleteRealtorFirm(int id)
        {
            var response = new ApiResponse<bool>
            {
                Data = false,
                Success = false,
            };

            try
            {
                await GetBearerToken();
                await client.RealtorFirmDELETEAsync(id);
                response = new ApiResponse<bool>
                {
                    Data = true,
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
