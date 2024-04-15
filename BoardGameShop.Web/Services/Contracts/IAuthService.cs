﻿namespace BoardGameShop.Web.Services.Contracts
{
    public interface IAuthService
    {
        Task Login(UserLoginDto userLoginDto);
        Task Registration(UserRegistrationDto userRegistrationDto);
        Task Logout();
        Task<UserUpdateDto> GetUserData();
        Task UpdateUser(UserUpdateDto userUpdateDto);
    }
}
