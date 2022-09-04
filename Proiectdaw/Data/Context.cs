using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proiectdaw.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Data
{
    public class Context : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
          public DbSet<SessionToken> SessionTokens { get; set; }
         public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<TeamCompetition> TeamCompetitions { get; set; }

        protected override void OnModelCreating(ModelBuilder Builder)
        {//One to many

            Builder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(p => p.Team);
            //One to one

            Builder.Entity<Team>()
                .HasOne(t => t.Coach)
                .WithOne(c => c.Team);

            //Many to many

            Builder.Entity<TeamCompetition>().HasKey(tc => new { tc.TeamId, tc.CompetitionId });

            Builder.Entity<TeamCompetition>()
                .HasOne(tc => tc.Team)
                .WithMany(t => t.TeamCompetitions)
                .HasForeignKey(tc => tc.TeamId);

           Builder.Entity<TeamCompetition>()
                .HasOne(tc => tc.Competition)
                .WithMany(t => t.TeamCompetitions)
                .HasForeignKey(tc => tc.CompetitionId);



            Builder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });
                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);

            });

             base.OnModelCreating(Builder);
        }


    }
}
