namespace GameStore.Data.Services
{
    using AutoMapper;
    using GameStore.Data.Services.Interfaces;
    using GameStore.Models.GameViewModels;
    using GameStore.Data.Models;

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

            var gameAdd = new Game()
            {
                Id = game.Id,
                Name = game.Name,
                Category = game.Category,
                Price = game.Price,
                Company = game.Company,
                VideoURL = game.VideoURL,
                Description = game.Description,
                Statistic = new Statistic()
                {
                    Id = game.Id,
                }
            };

            await _dbContext.Games.AddAsync(gameAdd);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<AddGameViewModel>> GetAllGames()
        {
            throw new NotImplementedException();
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