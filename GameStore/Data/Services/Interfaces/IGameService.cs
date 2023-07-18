namespace GameStore.Data.Services.Interfaces
{
    using GameStore.Models.GameViewModels;

    public interface IGameService
    {
        Task GetGameById(int id);
        Task AddGame(AddGameViewModel game);
        Task RemoveGame(AddGameViewModel game);
        Task UpdateGame(AddGameViewModel game);
        Task<List<AddGameViewModel>> GetAllGames();
    }
}