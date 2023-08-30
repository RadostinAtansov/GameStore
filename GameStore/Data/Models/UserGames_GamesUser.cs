namespace GameStore.Data.Models
{
    public class UserGames_GamesUser
    {
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}