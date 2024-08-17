using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJackEL;

namespace BlackJackDAL
{

    /*
     * Class for connection/creation of the BlackJack Database
     */
    public class GameDBContext : DbContext
    {
        public DbSet<PlayerEntity> Players { get; set; } // Player Table
        public DbSet<CardEntity> Cards { get; set; } // Cards Table
        public DbSet<GameCardEntity> GameCards { get; set; } // GameCards Table
        // GameCards represents the relationship between games / players and cards. What cards are used by the player in the game


        public GameDBContext() { }

        public GameDBContext(DbContextOptions<GameDBContext> options) : base(options)
        {
        }


        /*
         * Connects to Database
         */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GameDB;Integrated Security=True;");
            }
        }


        /*
         * Defineing the model for the database.
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defines the  primary keys for GameCardEntity using GameID, PlayerID, and CardID as the Key.
            modelBuilder.Entity<GameCardEntity>()
                .HasKey(e => new { e.GameID, e.PlayerID, e.CardID });

            // Each GameCardEntity is associated with one Player(OneToMany).
            modelBuilder.Entity<GameCardEntity>()
                .HasOne(gc => gc.Player)
                .WithMany(p => p.GameCards)
                .HasForeignKey(gc => gc.PlayerID);

            // Each GameCardEntity is associated with one Card (OneToMany).
            modelBuilder.Entity<GameCardEntity>()
                .HasOne(gc => gc.Card)
                .WithMany(c => c.GameCards)
                .HasForeignKey(gc => gc.CardID);
        }
    }
}
