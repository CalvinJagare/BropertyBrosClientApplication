﻿namespace BropertyBrosClientApplication.Services.Auth
{
    public interface IAuthService
    {
        Task<bool> AuthAsync(LoginUserDto loginModel);
        public Task Logout();
    }
}
