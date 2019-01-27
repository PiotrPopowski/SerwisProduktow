using SerwisProduktow.Domain.Entities;
using SerwisProduktow.Infrastructure.DTO;
using SerwisProduktow.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisProduktow.Infrastructure.Repositories
{
    public interface ICommentRepository
    {
        IEnumerable<CommentDto> GetComments(int serviceID, int page, int count=10);
        void AddComment(CommentModel comment);
    }
}
