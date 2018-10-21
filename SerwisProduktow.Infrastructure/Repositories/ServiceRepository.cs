using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerwisProduktow.Domain.Entities;
using SerwisProduktow.Domain.Repositories;
using SerwisProduktow.Infrastructure.DTO;

namespace SerwisProduktow.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IDBServiceRepository services;
        public ServiceRepository(IDBServiceRepository repo)
        {
            services = repo;
        }

        public void Add(int userID, string descryption, int categoryID)
        {
            var user = services.GetUser(userID);
            var category = services.GetCategory(categoryID);
            var rating = services.CreateRating();
            if (user == null) throw new Exception();
            if (category == null) throw new Exception();

            var service = new Service(user, category, rating, descryption);
            services.Add(service);
        }

        public void AddComment(int userID, string content, int serviceID)
        {
            var user = services.GetUser(userID);
            var comment = new Comment(content, user);
            var allcomments = services.GetComments(serviceID);
            services.AddComment(comment,serviceID);
        }

        public ServiceDto Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<ServiceDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<CommentDto> GetComments()
        {
            throw new NotImplementedException();
        }

        public void Remove(int serviceID)
        {
            services.Remove(serviceID);
        }

        public void Vote(int userID, int rate, int serviceID)
        {
            var service = services.Get(serviceID);
            service.Rating.AddVote(rate);
            services.Update();
        }

        public void SetCategory(int serviceID, int categoryID)
        {
            var service = services.Get(serviceID);
            var category = services.GetCategory(categoryID);
            service.SetCategory(category);
            services.Update();
        }
    }
}
