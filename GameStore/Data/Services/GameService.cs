namespace GameStore.Data.Services
{
    using AutoMapper;
    using GameStore.Data.Services.Interfaces;
    using GameStore.Models.GameViewModels;
    using GameStore.Data.Models;
    using IGDB;
    using GameStore.Models.IGDB;
    using IGDB.Models;

    public class GameService : IGameService
    {
        private readonly GameStoreDataDbContext _dbContext;
        private readonly IMapper _mapper;


        public GameService(GameStoreDataDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddGame(AddGameViewModel game)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GamesIGDBViewModel>> GetAllGames()
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

            //var model = IGDB.Models.Game();

            var igdbInfo = await igdb.QueryAsync<GamesIGDBViewModel>(IGDBClient.Endpoints.Games, query: "fields name, summary, screenshots, cover; limit 10;");
            var games = igdbInfo.ToList();


            for (int i = 0; i < games.Count; i++)
            {
                var game = games[i];
                var arrCover = game.Cover;
                var arrScreenshots = game.Screenshots;

                if (arrCover == null || arrScreenshots.Count == 0)
                {
                    games.Remove(game);
                    i--;
                }
                else
                {
                    var cover = await igdb.QueryAsync<IGDBCoverDetails>(IGDBClient.Endpoints.Covers, query: $"fields url; where id = ({string.Join(", ", game.Cover)});");

                    game.CoverUrl = cover[0];
                }
            }

            return games;
        }

        public async Task<DetailsViewModel> GetDetails(int id)
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

             var igdbInfo = await igdb.QueryAsync<DetailsViewModel>(IGDBClient.Endpoints.Games, query: $"fields *; where id = { id }; limit 10;");

            var details = igdbInfo.ToList()[0];

            var cover = await igdb.QueryAsync<IGDBCoverDetails>(IGDBClient.Endpoints.Covers, query: $"fields url; where id = ({string.Join(", ", details.Cover)});");
            var images = await igdb.QueryAsync<IGDBImagesDetails>(IGDBClient.Endpoints.Screenshots, query: $"fields url; where id = ({ string.Join(", ", details.Screenshots)});");
            var genres = await igdb.QueryAsync<IGDBGenreDetails>(IGDBClient.Endpoints.Genres, query: $"fields name, url; where id = ({string.Join(", ", details.Genres)});");
            var platform = await igdb.QueryAsync<IGDBPlatformsDetails>(IGDBClient.Endpoints.Platforms, query: $"fields name, url; where id = ({string.Join(", ", details.Platforms)});");
            var website = await igdb.QueryAsync<IGDBWebSiteDetails>(IGDBClient.Endpoints.Websites, query: $"fields category, url; where id = ({string.Join(", ", details.Websites)});");

            if (details.GameModes.Count != 0 ||
                details.Genres.Count != 0 ||
                details.Platforms.Count != 0 ||
                details.Websites.Count != 0)
            {
                var gameModels = await igdb.QueryAsync<IGDBGameModeDetails>(IGDBClient.Endpoints.GameModes, query: $"fields name, url; where id = ({string.Join(", ", details.GameModes)});");

                details.GameModesInfo.AddRange(gameModels);
                details.GenresInfo.AddRange(genres);
                details.PlatformsInfo.AddRange(platform);
                details.WebsitesInfo.AddRange(website);
            }

            details.Images.AddRange(images);
            details.CoverInfo = cover[0];

            return details;
        }

        public Task RemoveGame(AddGameViewModel game)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGame(AddGameViewModel game)
        {
            throw new NotImplementedException();
        }
    }
}