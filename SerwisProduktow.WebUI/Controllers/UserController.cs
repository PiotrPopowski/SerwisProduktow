using SerwisProduktow.Infrastructure.DTO;
using SerwisProduktow.Infrastructure.Repositories;
using SerwisProduktow.Infrastructure.ViewModels;
using SerwisProduktow.WebUI.Models;
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
        public Result Register([System.Web.Http.FromBody]UserModel register)
        {
            Result result;
            try
            {
                userRepository.Register(register);
                result = new Result(true, "");
            }
            catch (Exception ex)
            {
                result = new Result(false, ex.Message);
            }
            return result;
        }
    }
}