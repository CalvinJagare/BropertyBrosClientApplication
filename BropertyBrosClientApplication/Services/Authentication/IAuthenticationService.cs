using BropertyBrosClientApplication.Services.Base2;

namespace BropertyBrosClientApplication.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(LoginUserDto loginUserDto);
        public Task Logout();
    }
}
