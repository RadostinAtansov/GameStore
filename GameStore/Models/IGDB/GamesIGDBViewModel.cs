using IGDB.Models;
using Newtonsoft.Json;
using System.ComponentModel;

namespace GameStore.Models.IGDB
{
    public class GamesIGDBViewModel
    {

        public long Id { get; set; }

        [DisplayName("Game Name")]
        public string Name { get; set; }

        public int? Cover { get; set; }
        public IGDBCoverDetails? CoverUrl { get; set; }

        [DisplayName("Desription")]
        public string Summary { get; set; }

        public string Storyline { get; set; }

        public List<int> Screenshots = new List<int>();

        public IGDBImages Images { get; set; }
    }

    public class IGDBImages
    {
        [DisplayName("Screenshots")]
        public string Url { get; set; }
    }

    public class IGDBCoverDetails
    {
        [DisplayName("Screenshots")]
        public string Url { get; set; }
    }
}