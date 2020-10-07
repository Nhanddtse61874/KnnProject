
using Persistence.KnnProject.Models;
using Persistence.KnnProject.Models.Config;
using System.Data.Entity;


namespace Persistence.DataAccess.Models
{
    public class KnnDbContext : DbContext
    {
        public DbSet<Category> Category { get; set; }

        public DbSet<Contact> Contact { get; set; } 

        public DbSet<ImageStorage> ImageStorage { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetail> OrderDetail { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Size> Size { get; set; }

        public DbSet<Color> Color { get; set; }

        public DbSet<Tag> Tag { get; set; }

        public DbSet<Rank> Rank { get; set; }

        public DbSet<SizeProduct> SizeProduct { get; set; }

        public DbSet<ColorProduct> ColorProduct { get; set; }

        public DbSet<TagProduct> TagProduct { get; set; }
        public KnnDbContext() : base("KnnCnnString")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfig());
            modelBuilder.Configurations.Add(new ColorConfig());
            modelBuilder.Configurations.Add(new ImageStorageConfig());
            modelBuilder.Configurations.Add(new ColorProductConfig());
            modelBuilder.Configurations.Add(new ContactConfig());
            modelBuilder.Configurations.Add(new OrderConfig());
            modelBuilder.Configurations.Add(new OrderDetailConfig());
            modelBuilder.Configurations.Add(new ProductConfig());
            modelBuilder.Configurations.Add(new RankConfig());
            modelBuilder.Configurations.Add(new RoleConfig());
            modelBuilder.Configurations.Add(new SizeConfig());
            modelBuilder.Configurations.Add(new SizeProductConfig());
            modelBuilder.Configurations.Add(new TagConfig());
            modelBuilder.Configurations.Add(new TagProductConfig());
            modelBuilder.Configurations.Add(new UserConfig());

        }
    }

}