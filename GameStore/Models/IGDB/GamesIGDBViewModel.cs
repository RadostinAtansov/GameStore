    
namespace GameStore.Models.IGDB
{
    using System.ComponentModel;

    public class GamesIGDBViewModel
    {

        public long Id { get; set; }

        [DisplayName("Game Name")]
        public string Name { get; set; }

        public int? Cover { get; set; }
        public IGDBCoverDetails? CoverUrl { get; set; }

        public double? Rating { get; set; }

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

    public class IGDBImages
    {
        public string Url { get; set; }
    }

    public class IGDBCoverDetails
    {
        public string imageId { get; set; }

        public string Url { get; set; }
    }
}