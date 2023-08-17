namespace GameStore.Data.Services.Interfaces
{
    using GameStore.Models.GameViewModels;
    using GameStore.Models.IGDB;

    public interface IGameService
    {
        Task AddGame(AddGameViewModel game);
        Task RemoveGame(AddGameViewModel game);
        Task UpdateGame(AddGameViewModel game);
        Task<DetailsViewModel> GetDetails(int id);
        Task<List<GamesIGDBViewModel>> GetAllGames();
        Task<List<PlatformsViewModel>> ReturnAllPlatform();
        Task<List<GamesIGDBViewModel>> GetAllGamesTopRated();
        Task<List<GamesIGDBViewModel>> MostAnticipatedGames();
        Task<List<GamesIGDBViewModel>> GetAllGamesComingSoon();
        Task<List<GamesIGDBViewModel>> RecentlyReleasedGames();
        Task<List<GamesIGDBViewModel>> SearchByName(string name);
        Task<PlatformDetailsViewModel> ReturnPlatformDetails(int id);
        Task<List<GamesIGDBViewModel>> SearchByGenre(string searchByGenre);
        Task<List<GamesIGDBViewModel>> SearchByPlatform(string platformSearch);
    }
}