namespace GameStore.Data.Services
{
    using IGDB;
    using GameStore.Models.IGDB;
    using System.Threading.Tasks;
    using GameStore.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using GameStore.Data.Services.Interfaces;

    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly GameStoreDataDbContext _dbContext;


        public AccountService(UserManager<IdentityUser> userManager,
                            SignInManager<IdentityUser> signInManager,
                            GameStoreDataDbContext dbContext)
        {    
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task RemoveGame(int id, string username)
        {
            var loggedUser = _dbContext.Users.Where(u => u.UserName == username).FirstOrDefault();

            var wishListUser = _dbContext.UserGames_GamesUsers
               .Where(u => u.UserId == loggedUser.Id)
               .Select(a => a.Game.Id)
               .ToList();

            var gamesThisUserFromDB = _dbContext.Games
                .Where(g => wishListUser.Contains(g.Id))
                .Select(a => new Game
                {
                    Id = a.Id,
                    GameIdFromIGDB = a.GameIdFromIGDB,
                })
                .ToList();

            List<int> gameIds = new List<int>();
            int idForRemove = 0;
            Game game = new();

            for (int i = 0; i < wishListUser.Count; i++)
            {
                if (id == gamesThisUserFromDB[i].GameIdFromIGDB)
                {
                    game.Id = gamesThisUserFromDB[i].Id;
                    game.GameIdFromIGDB = gamesThisUserFromDB[i].GameIdFromIGDB;
                    break;
                }
            }

            UserGames_GamesUser uggu = new UserGames_GamesUser() 
            { 
                GameId = game.Id, 
                UserId = loggedUser.Id,
            };

            _dbContext.UserGames_GamesUsers.Remove(uggu);
            _dbContext.SaveChanges();

        }

        public async Task<ICollection<GamesIGDBViewModel>> ShowWishList(string userNameEmail)
        {

            var loggedUser = _dbContext.Users.Where(u => u.UserName == userNameEmail).FirstOrDefault();

            var wishListUser = _dbContext.UserGames_GamesUsers
                .Where(u => u.UserId == loggedUser.Id)
                .Select(a => a.Game.Id)
                .ToList();

            var gamesThisUserFromDB = _dbContext.Games
                .Where(g => wishListUser.Contains(g.Id))
                .Select(a => new Game
                {
                     GameIdFromIGDB = a.GameIdFromIGDB,
                })
                .ToList();

            List<int> gameIds = new List<int>();

            for ( int i = 0; i < wishListUser.Count; i++)
            {
                gameIds.Add(gamesThisUserFromDB[i].GameIdFromIGDB);
            }

            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

            if (gameIds.Count == 0)
            {
                return new List<GamesIGDBViewModel>();
            }

            var igdbInfo = await igdb.QueryAsync<GamesIGDBViewModel>(IGDBClient.Endpoints.Games, query: $"fields *; where id = ({string.Join(",", gameIds)});");

            var games = igdbInfo.ToList();

            for (int i = 0; i < games.Count; i++)
            {
                var game = games[i];
                var arrCover = game.Cover;
                var arrScreenshots = game.Screenshots;
                var arrGenres = game.Genres;
                var arrPlatforms = game.Platforms;

                int rating = Convert.ToInt32(game.Rating);
                game.Rating = rating;

                if (arrCover == null ||
                    arrScreenshots.Count == 0 ||
                    arrGenres.Count == 0 ||
                    arrPlatforms.Count == 0)
                {
                    games.Remove(game);
                    i--;
                }
                else
                {
                    var cover = await igdb.QueryAsync<IGDBCoverDetails>(IGDBClient.Endpoints.Covers, query: $"fields *; where id = ({string.Join(", ", game.Cover)});");
                    var genres = await igdb.QueryAsync<IGDBGenre>(IGDBClient.Endpoints.Genres, query: $"fields name; where id = ({string.Join(", ", game.Genres)});");
                    var platform = await igdb.QueryAsync<IGDBPlatformsDetails>(IGDBClient.Endpoints.Platforms, query: $"fields name; where id = ({string.Join(", ", game.Platforms)});");

                    game.CoverUrl = cover[0];
                    game.GenresInfo.AddRange(genres);
                    game.PlatformsInfo.AddRange(platform);
                }
            }

            return games;
        }
    }
}
