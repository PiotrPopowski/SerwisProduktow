using SerwisProduktow.Domain.Exceptions;
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
        public DateTime DateOfAddition { get; protected set; }

        public virtual User User { get; protected set; }
        public virtual Service Service { get; protected set; }

        protected Comment()
        {

        }
        public Comment(string content, User user, Service service)
        {
            SetContent(content);
            User = user;
            Service = service;
            DateOfAddition = DateTime.Now;
        }

        public void SetContent(string content)
        {
            if (content.Length < 20) throw new WojtekException(WojtekCodes.ShortComment);
            if (content.Length > 190) throw new WojtekException(WojtekCodes.LongComment);
            Content = content;
        }
    }
}
