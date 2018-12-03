using SerwisProduktow.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisProduktow.Domain.Entities
{
    public class Service
    {
        public int ID { get; protected set; }
        public string Descryption { get; protected set; }
        public int Status { get; protected set; }
        public DateTime DateOfAddition { get; protected set; }

        public virtual User User { get; protected set; }
        public virtual Category_Services Category { get; protected set; }
        public virtual Rating Rating { get; protected set; }
        public virtual ICollection<Comment> Comments { get; protected set; }

        protected Service()
        {

        }
        public Service(User user, Category_Services category, Rating rating, string descryption)
        {
            User = user;
            SetCategory(category);
            SetDescryption(descryption);
            SetStatus(0);
            Rating = rating;
            Comments = new HashSet<Comment>();
            DateOfAddition = DateTime.Now;
        }
        public void SetStatus(int status)
        {
            if (status == 0 || status == 1) Status = status;
            else throw new WojtekException(WojtekCodes.WrongStatus);
        }
        public void SetDescryption(string descryption)
        {
            if (descryption.Length < 50) throw new WojtekException(WojtekCodes.ShortDescryption);
            if (descryption.Length > 250) throw new WojtekException(WojtekCodes.LongDescryption);
            Descryption = descryption;
        }
        public void SetCategory(Category_Services category)
        {
            Category = category;
        }
        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

    }
}
