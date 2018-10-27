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
        IEnumerable<ServiceDto> GetAll();
        void Add(ServiceModel service);
        void AddComment(CommentModel comment);
        void Vote(int userID, int rate, int serviceID);
        void Remove(int serviceID);
        void SetCategory(int serviceID, int categoryID);
    }
}
