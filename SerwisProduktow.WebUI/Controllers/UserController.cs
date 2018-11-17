using SerwisProduktow.Infrastructure.DTO;
using SerwisProduktow.Infrastructure.Repositories;
using SerwisProduktow.Infrastructure.Services;
using SerwisProduktow.Infrastructure.ViewModels;
using SerwisProduktow.WebUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace SerwisProduktow.WebUI.Controllers
{
    [JwtAuthentication]
    public class UserController : ApiController
    {
        private readonly IUserRepository userRepository;
        private readonly IJwtHandler jwtHandler;
        public UserController(IUserRepository repo, IJwtHandler jwt)
        {
            userRepository = repo;
            jwtHandler = jwt;
        }

        [HttpGet]
        public JsonResult<UserDto> Get(int id)
        {
            var user = userRepository.Get(id);
            return Json(user);
        }

        [JwtAuthentication(Role = "Admin")]
        [System.Web.Http.HttpGet]
        public JsonResult<IEnumerable<UserDto>> GetAll()
        {
            return Json(userRepository.GetAll());
        }

        [Route("api/User/Register")]
        [HttpPost, AllowAnonymous]
        public IHttpActionResult Register([System.Web.Http.FromBody]UserModel register)
        {
            userRepository.Register(register);
            return Ok();
        }

        [Route("api/Login")]
        [HttpPost, AllowAnonymous]
        public IHttpActionResult Login([FromBody]UserModel login)
        {
            var user = userRepository.Login(login.Login, login.Password);
            return Ok(jwtHandler.CreateToken(user.ID, user.Role));
        }
    }
}