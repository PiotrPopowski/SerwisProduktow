using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisProduktow.Infrastructure.ViewModels
{
    public class ServiceModel
    {
        public int UserID { get; set; } 
        public string Descryption { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}
