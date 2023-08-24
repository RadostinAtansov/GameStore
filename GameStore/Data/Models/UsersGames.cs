using System.ComponentModel.DataAnnotations;

namespace GameStore.Data.Models
{
    public class UsersGames
    {
        [Key]
        public int Id { get; set; }

        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        //public int UserId { get; set; }
        //public virtual User User { get; set; }
    }
}