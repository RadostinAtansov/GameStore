namespace GameStore.Data
{
    using Microsoft.EntityFrameworkCore;

    public class GameStoreDataDbContext : DbContext
    {

        public GameStoreDataDbContext(DbContextOptions<GameStoreDataDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


    }
}
