using SerwisProduktow.Domain.Entities;
using System.Collections.Generic;

namespace SerwisProduktow.Domain.Repositories
{
    public interface IDBServiceRepository
    {
        Service Get(int id);
        User GetUser(int userID);
        IEnumerable<Service> GetAll(int page, int count = 10);
        IEnumerable<Service> GetAllUserServices(int id, int page, int count = 10);
        IEnumerable<Comment> GetComments(int serviceID);
        Category_Services GetCategory(int categoryID);
        void Add(Service service);
        void AddComment(Comment comment);
        void Remove(int serviceID);
        void Update();
        Rating CreateRating();
    }
}
