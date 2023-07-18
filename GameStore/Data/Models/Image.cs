namespace GameStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataValidation.ImageDataValidation;

    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = MessageRequireImage)]
        [StringLength(MaxLengthName, MinimumLength = MinLengthName, ErrorMessage = MessageLengthName)]
        public string Name { get; set; }

        [Required(ErrorMessage = MessageImageRequire)]
        public byte[] ImageData { get; set; }

        public int GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}