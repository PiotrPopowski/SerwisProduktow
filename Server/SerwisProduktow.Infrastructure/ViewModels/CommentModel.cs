using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisProduktow.Infrastructure.ViewModels
{
    public class CommentModel
    {
        public int UserID { get; set; }
        public string Content { get; set; }
        public int ServiceID { get; set; }
    }
}
