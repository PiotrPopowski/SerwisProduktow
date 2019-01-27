using SerwisProduktow.Domain.Entities;
using SerwisProduktow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisProduktow.Domain.Concrete
{
    public class DBCommentRepository: IDBCommentRepository
    {
        public DBCommentRepository()
        {
        }
        public IEnumerable<Comment> GetComments(int serviceID, int page, int count = 10)
        {
            using (var dBEntities = new DBEntities())
            {
                return dBEntities.Comments.Where(c => c.Service.ID == serviceID).OrderByDescending(u => u.DateOfAddition)
                                          .Skip((page - 1) * count)
                                          .Take(count);
            }
        }

        public void AddComment(Comment comment)
        {
            using (var dBEntities = new DBEntities())
            {
                dBEntities.Comments.Add(comment);
                dBEntities.SaveChanges();
            }
        }
    }
}
