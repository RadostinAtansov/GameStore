namespace GameStore.Models.IGDB
{
    public class HomePageViewModel
    {
        public string Name { get; set; }

        public int? Cover { get; set; }
        public IGDBCoverDetails? CoverUrl { get; set; }

        public List<int> Genres = new();
        public List<IGDBGenre> GenresInfo = new();

        public double? TotalRating { get; set; }
        public int? TotalRatingCount { get; set; }
        public double? AggregatedRating { get; set; }
        public int? AggregatedRatingCount { get; set; }
        public double? Rating { get; set; }
        public int? RatingCount { get; set; }
    }

    public class IGDBGenre
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }
}