using IGDB.Models;
using Newtonsoft.Json;
using System.ComponentModel;

namespace GameStore.Models.IGDB
{
    public class GamesIGDBViewModel
    {

        [DisplayName("Game Name")]
        public string Name { get; set; }

        [DisplayName("Desription")]
        public string Summary { get; set; }

        public List<IGDBImages> Images = new List<IGDBImages>();
    }

    public class IGDBImages
    {
        [DisplayName("Screenshots")]
        public string Url { get; set; }

        public int Hight { get; set; }

        public int Width { get; set; }
    }
}