using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisProduktow.Domain.Entities
{
    public class Comment
    {
        public int ID { get; protected set; }
        public string Content { get; protected set; }
        public Service IDServices { get; protected set; }
        public int IDUser { get; protected set; }
        public DateTime DateOfAddition { get; protected set; }
        public string UserName { get; protected set; }

        public Comment(string content, User user, Service service)
        {
            SetContent(content);
            IDServices = service;
            IDUser = user.ID;
            UserName = user.Login;
            DateOfAddition = DateTime.UtcNow;
        }

        public void SetContent(string content)
        {
            if (content.Length < 20) throw new Exception();
            if (content.Length > 190) throw new Exception();
            Content = content;
        }
    }
}
