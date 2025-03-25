using Microsoft.EntityFrameworkCore;
using uMarket.Models;

namespace uMarket.Data
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions<MarketContext> options) : base(options) 
        { 
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<Category> Categories{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Listing>().ToTable("Listings");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Category>().ToTable("Categories");

            modelBuilder.Entity<Order>()
            .HasOne(o => o.User) // Relacja do kupującego (User)
            .WithMany() // Nie ma kolekcji w User
            .HasForeignKey(o => o.UserId) // Klucz obcy do Usera
            .OnDelete(DeleteBehavior.Cascade); // Kaskadowe usuwanie dla UserId

            modelBuilder.Entity<Order>()
            .HasOne(o => o.Listing) // Relacja do ogłoszenia
            .WithMany() // Nie ma kolekcji w Listing
            .HasForeignKey(o => o.ListingId) // Klucz obcy do Listing
            .OnDelete(DeleteBehavior.NoAction); // Brak kaskadowego usuwania dla ListingId
        }
    }
}
