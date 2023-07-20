using Microsoft.EntityFrameworkCore;
using GameStore.Models.GameViewModels;
namespace GameStore.Data
{
    using GameStore.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class GameStoreDataDbContext : DbContext
    {

        public GameStoreDataDbContext(DbContextOptions<GameStoreDataDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Comments <=> Games many to many

            modelBuilder.Entity<GameComments>()
                .HasOne(g => g.Game)
                .WithMany(c => c.Comments_Game)
                .HasForeignKey(c => c.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GameComments>()
                .HasOne(c => c.Comment)
                .WithMany(g => g.Game_Comments)
                .HasForeignKey(c => c.CommentId)
                .OnDelete(DeleteBehavior.Cascade);

            //Games <=> User

            modelBuilder.Entity<UsersGames>()
                .HasOne(g => g.Game)
                .WithMany(c => c.Users_Games)
                .HasForeignKey(c => c.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UsersGames>()
                .HasOne(c => c.User)
                .WithMany(g => g.Games_Users)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //Game <=> Statistic many to one

            modelBuilder.Entity<Game>()
                .HasOne(s => s.Statistic)
                .WithMany(g => g.Games)
                .HasForeignKey(k => k.StatisticId)
                .OnDelete(DeleteBehavior.Cascade);

            //Game <=> Image one to many

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Game)
                .WithMany(g => g.Images)
                .HasForeignKey(i => i.GameId);
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameComments> GamesComments { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UsersGames> UsersGames { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<GameStore.Models.GameViewModels.ReturnAllGames>? ReturnAllGames { get; set; }
    }
}
