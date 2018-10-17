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
        public int IDUser { get; protected set; }
        public string UserName { get; protected set; }
        public int IDCategory { get; protected set; }
        public string Descryption { get; protected set; }
        public int Status { get; protected set; }
        public Rating Rating { get; protected set; }
        public DateTime DateOfAddition { get; protected set; }
        public Service(User user, Category_Services category, Rating rating, string descryption)
        {
            IDUser = user.ID;
            UserName = user.Login;
            SetCategory(category);
            SetDescryption(descryption);
            SetStatus(0);
            Rating = rating;
            DateOfAddition = DateTime.UtcNow;
        }
        public void SetStatus(int status)
        {
            if (status == 0 || status == 1) Status = status;
            else throw new Exception();
        }
        public void SetDescryption(string descryption)
        {
            if (descryption.Length < 50) throw new Exception();
            if (descryption.Length > 250) throw new Exception();
            Descryption = descryption;
        }
        public void SetCategory(Category_Services category)
        {
            IDCategory = category.ID;
        }
        

    }
}
