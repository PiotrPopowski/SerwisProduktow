using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerwisProduktow.Domain.Entities;
using SerwisProduktow.Domain.Repositories;
using SerwisProduktow.Infrastructure.DTO;
using SerwisProduktow.Domain.Exceptions;
using SerwisProduktow.Infrastructure.ViewModels;

namespace SerwisProduktow.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IDBServiceRepository services;
        public ServiceRepository(IDBServiceRepository repo)
        {
            services = repo;
        }

        public void Add(ServiceModel service)
        {
            var user = services.GetUser(service.UserID);
            var category = services.GetCategory(service.CategoryID);
            var rating = services.CreateRating();
            if (user == null) throw new WojtekException(WojtekCodes.UserNotFound);
            if (category == null) throw new WojtekException(WojtekCodes.CategoryNotFound);

            var newService = new Service(user, category, service.Name, rating, service.Descryption);
            services.Add(newService);
        }

        public void AddComment(CommentModel customComment)
        {
            var user = services.GetUser(customComment.UserID);
            var service = services.Get(customComment.ServiceID);
            var comment = new Comment(customComment.Content, user, service);
            services.AddComment(comment);
        }

        public ServiceDto Get(int id)
        {
            var service = services.Get(id);
            return Mappers.AutoMapperConfig.Initialize().Map<Service, ServiceDto>(service);
        }

        public IEnumerable<ServiceDto> GetAll()
        {
            var service = services.GetAll();
            return Mappers.AutoMapperConfig.Initialize().Map<IEnumerable<Service>, IEnumerable<ServiceDto>>(service);
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
