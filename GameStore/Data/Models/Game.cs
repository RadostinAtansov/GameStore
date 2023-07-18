namespace GameStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataValidation.GameDataValidation;

    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = MessageRequiredGameName)]
        [StringLength(MaxLengthGameName, MinimumLength = MinLengthGameName, ErrorMessage = MessageGameName)]
        public string Name { get; set; }

        [Required(ErrorMessage = MessageRequiredDescriptionName)]
        [StringLength(MaxLengthGameDescription, MinimumLength = MinLengthGameDescription, ErrorMessage = MessageGameDescription)]
        public string Description { get; set; }

        [Required(ErrorMessage = MessageRequiredCategoryName)]
        public string Category { get; set; }

        [Range(typeof(Decimal), MinPrice, MaxPrice)]
        [Required(ErrorMessage = MessageRequiredPriceName)]
        public decimal Price { get; set; }

        [StringLength(MaxLengthGameCompany, MinimumLength = MinLengthGameCompany, ErrorMessage = MessageGameCompany)]
        [Required(ErrorMessage = MessageRequiredCompanyName)]
        public string Company { get; set; }

        [Url]
        public string VideoURL { get; set; }

        public virtual ICollection<UsersGames> Users_Games{ get; set; }
        public virtual ICollection<GameComments> Comments_Game{ get; set; }
        public virtual ICollection<Image> Images { get; set; }

        public int StatisticId { get; set; }
        public virtual Statistic Statistic { get; set; }
    }
}