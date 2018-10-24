using SerwisProduktow.Infrastructure.DTO;
using SerwisProduktow.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SerwisProduktow.WebUI.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository userRepository;
        public UserController(IUserRepository repo)
        {
            userRepository = repo;
        }
        [HttpGet]
        public JsonResult Get(int id)
        {
            var user = userRepository.Get(id);
            return Json(user,JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Register(UserDto register)
        {
            userRepository.Register(register);
            var user = userRepository.Get(register.Login);
            return Json(user, JsonRequestBehavior.AllowGet);
        }
    }
}