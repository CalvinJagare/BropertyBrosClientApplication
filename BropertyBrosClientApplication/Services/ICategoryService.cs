namespace BropertyBrosClientApplication.Services
{
    //Author: Calvin
    public interface ICategoryService
    {
        Task<ApiResponse<List<CategoryReadDto>>> GetAllCategories();
        Task<ApiResponse<CategoryReadDto>> GetCategoryById(int id);
        Task<ApiResponse<CategoryReadDto>> CreateCategory(CategoryCreateDto categoryCreateDto);
        Task<ApiResponse<bool>> UpdateCategory(int id, CategoryCreateDto categoryUpdateDto);
        Task<ApiResponse<bool>> DeleteCategory(int id);
    }
}