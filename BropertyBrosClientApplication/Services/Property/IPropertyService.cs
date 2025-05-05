namespace BropertyBrosClientApplication.Services.Property
{
    public interface IPropertyService
    {
        Task<ApiResponse<List<PropertyReadDto>>> GetAllPropertiesAsync();
        Task<ApiResponse<PropertyReadDto>> GetPropertyByIdAsync(int id);
        Task<ApiResponse<PropertyReadDto>> CreatePropertyAsync(PropertyCreateDto propertyCreateDto);
        Task<ApiResponse<bool>> UpdatePropertyAsync(int id, PropertyCreateDto propertyUpdateDto);
        Task<ApiResponse<Task>> DeletePropertyAsync(int id);
        Task<ApiResponse<List<PropertyReadDto>>> GetPropertiesByRealtorAsync(int id);
        Task<ApiResponse<List<PropertyReadDto>>> GetPropertiesBySearchAsync(PropertySearchDto propertySearchDto);

    }
}
