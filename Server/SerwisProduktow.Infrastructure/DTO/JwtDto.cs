using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisProduktow.Infrastructure.DTO
{
    public class JwtDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
        public long Expires { get; set; }
    }
}
