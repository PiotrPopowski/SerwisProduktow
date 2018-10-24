using SerwisProduktow.Domain.Entities;
using SerwisProduktow.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisProduktow.Domain.Concrete
{
    class DataInitializer: DropCreateDatabaseIfModelChanges<DBEntities>
    {
        protected override void Seed(DBEntities context)
        {
            context.Roles.Add(Role.User);
            context.Roles.Add(Role.Admin);

            context.Category_Services.Add(new Category_Services("Ubrania"));
            context.Category_Services.Add(new Category_Services("Inne"));

            context.Users.Add(new User("Admin", "Password123", Role.Admin, Guid.NewGuid().ToString("N")));
            context.Users.Add(new User("Marek", "password1", Role.User, Guid.NewGuid().ToString("N")));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
