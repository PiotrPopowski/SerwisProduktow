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
        public void AddComment([FromBody]CommentModel comment)
        {
            serviceRepository.AddComment(comment);
        }

        [HttpGet, AllowAnonymous]
        public IHttpActionResult GetAll()
        {
            var services = serviceRepository.GetAll();
            return Ok(services);
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
        public void Remove(int serviceID)
        {
            int userID = int.Parse(User?.Identity?.Name);
            var identity = User.Identity as ClaimsIdentity;
            string role = identity.FindFirst(identity.RoleClaimType).Value;
            serviceRepository.Remove(serviceID, userID, role);
        }
    }
}
