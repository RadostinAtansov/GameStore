using System.ComponentModel.DataAnnotations;

namespace GameStore.Data.Models
{
    public class GameComments
    {
        [Key]
        public int Id { get; set; }

        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
