namespace GameStore.Data
{
    using GameStore.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class GameStoreDataDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {

        public GameStoreDataDbContext(DbContextOptions<GameStoreDataDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            //Game <=> Image one to many

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Game)
                .WithMany(g => g.Images)
                .HasForeignKey(i => i.GameId);

            ////Game <=> Statistic many to one

            modelBuilder.Entity<Game>()
                .HasOne(p => p.Statistic)
                .WithMany(p => p.Games)
                .HasForeignKey(k => k.StatisticId);








            //Games <=> User

            modelBuilder.Entity<UserGames_GamesUser>()
                .HasKey(gu => new { gu.UserId, gu.GameId });

            modelBuilder.Entity<UserGames_GamesUser>()
                .HasOne(s => s.ApplicationUser)
                .WithMany(s => s.UserGames)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<UserGames_GamesUser>()
                .HasOne(p => p.Game)
                .WithMany(p => p.GamesUser)
                .HasForeignKey(k => k.GameId);

            //modelBuilder.Entity<ApplicationUser>().ToTable("User");
            //modelBuilder.Entity<ApplicationUser>().Property(u => u.Id).HasColumnName("UserId");

        }

        public DbSet<UserGames_GamesUser> UserGames_GamesUsers{ get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameComments> GamesComments { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
