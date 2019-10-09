using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FixtureApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>()
                .HasOne(t => t.TeamLeft)
                .WithMany(m => m.MatchsL)
                .HasForeignKey(t => t.TeamLeftId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Match>()
                .HasOne(t => t.TeamRight)
                .WithMany(m => m.MatchsR)
                .HasForeignKey(t => t.TeamRightId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, Name = "Team1"},
                new Team { Id = 2, Name = "Team2"},
                new Team { Id = 3, Name = "Team3"},
                new Team { Id = 4, Name = "Team4"},
                new Team { Id = 5, Name = "Team5"},
                new Team { Id = 6, Name = "Team6"},
                new Team { Id = 7, Name = "Team7"},
                new Team { Id = 8, Name = "Team8"},
                new Team { Id = 9, Name = "Team9" },
                new Team { Id = 10, Name = "Team10"},
                new Team { Id = 11, Name = "Team11"},
                new Team { Id = 12, Name = "Team12"},
                new Team { Id = 13, Name = "Team13"},
                new Team { Id = 14, Name = "Team14"},
                new Team { Id = 15, Name = "Team15"},
                new Team { Id = 16, Name = "Team16"},
                new Team { Id = 17, Name = "Team17"},
                new Team { Id = 18, Name = "Team18" }
            );
        }
    }
}
