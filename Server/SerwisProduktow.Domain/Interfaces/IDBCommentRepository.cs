using SerwisProduktow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisProduktow.Domain.Interfaces
{
    public interface IDBCommentRepository
    {
        IEnumerable<Comment> GetComments(int serviceID, int page, int count = 10);
        void AddComment(Comment comment);
    }
}
