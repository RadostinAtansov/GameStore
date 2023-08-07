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
        Task<List<GamesIGDBViewModel>> GetAllGamesTopRated();
        Task<List<GamesIGDBViewModel>> GetAllGamesComingSoon();
        Task<List<GamesIGDBViewModel>> RecentlyReleasedGames();
        Task<List<GamesIGDBViewModel>> MostAnticipatedGames();
        Task<List<GamesIGDBViewModel>> SearchByName(string name);
        Task<List<GamesIGDBViewModel>> SearchByPlatform(string platformSearch);
        Task<List<GamesIGDBViewModel>> SearchByGenre(string searchByGenre);
    }
}