namespace GameStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UsersGames
    {
        [Key]
        public int GameId { get; set; }
        [ForeignKey("Game")]
        public virtual Game Game { get; set; }

        [Key]
        public int UserId { get; set; }
        [ForeignKey("User")]
        public virtual User User { get; set; }
    }
}