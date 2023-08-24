using Microsoft.EntityFrameworkCore;

namespace GameStore.Models.IGDB
{
    public class HomePageViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Cover { get; set; }
        public IGDBCoverDetails? CoverUrl { get; set; }

        public List<int> Genres = new();
        public List<IGDBGenre> GenresInfo = new();

        public double? Rating { get; set; }

    }

    [Keyless]
    public class IGDBGenre
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }
}