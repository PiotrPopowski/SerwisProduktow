using SerwisProduktow.Domain.Entities;
using System.Collections.Generic;

namespace SerwisProduktow.Domain.Repositories
{
    public interface IDBUserRepository
    {
        User Get(int id);
        User Get(string login);
        IEnumerable<User> GetAll();
        void Add(User user);
        void Remove(int id);
        void Update();
    }
}
