
namespace GameStore.Models.IGDB
{
    using IGDB;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel;

    public class DetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Summary { get; set; }

        public int Follows { get; set; }

        public int Hypes { get; set; }

        public double Rating { get; set; }

        public GameStatus Status { get; set; }

        public string Storyline { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public string Url { get; set; }

        public DateTimeOffset FirstReleaseDate { get; set; }

        public List<int> GameEngines = new();
        public List<IGDBGameEngine> GameEnginesInfo = new();

        public List<int> Screenshots = new();
        public List<string> ScreenshotsInfo = new();

        public List<int> GameModes = new();
        public List<IGDBGameModeDetails> GameModesInfo = new();

        public int? Cover { get; set; }
        public IGDBCoverDetails CoverInfo { get; set; }

        public List<int> Genres = new();
        public List<IGDBGenreDetails> GenresInfo = new();

        public List<int> PlayerPerspectives { get; set; }
        public List<IGDBPlayerPerspective> PlayerPerspectiveInfo { get; set; }

        public List<int> Platforms = new();
        public List<IGDBPlatformsDetails> PlatformsInfo = new();

        public List<int> Websites = new();
        public List<IGDBWebSiteDetails> WebsitesInfo = new();

        public List<int> Videos = new();
        public List<IGDBVideosDetails> VideosInfo = new();

        public List<int> ReleaseDates = new();
        public List<IGDBReleaseDate> ReleaseDatesInfo = new();
    }

    [Keyless]
    public class IGDBPlayerPerspective
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [Keyless]
    public class IGDBGameEngine
    {
        public string Name { get; set; }
    }

    public enum GameStatus
    {
        Released = 0,
        Alpha = 2,
        Beta = 3,
        EarlyAccess = 4,
        Offline = 5,
        Cancelled = 6,
        Rumored = 7,
        Delisted = 8
    }

    [Keyless]
    public class IGDBImagesDetails
    {
        public string imageId { get; set; }
    }

    [Keyless]
    public class IGDBEngineDetails
    {
        public string Name { get; set; }
    }

    [Keyless]
    public class IGDBGameModeDetails
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }

    [Keyless]
    public class IGDBGenreDetails
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }

    [Keyless]
    public class IGDBPlatformsDetails
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }

    [Keyless]
    public class IGDBVideosDetails
    {
        public string VideoId { get; set; }
    }

    [Keyless]
    public class IGDBReleaseDateDetails
    {
        public string Url { get; set; }
    }

    [Keyless]
    public class IGDBWebSiteDetails
    {
        public WebsiteCategory Category { get; set; }

        public string Url { get; set; }

        public enum WebsiteCategory
        {
            Official = 1,
            Wiki = 2,
            Wikipedia = 3,
            Facebook = 4,
            Twitter = 5,
            Twitch = 6,
            Instagram = 8,
            YouTube = 9,
            iPhone = 10,
            iPad = 11,
            Android = 12,
            Steam = 13,
            Reddit = 14,
            Itch = 15,
            EpicGames = 16,
            GOG = 17,
            Discord = 18
        }
    }
}