﻿using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class IdentityDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        override public DbSet<User> Users => Set<User>();
        public DbSet<Poll> Polls => Set<Poll>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Answer> Answers => Set<Answer>();
        public DbSet<Vote> Votes => Set<Vote>();
        public DbSet<PollAllowed> PollAllowed => Set<PollAllowed>();
        public DbSet<PollModerators> PollModerators => Set<PollModerators>();
        public DbSet<VotingToken> VotingTokens => Set<VotingToken>();
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PollAllowed>().HasKey(x => new
            {
                x.UserId,
                x.PollId,
            });
            builder.Entity<PollModerators>().HasKey(x => new
            {
                x.UserId,
                x.PollId,
            });
        }
    }
}
