using Azure;

namespace BropertyBrosClientApplication.Services
{
    public interface ICityService
    {
        Task<ApiResponse<List<CityReadDto>>> GetAllCities();
    }
}
