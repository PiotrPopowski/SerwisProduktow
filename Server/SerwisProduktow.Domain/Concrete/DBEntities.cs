using SerwisProduktow.Domain.Entities;
using SerwisProduktow.Domain.Repositories;
using System.Data.Entity;

namespace SerwisProduktow.Domain.Concrete
{
    public class DBEntities :DbContext, IDBEntities
    {
        public DBEntities()
        {
            Database.SetInitializer(new DataInitializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Category_Services> Category_Services { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}
