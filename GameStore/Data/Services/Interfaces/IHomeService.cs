namespace GameStore.Data.Services.Interfaces
{
    using GameStore.Models.IGDB;

    public interface IHomeService
    {
        Task<List<HomePageViewModel>> ReturnInfoFromIGDB();
        Task<List<GamesIGDBViewModel>> ReturnRecentlyReleasedGamesFromIGDB();
        Task<List<GamesIGDBViewModel>> ReturnComingSoonGamesFromIGDB();
        Task<List<GamesIGDBViewModel>> ReturnMostAnticipatedGamesFromIGDB();
    }
}