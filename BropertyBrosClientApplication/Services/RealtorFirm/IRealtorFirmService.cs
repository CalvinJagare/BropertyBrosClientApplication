namespace BropertyBrosClientApplication.Services.RealtorFirm
{
    // Author: Calvin
    public interface IRealtorFirmService
    {
        Task<ApiResponse<List<RealtorFirmReadDto>>> GetAllRealtorFirms();
        Task<ApiResponse<RealtorFirmReadDto>> GetRealtorFirmById(int id);
        Task<ApiResponse<RealtorFirmReadDto>> CreateRealtorFirm(RealtorFirmCreateDto realtorFirmCreateDto);
        Task<ApiResponse<bool>> UpdateRealtorFirm(int id, RealtorFirmCreateDto realtorFirmUpdateDto);
        Task<ApiResponse<bool>> DeleteRealtorFirm(int id);
    }
}
