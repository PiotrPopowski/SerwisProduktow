using SerwisProduktow.Infrastructure.DTO;
using SerwisProduktow.Infrastructure.Repositories;
using SerwisProduktow.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace SerwisProduktow.WebUI.Controllers
{
    public class UserController : ApiController
    {
        private IUserRepository userRepository;
        public UserController(IUserRepository repo)
        {
            userRepository = repo;
        }

        [HttpGet]
        public JsonResult<UserDto> Get(int id)
        {
            var user = userRepository.Get(id);
            return Json(user);
        }

        [System.Web.Http.HttpGet]
        public JsonResult<IEnumerable<UserDto>> GetAll()
        {
            return Json(userRepository.GetAll());
        }

        [Route("api/User/Register")]
        [System.Web.Http.HttpPost]
        public JsonResult<UserDto> Register([System.Web.Http.FromBody]UserModel register)
        {
            userRepository.Register(register);
            var user = userRepository.Get(register.Login);
            return Json(user);
        }
    }
}