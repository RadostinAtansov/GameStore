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

            var igdbInfo = await igdb.QueryAsync<GamesIGDBViewModel>(IGDBClient.Endpoints.Games, query: "fields name, summary, screenshots; limit 10;");
            List<GamesIGDBViewModel> games = igdbInfo.ToList();

            for (int i = 0; i < games.Count; i++)
            {
                var game = games[i];
                var arr = game.Screenshots;
                if (arr.Count == 0)
                {
                    games.Remove(game);
                    i--;
                }
                else
                {
                    //var igdbImages = await igdb.QueryAsync<IGDBImages>(IGDBClient.Endpoints.Screenshots, query: $"fields *; where id = ({string.Join(',', arr)});");
                    var igdbImages = await igdb.QueryAsync<IGDBImages>(IGDBClient.Endpoints.Screenshots, query: $"fields url; where id = ({arr[0]});");
                    game.Images = igdbImages[0];
                }
            }

            return games;
        }

        public async Task<DetailsViewModel> GetDetails(int id)
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

            var igdbInfo = await igdb.QueryAsync<DetailsViewModel>(IGDBClient.Endpoints.Games, query: $"fields *; where id = { id }; limit 10;");

            var details = igdbInfo.ToList()[0];

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