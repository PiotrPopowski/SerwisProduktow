using SerwisProduktow.Domain.Entities;
using SerwisProduktow.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SerwisProduktow.Domain.Concrete
{
    public class DBServiceRepository : IDBServiceRepository
    {
        private readonly IDBEntities dBEntities;
        public DBServiceRepository(IDBEntities db)
        {
            dBEntities = db;
        }

        public void Add(Service service)
        {
            dBEntities.Services.Add(service);
            dBEntities.SaveChanges();
        }

        public Service Get(int id)
        {
            return dBEntities.Services.SingleOrDefault(s => s.ID == id);
        }

        public IEnumerable<Service> GetAll()
        {
            return dBEntities.Services.ToList();
        }

        public IEnumerable<Comment> GetComments(int serviceID)
        {
            return Get(serviceID).Comments.ToList();
        }

        public void AddComment(Comment comment)
        {
            var service = Get(comment.Service.ID);
            service.Comments.Add(comment);
            dBEntities.Comments.Add(comment);
            dBEntities.SaveChanges();
        }

        public void Remove(int serviceID)
        {
            var service = Get(serviceID);
            service.SetStatus(1);
        }

        public User GetUser(int userID)
        {
            return dBEntities.Users.SingleOrDefault(u => u.ID == userID);
        }

        public Category_Services GetCategory(int categoryID)
        {
            return dBEntities.Category_Services.FirstOrDefault(c => c.ID == categoryID);
        }

        public Rating CreateRating()
        {
            var rating = new Rating();
            dBEntities.Ratings.Add(rating);
            dBEntities.SaveChanges();
            return rating;
        }

        public void Update()
        {
            dBEntities.SaveChanges();
        }
    }
}
