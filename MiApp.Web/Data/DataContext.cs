using Microsoft.EntityFrameworkCore;
using MiApp.Web.Data.Entities;

namespace MiApp.Web.Data
{
    public class DataContext : DbContext
    {

        #region Constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        #endregion

        public DbSet<ItemEntity> Items { get; set; }


        //Clave Unica para campo Name
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ItemEntity>()
                .HasIndex(t => t.Name)
                .IsUnique();
        }
    }
}
