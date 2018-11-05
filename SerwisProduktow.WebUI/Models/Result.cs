using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerwisProduktow.WebUI.Models
{
    public class Result
    {
        public Result(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }
        public bool Succeeded { get; }
        public string Message { get; }
    }
}