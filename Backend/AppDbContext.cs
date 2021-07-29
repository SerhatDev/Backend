using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        // Used for the ability to Add migrations from classLibrary
        private bool classLibraryInstace = false;

        public AppDbContext()
        {
            classLibraryInstace = true;
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            classLibraryInstace = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // If invoked by package manager, we set the default ConnectionString
            if (classLibraryInstace)
                optionsBuilder.UseSqlServer(@"Server=.\sqlexpress;Database=Backend;Trusted_Connection=true;");

            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}