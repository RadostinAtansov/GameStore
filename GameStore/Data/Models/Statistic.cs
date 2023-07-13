namespace GameStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataValidation.StatisticDataValidation;

    public class Statistic
    {
        [Key]
        public int Id { get; set; }

        [Range(typeof(double), MinNumber, MaxNumber)]
        public double AverageRate { get; set; }

        [Range(typeof(int), MinNumber, MaxNumber)]
        public int Likes { get; set; }

        [Range(typeof(int), MinNumber, MaxNumber)]
        public int HowManyTimeIsBoughtThisGame { get; set; }

        [Required(ErrorMessage = MessageWhoBoughtThisGameRequired)]
        [StringLength(MaxLengthWhoBoughtThisGame, MinimumLength = MinLengthWhoBoughtThisGame, ErrorMessage = MessageWhoBoughtThisGame)]
        public string WhoBoughtThisGame { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}