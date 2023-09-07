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

    public class GameServiceTest : ApiController
    {
        private Mock<IGameService> _gameService;
        private readonly IMapper _mapper;

        public GameServiceTest()
        {
            _gameService = new Mock<IGameService>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public async Task GetAllGamesCorrectly()
        {
            List<GamesIGDBViewModel> gameList = await GamesIGDB();
            _gameService.Setup(x => x.GetAllGames())
                .ReturnsAsync(gameList);
            var gameController = new GameController(_gameService.Object);

            var gameResult = await gameController.ReturnAllGames();
            var gameResultModel = ((ViewResult)gameResult).Model as List<GamesIGDBViewModel>;

            Assert.Equal(gameList, gameResultModel);
        }

        [Fact]
        public async Task GetAllGamesThatComingSoonCorrectly()
        {
            List<GamesIGDBViewModel> gameList = await GamesIGDB();
            _gameService.Setup(x => x.GetAllGamesComingSoon())
                .ReturnsAsync(gameList);
            var gameController = new GameController(_gameService.Object);

            var gameResult = await gameController.ReturnAllComingSoonGames();
            var gameResultModel = ((ViewResult)gameResult).Model as List<GamesIGDBViewModel>;

            Assert.Equal(gameList, gameResultModel);
        }

        [Fact]
        public async Task GetAllTopRatedGamesCorrectly()
        {
            List<GamesIGDBViewModel> gameList = await GamesIGDB();
            _gameService.Setup(x => x.GetAllGamesTopRated())
                .ReturnsAsync(gameList);
            var gameController = new GameController(_gameService.Object);

            var gameResult = await gameController.ReturnAllTopRatedGames();
            var gameResultModel = ((ViewResult)gameResult).Model as List<GamesIGDBViewModel>;

            Assert.Equal(gameList, gameResultModel);
        }

        [Fact]
        public async Task GetGameDetailsCorrectly()
        {
            List<GamesIGDBViewModel> gameList = await GamesIGDB();
            int id = 1;
            var fakeGameDetails = new DetailsViewModel()
            {
                Id = 1,
                Name = "SuperMario",
                Cover = 123,
                Genres = new List<int> { 1, 2 },
                Platforms = new List<int> { 1, 2 },
                Rating = 100,
                Storyline = "aaaaaaaaa aaaa a aaaaaaaa aaaaa a aaaaaaaa",
                Screenshots = new List<int> { 1, 2 },
                ReleaseDates = new List<int> { 1, 2 },
                Summary = "bbbbbbbbbbbbb b b b b bbbbbb bbbbb bbbbbbb bbbbbbbbbbbbbb", 

            };

            _gameService.Setup(x => x.GetDetails(id))
                .ReturnsAsync(fakeGameDetails);
            var gameController = new GameController(_gameService.Object);

            var gameResult = await gameController.Details(id);
            var gameResultModel = ((ViewResult)gameResult).Model as DetailsViewModel;

            Assert.Equal(fakeGameDetails, gameResultModel);
        }

        [Fact]
        public async Task GetAllRecentlyReleasedGamesCorrectly()
        {
            List<GamesIGDBViewModel> gameList = await GamesIGDB();
            _gameService.Setup(x => x.RecentlyReleasedGames())
                .ReturnsAsync(gameList);
            var gameController = new GameController(_gameService.Object);

            var gameResult = await gameController.RecentlyReleasedGames();
            var gameResultModel = ((ViewResult)gameResult).Model as List<GamesIGDBViewModel>;

            Assert.Equal(gameList, gameResultModel);
        }

        [Fact]
        public async Task GetAllMostAnticipatedGamesCorrectly()
        {
            List<GamesIGDBViewModel> gameList = await GamesIGDB();
            _gameService.Setup(x => x.MostAnticipatedGames())
                .ReturnsAsync(gameList);
            var gameController = new GameController(_gameService.Object);

            var gameResult = await gameController.MostAnticipatedGames();
            var gameResultModel = ((ViewResult)gameResult).Model as List<GamesIGDBViewModel>;

            Assert.Equal(gameList, gameResultModel);
        }

        [Fact]
        public async Task SearchByNameWorkCorrectly()
        {
            List<GamesIGDBViewModel> gameList = await GamesIGDB();

            var fakeGame = new GamesIGDBViewModel()
            {
                Id = 1,
                Name = "SuperMario",
                Cover = 123,
                Genres = new List<int> { 1, 2 },
                Platforms = new List<int> { 1, 2 },
                Rating = 100,
                Storyline = "aaaaaaaaa aaaa a aaaaaaaa aaaaa a aaaaaaaa",
                Screenshots = new List<int> { 1, 2 },
                ReleaseDates = new List<int> { 1, 2 },
                Summary = "bbbbbbbbbbbbb b b b b bbbbbb bbbbb bbbbbbb bbbbbbbbbbbbbb",
                Images = new IGDBImages()
            };
            var searchName = "SuperMario";
            _gameService.Setup(x => x.SearchByName(searchName))
                .ReturnsAsync(gameList);
            var gameController = new GameController(_gameService.Object);

            var gameResult = await gameController.SearchByName(searchName);
            var gameResultModel = ((ViewResult)gameResult).Model as List<GamesIGDBViewModel>;

            Assert.Equal(fakeGame.Name, gameResultModel[0].Name);
        }

        [Fact]
        public async Task SearchByGenreWorkCorrectly()
        {
            List<GamesIGDBViewModel> gameList = await GamesIGDB();

            var fakeGame = new GamesIGDBViewModel()
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
            };
            var searchGenre = "action";
            _gameService.Setup(x => x.SearchByGenre(searchGenre))
                .ReturnsAsync(gameList);
            var gameController = new GameController(_gameService.Object);

            var gameResult = await gameController.SearchByGenre(searchGenre);
            var gameResultModel = ((ViewResult)gameResult).Model as List<GamesIGDBViewModel>;

            Assert.Equal(fakeGame.Id, gameResultModel[0].Id);
        }

        [Fact]
        public async Task SearchByPlatformWorkCorrectly()
        {
            List<GamesIGDBViewModel> gameList = await GamesIGDB();

            var fakeGame = new GamesIGDBViewModel()
            {
                Id = 2,
                Name = "CS",
                Cover = 123,
                Genres = new List<int> { 1, 2 },
                Platforms = new List<int> { 1, 2 },
                PlatformsInfo = new List<IGDBPlatformsDetails> { new IGDBPlatformsDetails { Name = "Xbox" } },
                Rating = 100,
                Storyline = "bbbbbbbbbbb aabbbbbbbbbbaa a aaabbbbaaaaa aaaaa a aaaaabbbbaaa",
                Screenshots = new List<int> { 1, 2 },
                ReleaseDates = new List<int> { 1, 2 },
                Summary = "bbbbbbbbbbbbb b b b b bbbbbb bbbbb bbbbbbb bbbbbbbbbbbbbb",
                Images = new IGDBImages()
            };
            var searchPlatform = "PS5";
            _gameService.Setup(x => x.SearchByPlatform(searchPlatform))
                .ReturnsAsync(gameList);
            var gameController = new GameController(_gameService.Object);

            var gameResult = await gameController.SearchByPlatform(searchPlatform);
            var gameResultModel = ((ViewResult)gameResult).Model as List<GamesIGDBViewModel>;

            Assert.Equal(fakeGame.Id, gameResultModel[1].Id);
        }

        [Fact]
        public async Task ReturnAllPlatformsCorrectly()
        {
            List<PlatformsViewModel> platformList = await GamesIGDBPlatforms();
            _gameService.Setup(x => x.ReturnAllPlatform())
                .ReturnsAsync(platformList);
            var gameController = new GameController(_gameService.Object);

            var gameResult = await gameController.ReturnAllPlatforms();
            var gameResultModel = ((ViewResult)gameResult).Model as List<PlatformsViewModel>;

            Assert.Equal(platformList, gameResultModel);
        }

        [Fact]
        public async Task ReturnPlatformsDetailsCorrectly()
        {
            List<PlatformDetailsViewModel> platformList = await GamesIGDBPlatformsDetails();

            var id = 1;

            var fakeDetailPlatform = new PlatformDetailsViewModel()
            {
                Id = 1,
                Name = "Xbox",
                Generation = 5,
            };

            _gameService.Setup(x => x.ReturnPlatformDetails(id))
            .ReturnsAsync(fakeDetailPlatform);
            var gameController = new GameController(_gameService.Object);

            var gameResult = await gameController.ReturnPlatform(id);
            var gameResultModel = ((ViewResult)gameResult).Model as PlatformDetailsViewModel;

            Assert.Equal(platformList[0].Name, fakeDetailPlatform.Name);
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

        private async Task<List<PlatformsViewModel>> GamesIGDBPlatforms()
        {
            List<PlatformsViewModel> PlatformList = new List<PlatformsViewModel>()
                {
                    new PlatformsViewModel()
                    {
                        Id = 1,
                        Name = "Xbox",
                    },
                    new PlatformsViewModel()
                    {
                         Id = 2,
                         Name = "PS2",
                    },
                    new PlatformsViewModel()
                    {
                         Id = 3,
                         Name = "PC",
                    },
                };
            return PlatformList;
        }

        private async Task<List<PlatformDetailsViewModel>> GamesIGDBPlatformsDetails()
        {
            List<PlatformDetailsViewModel> PlatformListDetails = new List<PlatformDetailsViewModel>()
                {
                    new PlatformDetailsViewModel()
                    {
                        Id = 1,
                        Name = "Xbox",
                        Generation = 5,
                    },
                    new PlatformDetailsViewModel()
                    {
                         Id = 2,
                         Name = "PS2",
                         Generation = 2,
                    },
                    new PlatformDetailsViewModel()
                    {
                         Id = 3,
                         Name = "PC",
                         Generation = 1,
                    },
                };

            return PlatformListDetails;
        }
    }
}