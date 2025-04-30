namespace BropertyBrosClientApplication.Services.Property
{
    public interface IPropertyService
    {
        Task<ApiResponse<List<PropertyReadDto>>> GetAllProperties();
        Task<ApiResponse<PropertyReadDto>> GetPropertyById(int id);
        Task<ApiResponse<PropertyReadDto>> CreateProperty(PropertyCreateDto propertyCreateDto);
        Task<ApiResponse<bool>> UpdateProperty(int id, PropertyCreateDto propertyUpdateDto);
        Task<ApiResponse<Task>> DeleteProperty(int id);
        Task<ApiResponse<List<PropertyReadDto>>> GetPropertiesByRealtor(int id);
        Task<ApiResponse<List<PropertyReadDto>>> GetPropertiesBySearch(PropertySearchDto propertySearchDto);

    }
}
