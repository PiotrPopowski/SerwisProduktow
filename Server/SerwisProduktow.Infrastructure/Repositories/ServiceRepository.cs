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
using System.IO;
using SerwisProduktow.Infrastructure.Models;

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

            string filename =ImageHelper.WriteImage(service.Image, ProjectLocation.Get + @"\Images");

            var newService = new Service(user, category, service.Name, filename.Replace('.',';'), rating, service.Descryption);
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

        public IEnumerable<ServiceDto> GetAll(int page, int count = 10)
        {
            var service = services.GetAll(page, count);
            return Mappers.AutoMapperConfig.Initialize().Map<IEnumerable<Service>, IEnumerable<ServiceDto>>(service);
        }

        public IEnumerable<ServiceDto> GetAllUserServices(int id, int page, int count = 10)
        {
            var service = services.GetAllUserServices(id, page, count);
            return Mappers.AutoMapperConfig.Initialize().Map<IEnumerable<Service>, IEnumerable<ServiceDto>>(service);
        }

        public void Remove(int serviceID, int userID, string role="")
        {
            var service = services.Get(serviceID);
            if (role=="Admin" || service.User.ID == userID)
                services.Remove(serviceID);
            else
                throw new WojtekException(WojtekCodes.PermissionDenied);
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

        public IEnumerable<CommentDto> GetComments(int serviceID, int page, int count = 10)
        {
            var service = services.Get(serviceID);
            var comments = service.Comments.OrderByDescending(s => s.DateOfAddition).Skip((page - 1) * count).Take(count).ToList();
            return Mappers.AutoMapperConfig.Initialize().Map<IEnumerable<Comment>, IEnumerable<CommentDto>>(comments);
        }
    }
}
