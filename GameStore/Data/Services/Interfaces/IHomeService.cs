namespace GameStore.Data.Services.Interfaces
{
    using GameStore.Models.IGDB;

    public interface IHomeService
    {
        Task<List<HomePageViewModel>> ReturnInfoFromIGDB();
    }
}