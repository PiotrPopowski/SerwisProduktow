using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisProduktow.Domain.Entities
{
    public class Category_Services
    {
        public Category_Services(string category="")
        {
            NameOfCategory = category;
            Services = new HashSet<Service>();
        }
        protected Category_Services()
        {

        }
        public int ID { get; protected set; }
        public string NameOfCategory { get; protected set; }

        public ICollection<Service> Services { get; set; }
    }
}
