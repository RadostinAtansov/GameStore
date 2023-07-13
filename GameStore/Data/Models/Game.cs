namespace GameStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataValidation.GameDataValidation;

    public class Game
    {
        //[Key]
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

        public virtual ICollection<UsersGames> Users_Games{ get; set; }
        public virtual ICollection<GameComments> Comments_Game{ get; set; }

        [Key]
        public int StatisticId { get; set; }
        //[ForeignKey("Statistic")]
        public virtual Statistic Statistic { get; set; }
    }
}