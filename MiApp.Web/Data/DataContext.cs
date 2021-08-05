using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiApp.Web.Data.Entities;

namespace MiApp.Web.Data
{
    public class DataContext : IdentityDbContext<UserEntity>
    {

        #region Constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        #endregion

        public DbSet<ItemEntity> Items { get; set; }
        public DbSet<VersionEntity> Versions { get; set; }
        public DbSet<AppUserEntity> AppUsers { get; set; }
        public DbSet<ManagerEntity> Managers { get; set; }


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
