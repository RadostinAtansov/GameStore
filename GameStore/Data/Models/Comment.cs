namespace GameStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataValidation.CommentDataValidation;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = MessageTitleRequired)]
        [StringLength(MaxLengthComment, MinimumLength = MinLengthComment, ErrorMessage = MessageTitleComment)]
        public string Title { get; set; }

        [Required(ErrorMessage = MessageTextRequired)]
        [StringLength(MaxLengthText, MinimumLength = MinLengthText, ErrorMessage = MessageTextComment)]
        public string Text { get; set; }

        public DateTime WhenIsWrite { get; set; }

        public virtual ICollection<GameComments> Game_Comments { get; set; }
    }
}