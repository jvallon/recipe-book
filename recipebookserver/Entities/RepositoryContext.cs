using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Favorite>()
            //    .HasKey(f => new { f.UserId, f.RecipeId });
            var instConverter = new ValueConverter<IList<Instruction>, string>(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<IList<Instruction>>(v) ?? null);

            modelBuilder
                .Entity<Recipe>()
                .Property(e => e.Instructions)
                .HasConversion(instConverter);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
    }
}
