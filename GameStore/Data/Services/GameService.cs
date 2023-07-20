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
            // var addgame = _mapper.Map<Game>(game);

            //var gameAdd = new Game()
            //{
            //    Id = game.Id,
            //    Name = game.Name,
            //    Category = game.Category,
            //    Price = game.Price,
            //    Company = game.Company,
            //    VideoURL = game.VideoURL,
            //    Description = game.Description,
            //    Statistic = new Statistic()
            //    {
            //        Id = game.Id,
            //    }
            //};

            //await _dbContext.Games.AddAsync(gameAdd);
            //await _dbContext.SaveChangesAsync();
        }

        public async Task<List<GamesIGDBViewModel>> GetAllGames()
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

            var igdbInfo = await igdb.QueryAsync<GamesIGDBViewModel>(IGDBClient.Endpoints.Games, query: "fields *; limit 10;");
            var igdbImages = await igdb.QueryAsync<IGDBImages>(IGDBClient.Endpoints.Screenshots, query: "fields *; limit 10;");



            List<GamesIGDBViewModel> games = igdbInfo.ToList();
            List<IGDBImages> images = igdbImages.ToList();

            for (int i = 0; i < games.Count; i++)
            {
                games[i].Images.Add(images[i]);
            }

            return games;
        }

        public Task GetGameById(int id)
        {
            throw new NotImplementedException();
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