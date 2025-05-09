namespace BropertyBrosClientApplication.Services.Realtor
{

    // Author: Emil
    //Co-author: Arlind
    public interface IRealtorService
    {
        Task<ApiResponse<List<RealtorReadDto>>> GetAllRealtorsAsync();
        Task<ApiResponse<List<RealtorReadDto>>> GetRealtorsBySearchAsync(RealtorSearchDto dto);
        Task<ApiResponse<RealtorReadDto>> GetRealtorByIdAsync(int realtorId);
        Task<ApiResponse<RealtorReadDto>> GetRealtorByUserIdAsync(string userId);
        Task<ApiResponse<RealtorReadDto>> CreateRealtorAsync(RealtorCreateDto dto);
        Task<ApiResponse> DeleteRealtorAsync(int realtorId);
        Task<ApiResponse> UpdateRealtorAsync(int realtorId, RealtorCreateDto dto);
        Task<ApiResponse> RegisterRealtorAsync(RegisterRealtorDto dto);
    }
}
