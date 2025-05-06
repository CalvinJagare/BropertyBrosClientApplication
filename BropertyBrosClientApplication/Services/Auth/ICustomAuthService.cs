using BropertyBrosClientApplication.DTO.User;
using System.Threading.Tasks;

namespace BropertyBrosClientApplication.Services.Auth
{
    public interface ICustomAuthService
    {
        Task<bool> AuthenticateAsync(LoginUserDto loginDto);
        Task Logout(); // <- lägg till denna
    }
}
