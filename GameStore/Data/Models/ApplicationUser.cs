namespace GameStore.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<UserGames_GamesUser> UserGames { get; set; }
    }
}