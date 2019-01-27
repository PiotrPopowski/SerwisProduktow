using SerwisProduktow.Domain.Entities;
using SerwisProduktow.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SerwisProduktow.Domain.Concrete
{
    public class DBUserRepository : IDBUserRepository
    {
        IDBEntities dBEntities;
        public DBUserRepository(IDBEntities db)
        {
            dBEntities = db;
        }

        public void Add(User user)
        {
            dBEntities.Users.Add(user);
            dBEntities.SaveChanges();
        }

        public User Get(int id)
        {
            return dBEntities.Users.FirstOrDefault(u => u.ID == id);
        }

        public User Get(string login)
        {
            return dBEntities.Users.FirstOrDefault(u => u.Login == login);
        }

        public IEnumerable<User> GetAll()
        {
            return dBEntities.Users.OrderByDescending(u=>u.Created_at).ToList();
        }

        public void Remove(int id)
        {
            var user = Get(id);
            user.SetStatus(1);
            dBEntities.SaveChanges();
        }

        public void Update()
        {
            dBEntities.SaveChanges();
        }
    }
}
