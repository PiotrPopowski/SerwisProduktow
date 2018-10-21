using SerwisProduktow.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SerwisProduktow.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        private IServiceRepository serviceRepository;
        public ServiceController(IServiceRepository repo)
        {
            serviceRepository = repo;
        }
        // GET: Service
        public void AddService(int userID, string descryption, int categoryID)
        {
            serviceRepository.Add(userID, descryption, categoryID);
        }

        public void AddComment(int userID, string content, int serviceID)
        {
            serviceRepository.AddComment(userID, content, serviceID);
        }

        public void Vote(int userID, int rate, int serviceID)
        {
            serviceRepository.Vote(userID, rate, serviceID);
        }
    }
}