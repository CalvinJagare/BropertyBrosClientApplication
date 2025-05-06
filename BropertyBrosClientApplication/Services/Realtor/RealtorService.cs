using Blazored.LocalStorage;
using BropertyBrosClientApplication.Services.Auth;

namespace BropertyBrosClientApplication.Services.Realtor
{
    //Author: Emil
    public class RealtorService : BaseHttpService, IRealtorService
    {
        private readonly IClient client;

        public RealtorService(ILocalStorageService localStorage, IClient client) : base(localStorage, client)
        {
            this.client = client;
        }

        public async Task<ApiResponse<List<RealtorReadDto>>> GetAllRealtorsAsync()
        {
            ApiResponse<List<RealtorReadDto>> response = new();

            try
            {
                await GetBearerToken();
                ICollection<RealtorReadDto> collection = await client.RealtorAllAsync();

                response.Data = collection.ToList();
                response.Success = true;
            }
            catch(ApiException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ApiResponse<RealtorReadDto>> GetRealtorByIdAsync(int realtorId)
        {
            ApiResponse<RealtorReadDto> response = new();

            try
            {
                await GetBearerToken();
                RealtorReadDto data = await client.RealtorGETAsync(realtorId);

                response.Data = data;
                response.Success = true;
            }
            catch(ApiException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ApiResponse<RealtorReadDto>> CreateRealtorAsync(RealtorCreateDto dto)
        {
            ApiResponse<RealtorReadDto> response = new();

            try
            {
                await GetBearerToken();
                RealtorReadDto data = await client.RealtorPOSTAsync(dto);

                response.Data = data;
                response.Success = true;
            }
            catch (ApiException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ApiResponse> DeleteRealtorAsync(int realtorId)
        {
            ApiResponse response = new();

            try
            {
                await GetBearerToken();
                await client.RealtorDELETEAsync(realtorId);

                response.Success = true;
            }
            catch(ApiException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ApiResponse> UpdateRealtorAsync(int realtorId, RealtorCreateDto dto)
        {
            ApiResponse response = new();

            try
            {
                await GetBearerToken();
                await client.RealtorPUTAsync(realtorId, dto);

                response.Success = true;
            }
            catch(ApiException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ApiResponse<List<RealtorReadDto>>> GetRealtorsBySearchAsync(RealtorSearchDto dto)
        {
            ApiResponse<List<RealtorReadDto>> response = new();

            try
            {
                await GetBearerToken();
                ICollection<RealtorReadDto> collection = await client.GetRealtorsBySearchAsync(dto);

                response.Data = collection.ToList();
                response.Success = true;
            }
            catch (ApiException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
