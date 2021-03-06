﻿using SerwisProduktow.Domain.Exceptions;
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
        public string ServiceName { get; protected set; }
        public string ImageName { get; protected set; }
        public virtual User User { get; protected set; }
        public virtual Category_Services Category { get; protected set; }
        public virtual Rating Rating { get; protected set; }
        public ICollection<Comment> Comments { get; protected set; }

        protected Service()
        {

        }
        public Service(User user, Category_Services category, string servicename, string imageName, Rating rating, string descryption)
        {
            User = user;
            SetCategory(category);
            SetDescryption(descryption);
            SetServiceName(servicename);
            SetImageName(imageName);
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
            if (descryption.Length > 25000) throw new WojtekException(WojtekCodes.LongDescryption);
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
        public void SetServiceName(string servicename)
        {
            if (servicename.Length < 4) throw new WojtekException(WojtekCodes.ShorServiceName);
            if (servicename.Length > 100) throw new WojtekException(WojtekCodes.LongServiceName);
            ServiceName = servicename;
        }
        public void SetImageName(string image)
        {
            ImageName = image;
        }
    }
}
