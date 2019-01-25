using SerwisProduktow.Infrastructure.DTO;
using SerwisProduktow.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisProduktow.Infrastructure.Repositories
{
    public interface IServiceRepository
    {
        ServiceDto Get(int id);
        IEnumerable<ServiceDto> GetAll(int page, int count = 10);
        IEnumerable<CommentDto> GetComments(int serviceID, int page, int count = 10);
        IEnumerable<ServiceDto> GetTop(int count, string category);
        void Add(ServiceModel service);
        void AddComment(CommentModel comment);
        void Vote(int userID, int rate, int serviceID);
        void Remove(int serviceID, int userID, string role="");
        void SetCategory(int serviceID, int categoryID);
        IEnumerable<ServiceDto> GetAllUserServices(int id, int page, int count = 10);
    }
}
