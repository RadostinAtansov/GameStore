namespace GameStore.Data.Services
{
    using IGDB;
    using AutoMapper;
    using GameStore.Models.IGDB;
    using GameStore.Models.GameViewModels;
    using GameStore.Data.Services.Interfaces;
    using System.Collections.Generic;
    using System;
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

        public async Task<List<GamesIGDBViewModel>> GetAllGames()
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

            //var model = IGDB.Models.Game();

            var igdbInfo = await igdb.QueryAsync<GamesIGDBViewModel>(IGDBClient.Endpoints.Games, query: "fields name, summary, screenshots, cover, genres, rating, platforms; where rating > 0 & platforms != 0 & cover != 0; limit 5;");

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

        public async Task<List<GamesIGDBViewModel>> GetAllGamesComingSoon()
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

            //DateTimeOffset dateTime1 = new DateTime(2023, 01, 01, 13, 09, 14);
            DateTimeOffset dateTime1 =  DateTime.UtcNow;
            DateTimeOffset dateTime2 =  DateTime.UtcNow.AddMonths(1);

            var dt1 = dateTime1.ToUnixTimeSeconds();
            var dt2 = dateTime2.ToUnixTimeSeconds();

            var releaseDate = await igdb.QueryAsync<IGDBReleaseDate>(IGDBClient.Endpoints.ReleaseDates, query: $"fields *; where date > {dt1} & date < {dt2}; limit 10;");

            var gamesId = new List<int>();

            for (int i = 0; i < releaseDate.Length; i++)
            {
                gamesId.Add(releaseDate[i].Game);
            }

            var igdbInfo = await igdb.QueryAsync<GamesIGDBViewModel>(IGDBClient.Endpoints.Games, query: $"fields *; where id = ({ string.Join(", ", gamesId) });");
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
                    var platform = await igdb.QueryAsync<IGDBPlatformsDetails>(IGDBClient.Endpoints.Platforms, query: $"fields name, url; where id = ({string.Join(", ", game.Platforms)});");
                    var releaseDate2 = await igdb.QueryAsync<IGDBReleaseDate>(IGDBClient.Endpoints.ReleaseDates, query: $"fields *; where id = ({string.Join(", ", game.ReleaseDates)});");


                    game.CoverUrl = cover[0];
                    game.GenresInfo.AddRange(genres);
                    game.PlatformsInfo.AddRange(platform);
                    game.ReleaseDateInfo.AddRange(releaseDate2);
                }
            }

            return games;
        }

        public async Task<List<GamesIGDBViewModel>> GetAllGamesTopRated()
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

            var igdbInfo = await igdb.QueryAsync<GamesIGDBViewModel>(IGDBClient.Endpoints.Games, query: "fields name, summary, screenshots, cover, genres, rating, platforms; where rating > 99 & platforms != 0 & cover != 0; limit 20;");

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
                    var platform = await igdb.QueryAsync<IGDBPlatformsDetails>(IGDBClient.Endpoints.Platforms, query: $"fields name, url; where id = ({string.Join(", ", game.Platforms)});");

                    game.CoverUrl = cover[0];
                    game.GenresInfo.AddRange(genres);
                    game.PlatformsInfo.AddRange(platform);
                }
            }

            return games;
        }

        public async Task<DetailsViewModel> GetDetails(int id)
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

             var igdbInfo = await igdb.QueryAsync<DetailsViewModel>(IGDBClient.Endpoints.Games, query: $"fields *; where id = { id }; limit 5;");

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

        public async Task<List<GamesIGDBViewModel>> RecentlyReleasedGames()
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

            DateTimeOffset dateTime1 = DateTime.Now;

            var dt1 = dateTime1.ToUnixTimeSeconds();

            DateTimeOffset dateTime2 = DateTime.Now.AddDays(-3);

            var dt2 = dateTime2.ToUnixTimeSeconds();

            var releaseDate = await igdb.QueryAsync<IGDBReleaseDate>(IGDBClient.Endpoints.ReleaseDates, query: $"fields *; where date < { dt1 } & date > { dt2 }; limit 5;");

            var gamesId = new List<int>();

            for (int i = 0; i < releaseDate.Length; i++)
            {
                gamesId.Add(releaseDate[i].Game);
            }

            var igdbInfo = await igdb.QueryAsync<GamesIGDBViewModel>(IGDBClient.Endpoints.Games, query: $"fields *; where id = ({string.Join(", ", gamesId)});");
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
                    var platform = await igdb.QueryAsync<IGDBPlatformsDetails>(IGDBClient.Endpoints.Platforms, query: $"fields name, url; where id = ({string.Join(", ", game.Platforms)});");
                    var releaseDate2 = await igdb.QueryAsync<IGDBReleaseDate>(IGDBClient.Endpoints.ReleaseDates, query: $"fields *; where id = ({string.Join(", ", game.ReleaseDates)});");


                    game.CoverUrl = cover[0];
                    game.GenresInfo.AddRange(genres);
                    game.PlatformsInfo.AddRange(platform);
                    game.ReleaseDateInfo.AddRange(releaseDate2);
                }
            }

            return games;
        }

        public async Task<List<GamesIGDBViewModel>> MostAnticipatedGames()
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

            DateTimeOffset dateTime1 = DateTime.Now;

            var dt1 = dateTime1.ToUnixTimeSeconds();

            var releaseDate = await igdb.QueryAsync<IGDBReleaseDate>(IGDBClient.Endpoints.ReleaseDates, query: $"fields *; where date > { dt1 }; limit 5;");

            var gamesId = new List<int>();

            for (int i = 0; i < releaseDate.Length; i++)
            {
                gamesId.Add(releaseDate[i].Game);
            }

            var igdbInfo = await igdb.QueryAsync<GamesIGDBViewModel>(IGDBClient.Endpoints.Games, query: $"fields *; where id = ({string.Join(", ", gamesId)});");
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
                    var platform = await igdb.QueryAsync<IGDBPlatformsDetails>(IGDBClient.Endpoints.Platforms, query: $"fields name, url; where id = ({string.Join(", ", game.Platforms)});");
                    var releaseDate2 = await igdb.QueryAsync<IGDBReleaseDate>(IGDBClient.Endpoints.ReleaseDates, query: $"fields *; where id = ({string.Join(", ", game.ReleaseDates)});");


                    game.CoverUrl = cover[0];
                    game.GenresInfo.AddRange(genres);
                    game.PlatformsInfo.AddRange(platform);
                    game.ReleaseDateInfo.AddRange(releaseDate2);
                }
            }

            return games;
        }

        public async Task<List<GamesIGDBViewModel>> SearchByName(string searchByName)
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

            var igdbInfo = await igdb.QueryAsync<GamesIGDBViewModel>(IGDBClient.Endpoints.Games, query: $"search \"{ searchByName }\"; fields name, *;");
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
                    var platform = await igdb.QueryAsync<IGDBPlatformsDetails>(IGDBClient.Endpoints.Platforms, query: $"fields name, url; where id = ({string.Join(", ", game.Platforms)});");
                    var releaseDate2 = await igdb.QueryAsync<IGDBReleaseDate>(IGDBClient.Endpoints.ReleaseDates, query: $"fields *; where id = ({string.Join(", ", game.ReleaseDates)});");


                    game.CoverUrl = cover[0];
                    game.GenresInfo.AddRange(genres);
                    game.PlatformsInfo.AddRange(platform);
                    game.ReleaseDateInfo.AddRange(releaseDate2);
                }
            }

            return games;
        }

        public async Task<List<GamesIGDBViewModel>> SearchByPlatform(string platformSearch)
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

            var igdbInfo = await igdb.QueryAsync<GamesIGDBViewModel>(IGDBClient.Endpoints.Games, query: $"fields *; where platforms.name = \"{ platformSearch }\"; limit 5;");
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
                    var platform = await igdb.QueryAsync<IGDBPlatformsDetails>(IGDBClient.Endpoints.Platforms, query: $"fields name, url; where id = ({string.Join(", ", game.Platforms)});");
                    var releaseDate2 = await igdb.QueryAsync<IGDBReleaseDate>(IGDBClient.Endpoints.ReleaseDates, query: $"fields *; where id = ({string.Join(", ", game.ReleaseDates)});");


                    game.CoverUrl = cover[0];
                    game.GenresInfo.AddRange(genres);
                    game.PlatformsInfo.AddRange(platform);
                    game.ReleaseDateInfo.AddRange(releaseDate2);
                }
            }

            return games;
        }

        public async Task<List<GamesIGDBViewModel>> SearchByGenre(string searchByGenres)
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

            var igdbInfo = await igdb.QueryAsync<GamesIGDBViewModel>(IGDBClient.Endpoints.Games, query: $"fields *; where genres.name = \"{ searchByGenres }\"; limit 5;");
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
                    var platform = await igdb.QueryAsync<IGDBPlatformsDetails>(IGDBClient.Endpoints.Platforms, query: $"fields name, url; where id = ({string.Join(", ", game.Platforms)});");
                    var releaseDate2 = await igdb.QueryAsync<IGDBReleaseDate>(IGDBClient.Endpoints.ReleaseDates, query: $"fields *; where id = ({string.Join(", ", game.ReleaseDates)});");


                    game.CoverUrl = cover[0];
                    game.GenresInfo.AddRange(genres);
                    game.PlatformsInfo.AddRange(platform);
                    game.ReleaseDateInfo.AddRange(releaseDate2);
                }
            }

            return games;
        }

        public async Task<List<PlatformsViewModel>> ReturnAllPlatform()
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

            //var igdbInfo = await igdb.QueryAsync<PlatformsViewModel>(IGDBClient.Endpoints.Games, query: $"fields *; where genres.name; limit 5;");
            //var games = igdbInfo.ToList();

            //for (int i = 0; i < games.Count; i++)
            //{
            //    var game = games[i];
            //    var arrCover = game.Cover;
            //    var arrScreenshots = game.Screenshots;
            //    var arrGenres = game.Genres;
            //    var arrPlatforms = game.Platforms;

            //    int rating = Convert.ToInt32(game.Rating);
            //    game.Rating = rating;

            //    if (arrCover == null ||
            //        arrScreenshots.Count == 0 ||
            //        arrGenres.Count == 0 ||
            //        arrPlatforms.Count == 0)
            //    {
            //        games.Remove(game);
            //        i--;
            //    }
            //    else
            //    {
            //        var cover = await igdb.QueryAsync<IGDBCoverDetails>(IGDBClient.Endpoints.Covers, query: $"fields *; where id = ({string.Join(", ", game.Cover)});");
            //        var genres = await igdb.QueryAsync<IGDBGenre>(IGDBClient.Endpoints.Genres, query: $"fields name; where id = ({string.Join(", ", game.Genres)});");
            //        var platform = await igdb.QueryAsync<IGDBPlatformsDetails>(IGDBClient.Endpoints.Platforms, query: $"fields name, url; where id = ({string.Join(", ", game.Platforms)});");
            //        var releaseDate2 = await igdb.QueryAsync<IGDBReleaseDate>(IGDBClient.Endpoints.ReleaseDates, query: $"fields *; where id = ({string.Join(", ", game.ReleaseDates)});");


            //        game.CoverUrl = cover[0];
            //        game.GenresInfo.AddRange(genres);
            //        game.PlatformsInfo.AddRange(platform);
            //        game.ReleaseDateInfo.AddRange(releaseDate2);
            //    }
            //}

            // return games;
            return new List<PlatformsViewModel>();
        }

        public Task RemoveGame(AddGameViewModel game)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGame(AddGameViewModel game)
        {
            throw new NotImplementedException();
        }

        public async Task AddGame(AddGameViewModel game)
        {
            throw new NotImplementedException();
        }
    }
}