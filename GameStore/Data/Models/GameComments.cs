namespace GameStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class GameComments
    {
        [Key]
        public int GameId { get; set; }
        //[ForeignKey("Game")]
        public virtual Game Game { get; set; }

       // [Key]
        public int CommentId { get; set; }
       // [ForeignKey("Comment")]
        public virtual Comment Comment { get; set; }
    }
}
