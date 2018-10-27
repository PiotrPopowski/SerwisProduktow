using SerwisProduktow.Infrastructure.Repositories;
using SerwisProduktow.Infrastructure.ViewModels;
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

        public void AddService(ServiceModel service)
        {
            serviceRepository.Add(service);
        }

        public void AddComment(CommentModel comment)
        {
            serviceRepository.AddComment(comment);
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            var services = serviceRepository.GetAll();
            return Json(services, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Get(int id)
        {
            var service = serviceRepository.Get(id);
            return Json(service);
        }

        public void Vote(int userID, int rate, int serviceID)
        {
            serviceRepository.Vote(userID, rate, serviceID);
        }
    }
}