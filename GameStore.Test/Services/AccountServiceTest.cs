namespace GameStore.Test.Services
{
    using AutoMapper;
    using FakeItEasy;
    using GameStore.Controllers;
    using GameStore.Data;
    using GameStore.Data.Models;
    using GameStore.Data.Models.Services;
    using GameStore.Data.Services;
    using GameStore.Data.Services.Interfaces;
    using GameStore.Models.IGDB;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using System.Web.Mvc;
    using Xunit;

    public class AccountServiceTest
    {
        private Mock<IAccountService> _accountServices;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly GameStoreDataDbContext _dbContext;

        public AccountServiceTest()
        {
            _accountServices = new Mock<IAccountService>();
            _mapper = A.Fake<IMapper>();
        }


        [Fact]
        public async Task ShowWishListOfUserCorrectly()
        {
            List<GamesIGDBViewModel> gameList = await GamesIGDB();

            string user = "Admin";

            _accountServices.Setup(x => x.ShowWishList(user))
                .ReturnsAsync(gameList);

            var gameController = new AccountController(_dbContext,
                _userManager,
                _signInManager,
                _accountServices.Object);

            var gameResult = await gameController.ShowWishList();
            var gameResultModel = ((ViewResult)gameResult).Model as List<GamesIGDBViewModel>;

            Assert.Equal(gameList, gameResultModel);
        }

        private async Task<List<GamesIGDBViewModel>> GamesIGDB()
        {
            List<GamesIGDBViewModel> GameList = new List<GamesIGDBViewModel>()
                {
                    new GamesIGDBViewModel()
                    {
                        Id = 1,
                        Name = "SuperMario",
                        Cover = 123,
                        Genres = new List<int> { 1, 2 },
                        GenresInfo = new List<IGDBGenre> { new IGDBGenre() { Name = "action" } },
                        Platforms = new List<int> { 1, 2 },
                        Rating = 100,
                        Storyline = "aaaaaaaaa aaaa a aaaaaaaa aaaaa a aaaaaaaa",
                        Screenshots = new List<int> { 1, 2 },
                        ReleaseDates = new List<int> { 1, 2 },
                        Summary = "bbbbbbbbbbbbb b b b b bbbbbb bbbbb bbbbbbb bbbbbbbbbbbbbb",
                        Images = new IGDBImages()

                    },
                    new GamesIGDBViewModel()
                    {
                         Id = 2,
                         Name = "CS",
                         Cover = 123,
                         Genres = new List<int> { 1, 2 },
                         Platforms = new List<int>{ 1, 2 },
                         PlatformsInfo = new List<IGDBPlatformsDetails> { new IGDBPlatformsDetails { Name = "Xbox"} },
                         Rating = 100,
                         Storyline = "bbbbbbbbbbb aabbbbbbbbbbaa a aaabbbbaaaaa aaaaa a aaaaabbbbaaa",
                         Screenshots = new List<int>{ 1, 2 },
                         ReleaseDates = new List<int>{ 1, 2 },
                         Summary = "bbbbbbbbbbbbb b b b b bbbbbb bbbbb bbbbbbb bbbbbbbbbbbbbb",
                         Images = new IGDBImages()
                    },
                    new GamesIGDBViewModel()
                    {
                         Id = 3,
                         Name = "Mu",
                         Cover = 123,
                         Genres = new List<int> { 1, 2 },
                         Platforms = new List<int>{ 1, 2 },
                         Rating = 100,
                         Storyline = "ccccccc aaaa a aaaaaccccaaa aaaaa a aaaaaaccaa",
                         Screenshots = new List<int>{ 1, 2 },
                         ReleaseDates = new List<int>{ 1, 2 },
                         Summary = "bbbbbccccbbbbbbbb b b b b bbcccbbbb bbbbb bbbcbbb bbbbbbccbbbbbbbb",
                         Images = new IGDBImages()
                    },
                };
            return GameList;
        }

        private async Task<List<ApplicationUser>> UserData()
        {
            List<ApplicationUser> usersDb = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {             
                    Id = "1",
                    UserName = "Admin",
                    PasswordHash = "Admin123",
                    UserGames = new List<UserGames_GamesUser> 
                    { 
                        new UserGames_GamesUser { GameId = 1, UserId = "1" },
                        new UserGames_GamesUser { GameId = 2, UserId = "1" },
                        new UserGames_GamesUser { GameId = 3, UserId = "1" },
                    },  
                },
                new ApplicationUser()
                {
                    Id = "2",
                    UserName = "Metla",
                    PasswordHash = "Metla123",
                },
                new ApplicationUser()
                {
                    Id = "3",
                    UserName = "Tigan",
                    PasswordHash = "Tigan123",
                },
            };
            return usersDb;
        }
    }
}
