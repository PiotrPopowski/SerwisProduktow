using SerwisProduktow.Infrastructure.DTO;
using SerwisProduktow.Infrastructure.Repositories;
using SerwisProduktow.Infrastructure.ViewModels;
using SerwisProduktow.WebUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Results;

namespace SerwisProduktow.WebUI.Controllers
{
    [JwtAuthentication]
    public class ServiceController : ApiController
    {
        private IServiceRepository serviceRepository;
        public ServiceController(IServiceRepository repo)
        {
            serviceRepository = repo;
        }

        [Route("api/Service/AddService")]
        [HttpPost]
        public IHttpActionResult AddService([FromBody]ServiceModel service)
        {
            serviceRepository.Add(service);
            return Ok();
        }

        [Route("api/Service/AddComment")]
        [HttpPost]
        public IHttpActionResult AddComment([FromBody]CommentModel comment)
        {
            serviceRepository.AddComment(comment);
            return Ok();
        }

        [HttpGet, AllowAnonymous]
        public IHttpActionResult GetAll(int page, int count = 10)
        {
            var services = serviceRepository.GetAll(page, count);
            return Ok(services);
        }

        [HttpGet, AllowAnonymous]
        public IHttpActionResult GetComments(int serviceID, int page, int count = 10)
        {
            var comments = serviceRepository.GetComments(serviceID, page, count);
            return Ok(comments);
        }

        [HttpGet, AllowAnonymous]
        public IHttpActionResult GetAllUserServices(int id, int page, int count = 10)
        {
            var service = serviceRepository.GetAllUserServices(id, page, count);
            return Ok(service);
        }

        [HttpGet, AllowAnonymous]
        public IHttpActionResult Get(int id)
        {
            var service = serviceRepository.Get(id);
            return Ok(service);
        }

        public void Vote(int userID, int rate, int serviceID)
        {
            serviceRepository.Vote(userID, rate, serviceID);
        }

        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            int userID = int.Parse(User?.Identity?.Name);
            var identity = User.Identity as ClaimsIdentity;
            string role = identity.FindFirst(identity.RoleClaimType).Value;
            serviceRepository.Remove(id, userID, role);
            return Ok();
        }
    }
}
