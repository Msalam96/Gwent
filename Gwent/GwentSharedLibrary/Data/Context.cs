using GwentSharedLibrary.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GwentSharedLibrary.Data
{
    public class Context : DbContext
    {
        public DbSet<Card> Cards { get; set; }  
        public DbSet<Pile> Piles { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRelationship> UserRelationships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Card>()
                .HasRequired(c => c.Deck)
                .WithMany(d => d.Cards)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.EmailAddress)
                .IsUnique();
        }
    }
}