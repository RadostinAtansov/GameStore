namespace GameStore.Models.IGDB
{
    public class DetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Summary { get; set; }

        public List<int> Screenshots = new List<int>();

        public List<int> Artworks = new List<int>();

        public int Cover { get; set; }

        public int Collection { get; set; }

        public List<int> GameEngines = new List<int>();

        public List<int> GameModes = new List<int>();

        public List<int> Genres = new List<int>();

        public List<int> InvolvedCompanies = new List<int>();

        public List<int> MultiplayerModes = new List<int>();

        public List<int> Platforms = new List<int>();

        public List<int> PlayerPerspectives = new List<int>();

        public List<int> Themes = new List<int>();

        public List<int> Videos = new List<int>();

        public List<int> ReleaseDates = new List<int>();

        public List<int> Websites = new List<int>();
    }
}