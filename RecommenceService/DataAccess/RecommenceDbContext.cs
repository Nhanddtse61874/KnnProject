
using RecommenceService.Models;
using RecommenceService.Models.Config;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace RecommenceService.DataAccess
{
    public class RecommenceDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Result> Result { get; set; }

        public RecommenceDbContext() : base("RSCnnString")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfig());
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new ResultConfig());
            modelBuilder.Configurations.Add(new CategoryConfig());

        }
    }
}
