namespace GameStore.Data.Services.Interfaces
{
    using GameStore.Models.IGDB;

    public interface IAccountService
    {
        Task<ICollection<GamesIGDBViewModel>> ShowWishList(string userNameEmail);
        Task RemoveGame(int id, string usernameUser);
    }
}