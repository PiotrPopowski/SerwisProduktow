using SerwisProduktow.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisProduktow.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(int userID, string role);
    }
}
