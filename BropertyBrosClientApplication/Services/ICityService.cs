using Azure;
using BropertyBrosClientApplication.DTO.City;
namespace BropertyBrosClientApplication.Services
// Author: Arlind 
{
    public interface ICityService
    {
        Task<ApiResponse<List<CityReadDto>>> GetAllCities();
        Task<ApiResponse<CityReadDto>> GetCityById(int id);
        Task<ApiResponse<CityReadDto>> CreateCity(CityCreateDto dto);
        Task<ApiResponse<bool>> UpdateCity(int id, CityCreateDto dto);
        Task<ApiResponse<bool>> DeleteCity(int id);
    }
}
