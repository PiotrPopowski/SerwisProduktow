using SerwisProduktow.Infrastructure.DTO;
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
        ICollection<ServiceDto> GetAll();
        ICollection<CommentDto> GetComments();
        void Add(int userID, string descryption, int categoryID);
        void AddComment(int userID, string content, int serviceID);
        void Vote(int userID, int rate, int serviceID);
        void Remove(int serviceID);
        void SetCategory(int serviceID, int categoryID);
    }
}
