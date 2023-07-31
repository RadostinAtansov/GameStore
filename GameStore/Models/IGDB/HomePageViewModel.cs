namespace GameStore.Models.IGDB
{
    public class HomePageViewModel
    {
        public string Name { get; set; }

        public int? Cover { get; set; }
        public IGDBCoverDetails? CoverUrl { get; set; }

        public List<int> Genres = new();
        public List<IGDBGenre> GenresInfo = new();
    }

    public class IGDBGenre
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }
}