using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SerwisProduktow.Domain.Exceptions
{
    public class WojtekException : Exception
    {

        public WojtekException() { }

        public WojtekException(string message) :base(message)
        {
        }
    }
}
