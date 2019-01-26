using SerwisProduktow.Domain.Entities;
using System.Data.Entity;
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
            using (var dBEntities = new DBEntities())
            {
                return dBEntities.Services.Include(x=>x.Comments.Select(c=>c.User)).Include("User").Include("Rating").Include("Category").FirstOrDefault(s => s.ID == id && s.Status == 0);
            }
        }

        public IEnumerable<Service> GetAll(int page, int count = 10)
        {
            using (var dBEntities = new DBEntities())
            {
                return dBEntities.Services.Include("User").Include("Rating").Include("Category").OrderByDescending(s => s.DateOfAddition).Where(x => x.Status == 0).Skip((page - 1) * count).Take(count).ToList();
            }
        }

        public IEnumerable<Service> GetAllUserServices(int id, int page, int count=10)
        {
            return dBEntities.Services.OrderByDescending(s => s.DateOfAddition).Where(x => x.User.ID == id && x.Status == 0).Skip((page-1)*count).Take(count).ToList();
        }

        public void AddComment(Comment comment)
        {
            var service = Get(comment.ServiceID);
            service.Comments.Add(comment);
            dBEntities.Comments.Add(comment);
            dBEntities.SaveChanges();
        }

        public void Remove(int serviceID)
        {
            var service = dBEntities.Services.SingleOrDefault(s => s.ID == serviceID && s.Status == 0);
            service.SetStatus(1);
            Update();
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
