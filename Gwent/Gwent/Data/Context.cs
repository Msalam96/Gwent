using Gwent.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Gwent.Data
{
    public class Context : DbContext
    {
        public DbSet<Card> Cards { get; set; }  
        public DbSet<Pile> Piles { get; set; }
        public DbSet<Deck> Decks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Card>()
                .HasRequired(c => c.Deck)
                .WithMany(d => d.Cards)
                .WillCascadeOnDelete(false);
        }
    }
}