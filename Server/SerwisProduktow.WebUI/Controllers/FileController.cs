using SerwisProduktow.Infrastructure.Models;
using SerwisProduktow.WebUI.Filters;
using SerwisProduktow.WebUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SerwisProduktow.WebUI.Controllers
{
    public class FileController : ApiController
    {

        public FileController()
        {
        }
        
        [Route("api/Images/{id}")]
        [HttpGet, AllowAnonymous]
        public IHttpActionResult GetImage(string id)
        {
            var serverPath = Path.Combine(ProjectLocation.Get+@"\Images", id.Replace(';','.'));
            var fileInfo = new FileInfo(serverPath);

            return !fileInfo.Exists
                ? (IHttpActionResult)NotFound()
                : new Models.FileResult(fileInfo.FullName);
        }
    }
}
