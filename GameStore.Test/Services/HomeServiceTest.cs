namespace GameStore.Test.Services
{
    using Moq;
    using Xunit;
    using AutoMapper;
    using FakeItEasy;
    using System.Web.Http;
    using GameStore.Models.IGDB;
    using GameStore.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using GameStore.Data.Services.Interfaces;
    using GameStore.Data.Models.Services;

    public class HomeServiceTest : ApiController
    {
        private Mock<IHomeService> _homeService;
        private readonly IMapper _mapper;

        public HomeServiceTest()
        {
            _homeService = new Mock<IHomeService>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public async Task RenderGamesMiddleCorrectly()
        {
            List<GamesIGDBViewModel> gameList = await GamesIGDB();
            _homeService.Setup(x => x.ReturnMiddleSiteOnPageGamesFromIGDB())
                .ReturnsAsync(gameList);
            var gameController = new HomeController(_homeService.Object);

            var gameResult = await gameController.RenderGamesMiddle();
            var gameResultModel = ((PartialViewResult)gameResult).Model as List<GamesIGDBViewModel>;

            Assert.Equal(gameList, gameResultModel);
        }

        [Fact]
        public async Task RenderMostAnticipatedGames()
        {
            List<GamesIGDBViewModel> gameList = await GamesIGDB();
            _homeService.Setup(x => x.ReturnMostAnticipatedGamesFromIGDB())
                .ReturnsAsync(gameList);
            var gameController = new HomeController(_homeService.Object);

            var gameResult = await gameController.RenderMostAnticipatedGames();
            var gameResultModel = ((PartialViewResult)gameResult).Model as List<GamesIGDBViewModel>;

            Assert.Equal(gameList, gameResultModel);
        }

        [Fact]
        public async Task RenderGamesDownRecentlyReleasedCorrectly()
        {
            List<GamesIGDBViewModel> gameList = await GamesIGDB();
            _homeService.Setup(x => x.ReturnRecentlyReleasedGamesFromIGDB())
                .ReturnsAsync(gameList);
            var gameController = new HomeController(_homeService.Object);

            var gameResult = await gameController.RenderGamesDownRecentlyReleased();
            var gameResultModel = ((PartialViewResult)gameResult).Model as List<GamesIGDBViewModel>;

            Assert.Equal(gameList, gameResultModel);
        }

        [Fact]
        public async Task RenderGamesDownComingSoon()
        {
            List<GamesIGDBViewModel> gameList = await GamesIGDB();
            _homeService.Setup(x => x.ReturnComingSoonGamesFromIGDB())
                .ReturnsAsync(gameList);
            var gameController = new HomeController(_homeService.Object);

            var gameResult = await gameController.RenderGamesDownComingSoon();
            var gameResultModel = ((PartialViewResult)gameResult).Model as List<GamesIGDBViewModel>;

            Assert.Equal(gameList, gameResultModel);
        }

        [Fact]
        public async Task RenderWholePageWithPartialsInIt()
        {
            List<GamesIGDBViewModel> gameList = await GamesIGDB();
            var gamesMapped = _mapper.Map<List<HomePageViewModel>>(gameList);
            
            _homeService.Setup(x => x.ReturnInfoFromIGDB())
                .ReturnsAsync(gamesMapped);
            var gameController = new HomeController(_homeService.Object);

            var gameResult = await gameController.Index();
            var gameResultModel = ((ViewResult)gameResult).Model as List<HomePageViewModel>;

            Assert.Equal(gamesMapped, gameResultModel);
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
    }
    
}
