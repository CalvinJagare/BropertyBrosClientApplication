namespace BropertyBrosClientApplication.Services.Realtor
{

    // Author: Emil
    public interface IRealtorService
    {
        Task<ApiResponse<List<RealtorReadDto>>> GetAllRealtorsAsync();
        Task<ApiResponse<RealtorReadDto>> GetRealtorByIdAsync(int realtorId);
        Task<ApiResponse<RealtorReadDto>> CreateRealtorAsync(RealtorCreateDto dto);
        Task<ApiResponse> DeleteRealtorAsync(int realtorId);
        Task<ApiResponse> UpdateRealtorAsync(int realtorId, RealtorCreateDto dto);
    }
}
