using SerwisProduktow.Domain.Entities;
using System.Data.Entity;

namespace SerwisProduktow.Domain.Repositories
{
    public interface IDBEntities
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<Category_Services> Category_Services { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Rating> Ratings { get; set; }

        int SaveChanges();
    }
}
