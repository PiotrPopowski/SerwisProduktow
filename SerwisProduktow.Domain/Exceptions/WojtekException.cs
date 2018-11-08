using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SerwisProduktow.Infrastructure.Exceptions
{
    public class WojtekException : Exception
    {

        public WojtekException() { }

        public WojtekException(string message) :base(message)
        {
        }
    }
}
