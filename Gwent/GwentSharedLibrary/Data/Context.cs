using GwentSharedLibrary.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;

namespace GwentSharedLibrary.Data
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.Log = (message) => Debug.WriteLine(message);
        }

        public DbSet<Card> Cards { get; set; }  
        public DbSet<Pile> Piles { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRelationship> UserRelationships { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<DeckUser> DeckUsers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<DeckCard> DeckCards { get; set; }
        public DbSet<PileCard> PileCards { get; set; }
        public DbSet<GameRound> GameRounds { get; set; }
        public DbSet<GameRoundCard> GameRoundCards { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<Card>()
            //    .HasRequired(c => c.Deck)
            //    .WithMany(d => d.Cards)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.EmailAddress)
                .IsUnique();
            //base.OnModelCreating(modelBuilder);
        }
    }
}