using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerwisProduktow.Domain.Entities;
using SerwisProduktow.Domain.Interfaces;
using SerwisProduktow.Infrastructure.DTO;
using SerwisProduktow.Infrastructure.ViewModels;

namespace SerwisProduktow.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IDBCommentRepository comments;
        private readonly IDBServiceRepository services;
        public CommentRepository(IDBCommentRepository repo, IDBServiceRepository serviceRepo)
        {
            comments = repo;
            services = serviceRepo;
        }

        public void AddComment(CommentModel comment)
        {
            var user = services.GetUser(comment.UserID);
            var service = services.Get(comment.ServiceID);
            var newComment = new Comment(comment.Content, user, service);
            comments.AddComment(newComment);
        }

        public IEnumerable<CommentDto> GetComments(int serviceID, int page, int count = 10)
        {
            var service = services.Get(serviceID);
            var commentList = comments.GetComments(service.ID, page, count);
            return Mappers.AutoMapperConfig.Initialize().Map<IEnumerable<Comment>, IEnumerable<CommentDto>>(commentList);
        }
    }
}
