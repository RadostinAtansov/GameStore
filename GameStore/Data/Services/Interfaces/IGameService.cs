namespace GameStore.Data.Services.Interfaces
{
    using GameStore.Models.GameViewModels;
    using GameStore.Models.IGDB;

    public interface IGameService
    {
        Task<DetailsViewModel> GetDetails(int id);
        Task AddGame(AddGameViewModel game);
        Task RemoveGame(AddGameViewModel game);
        Task UpdateGame(AddGameViewModel game);
        Task<List<GamesIGDBViewModel>> GetAllGames();
    }
}