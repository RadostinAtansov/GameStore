namespace GameStore.Data.Services.Interfaces
{
    using GameStore.Models.UserModels;

    public interface IAuthorizationUserService
    {
        Task<UserViewModel> Login(UserViewModel userRequest);
        Task<LoginViewModel> Register(LoginViewModel userRequest);
    }
}