using Blazored.LocalStorage;
using BropertyBrosClientApplication.Services.Auth;
using System.Diagnostics;

namespace BropertyBrosClientApplication.Services
{
    // Author: Calvin
    public class CategoryService : BaseHttpService, ICategoryService
    {
        private readonly IClient client;

        public CategoryService(ILocalStorageService localStorage, IClient client) : base(localStorage, client)
        {
            this.client = client;
        }

        public async Task<ApiResponse<List<CategoryReadDto>>> GetAllCategories()
        {
            var response = new ApiResponse<List<CategoryReadDto>>
            {
                Data = new List<CategoryReadDto>(),
                Success = false,
            };

            try
            {
                await GetBearerToken();
                var data = await client.CategoryAllAsync();
                response = new ApiResponse<List<CategoryReadDto>>
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

        public async Task<ApiResponse<CategoryReadDto>> GetCategoryById(int id)
        {
            var response = new ApiResponse<CategoryReadDto>
            {
                Data = null,
                Success = false,
            };

            try
            {
                await GetBearerToken();
                var data = await client.CategoryGETAsync(id);
                response = new ApiResponse<CategoryReadDto>
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

        public async Task<ApiResponse<CategoryReadDto>> CreateCategory(CategoryCreateDto categoryCreateDto)
        {
            var response = new ApiResponse<CategoryReadDto>
            {
                Data = null,
                Success = false,
            };

            try
            {
                await GetBearerToken();
                var data = await client.CategoryPOSTAsync(categoryCreateDto);
                response = new ApiResponse<CategoryReadDto>
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

        public async Task<ApiResponse<bool>> UpdateCategory(int id, CategoryCreateDto categoryUpdateDto)
        {
            var response = new ApiResponse<bool>
            {
                Data = false,
                Success = false,
            };

            try
            {
                await GetBearerToken();
                await client.CategoryPUTAsync(id, categoryUpdateDto);
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

        public async Task<ApiResponse<bool>> DeleteCategory(int id)
        {
            var response = new ApiResponse<bool>
            {
                Data = false,
                Success = false,
            };

            try
            {
                await GetBearerToken();
                await client.CategoryDELETEAsync(id);
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