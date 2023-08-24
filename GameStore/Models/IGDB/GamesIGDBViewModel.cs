    
namespace GameStore.Models.IGDB
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel;

    public class GamesIGDBViewModel
    {
        public long Id { get; set; }

        [DisplayName("Game Name")]
        public string Name { get; set; }

        public int? Cover { get; set; }
        public IGDBCoverDetails? CoverUrl { get; set; }

        public double? Rating { get; set; }

        public List<int> ReleaseDates = new();

        public List<IGDBReleaseDate> ReleaseDateInfo = new();

        [DisplayName("Desription")]
        public string Summary { get; set; }

        public string Storyline { get; set; }

        public List<int> Screenshots = new List<int>();
        public IGDBImages Images { get; set; }

        public List<int> Genres = new();
        public List<IGDBGenre> GenresInfo = new();


        public List<int> Platforms = new();
        public List<IGDBPlatformsDetails> PlatformsInfo = new();
    }

    [Keyless]
    public class IGDBImages
    {
        public string Url { get; set; }
    }

    [Keyless]
    public class IGDBCoverDetails
    {
        public int id { get; set; }

        public string imageId { get; set; }

        public string Url { get; set; }
    }

    [Keyless]
    public class IGDBReleaseDate
    {
        public ReleaseDateRegion? Region { get; set; }
        public DateTimeOffset? Date { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public int Game { get; set; }
    }
        public enum ReleaseDateRegion
        {
            Europe = 1,
            NorthAmerica = 2,
            Australia = 3,
            NewZealand = 4,
            Japan = 5,
            China = 6,
            Asia = 7,
            Worldwide = 8,
            Korea = 9,
            Brazil = 10
        }
}