namespace GameStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataValidation.UserDataValidation;

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = MessageUsername)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = MessageUsername)]
        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public Byte[] PasswordSalt { get; set; }

        public string Role { get; set; }

        public virtual ICollection<UsersGames> Games_Users { get; set; }
    }
}