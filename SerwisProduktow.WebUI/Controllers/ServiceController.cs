using SerwisProduktow.Infrastructure.DTO;
using SerwisProduktow.Infrastructure.Repositories;
using SerwisProduktow.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace SerwisProduktow.WebUI.Controllers
{
    public class ServiceController : ApiController
    {
        private IServiceRepository serviceRepository;
        public ServiceController(IServiceRepository repo)
        {
            serviceRepository = repo;
        }
        [Route("api/Service/AddService")]
        [HttpPost]
        public void AddService([FromBody]ServiceModel service)
        {
            serviceRepository.Add(service);
        }

        [Route("api/Service/AddComment")]
        [HttpPost]
        public void AddComment([FromBody]CommentModel comment)
        {
            serviceRepository.AddComment(comment);
        }

        [HttpGet]
        public JsonResult<IEnumerable<ServiceDto>> GetAll()
        {
            var services = serviceRepository.GetAll();
            return Json(services);
        }

        [HttpGet]
        public JsonResult<ServiceDto> Get(int id)
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