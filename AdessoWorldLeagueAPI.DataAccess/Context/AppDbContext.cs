using AdessoWorldLeagueAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoWorldLeagueAPI.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Country> Country { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<AdessoGroup> AdessoGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Country)
                .WithMany(c => c.Teams)
                .HasForeignKey(t => t.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.AdessoGroup)
                .WithMany(g => g.Teams)
                .HasForeignKey(t => t.GroupId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Draw>()
                .HasOne(d => d.Group)
                .WithMany(g => g.Draws)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Draw>()
                .HasOne(d => d.Team)
                .WithMany(t => t.Draws)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
