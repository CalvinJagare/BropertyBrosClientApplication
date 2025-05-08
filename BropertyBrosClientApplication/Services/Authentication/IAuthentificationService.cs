namespace BropertyBrosClientApplication.Services.Authentication
{
    public interface IAuthentificationService
    {
        Task<bool> AuthenticateAsync(LoginUserDto loginModel);
        public Task Logout();
    }
}
