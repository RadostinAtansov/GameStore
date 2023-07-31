namespace GameStore.Data.Services
{
    using IGDB;
    using GameStore.Models.IGDB;
    using GameStore.Data.Services.Interfaces;

    public class HomeService : IHomeService
    {
        private readonly GameStoreDataDbContext _dbContext;

        public HomeService(GameStoreDataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HomePageViewModel>> ReturnInfoFromIGDB()
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

            var igdbInfo = await igdb.QueryAsync<HomePageViewModel>(IGDBClient.Endpoints.Games, query: "fields name, cover, genres; limit 15;");

            var games = igdbInfo.ToList();


            for (int i = 0; i < games.Count; i++)
            {
                var game = games[i];
                var arrCover = game.Cover;


                if (arrCover == null)
                {
                    games.Remove(game);
                    i--;
                }
                else
                {
                    var cover = await igdb.QueryAsync<IGDBCoverDetails>(IGDBClient.Endpoints.Covers, query: $"fields url; where id = ({string.Join(", ", game.Cover)});");

                    var genres = await igdb.QueryAsync<IGDBGenre>(IGDBClient.Endpoints.Genres, query: $"fields name, url; where id = ({game.Genres[0]});");

                    game.CoverUrl = cover[0];
                    game.GenresInfo.Add(genres[0]);
                }
            }

            return games;
        }
    }
}