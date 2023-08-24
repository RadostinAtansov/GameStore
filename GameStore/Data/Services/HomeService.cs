namespace GameStore.Data.Services
{
    using IGDB;
    using GameStore.Models.IGDB;
    using GameStore.Data.Services.Interfaces;
    using System.Web.Mvc;

    public class HomeService : IHomeService
    {
        private readonly GameStoreDataDbContext _dbContext;

        public HomeService(GameStoreDataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GamesIGDBViewModel>> ReturnComingSoonGamesFromIGDB()
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

            //DateTimeOffset dateTime1 = new DateTime(2023, 01, 01, 13, 09, 14);
            DateTimeOffset dateTime1 = DateTime.UtcNow;
            DateTimeOffset dateTime2 = DateTime.UtcNow.AddDays(5);

            var dt1 = dateTime1.ToUnixTimeSeconds();
            var dt2 = dateTime2.ToUnixTimeSeconds();

            var releaseDate = await igdb.QueryAsync<IGDBReleaseDate>(IGDBClient.Endpoints.ReleaseDates, query: $"fields *; where date > {dt1} & date < {dt2}; limit 10;");

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

        public async Task<List<HomePageViewModel>> ReturnInfoFromIGDB()
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

            var igdbInfo = await igdb.QueryAsync<HomePageViewModel>(IGDBClient.Endpoints.Games, query: "fields name, cover, genres, rating; where rating > 99; limit 10;");

            var games = igdbInfo.ToList();


            for (int i = 0; i < games.Count; i++)
            {
                var game = games[i];
                var arrCover = game.Cover;

                int rating = Convert.ToInt32(game.Rating);
                game.Rating = rating;

                if (arrCover == null)
                {
                    games.Remove(game);
                    i--;
                }
                else
                {
                    var cover = await igdb.QueryAsync<IGDBCoverDetails>(IGDBClient.Endpoints.Covers, query: $"fields *; where id = ({string.Join(", ", game.Cover)});");

                    var genres = await igdb.QueryAsync<IGDBGenre>(IGDBClient.Endpoints.Genres, query: $"fields name, url; where id = ({game.Genres[0]});");

                    game.CoverUrl = cover[0];
                    game.GenresInfo.Add(genres[0]);
                }
            }

            return games;
        }

        public async Task<List<GamesIGDBViewModel>> ReturnRecentlyReleasedGamesFromIGDB()
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

            DateTimeOffset dateTime1 = DateTime.Now;

            var dt1 = dateTime1.ToUnixTimeSeconds();

            DateTimeOffset dateTime2 = DateTime.Now.AddDays(-5);

            var dt2 = dateTime2.ToUnixTimeSeconds();

            var releaseDate = await igdb.QueryAsync<IGDBReleaseDate>(IGDBClient.Endpoints.ReleaseDates, query: $"fields *; where date < {dt1} & date > {dt2}; limit 3;");

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

        public async Task<List<GamesIGDBViewModel>> ReturnMostAnticipatedGamesFromIGDB()
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

            //DateTimeOffset dateTime1 = DateTime.Now;

            //var dt1 = dateTime1.ToUnixTimeSeconds();

            DateTimeOffset dateTime2 = DateTime.Now.AddMonths(6);

            var dt2 = dateTime2.ToUnixTimeSeconds();

            var releaseDate = await igdb.QueryAsync<IGDBReleaseDate>(IGDBClient.Endpoints.ReleaseDates, query: $"fields *; where date > {dt2}; limit 3;");

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

        public async Task<List<GamesIGDBViewModel>> ReturnMiddleSiteOnPageGamesFromIGDB()
        {
            var igdb = new IGDBClient("dhs4qgav57pw3ry6ts1dhfgn5t33c0", "15yjgjhviddv2qppk5h7911ko33pbd");

            DateTimeOffset dateTime1 = DateTime.Now;

            var dt1 = dateTime1.ToUnixTimeSeconds();

            DateTimeOffset dateTime2 = DateTime.Now.AddDays(-5);

            var dt2 = dateTime2.ToUnixTimeSeconds();

            var releaseDate = await igdb.QueryAsync<IGDBReleaseDate>(IGDBClient.Endpoints.ReleaseDates, query: $"fields *; where date < {dt1} & date > {dt2}; limit 10;");

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
    }
}