using System;

namespace SerwisProduktow.Infrastructure.DTO
{
    public class UserDto
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }
        public int Status { get; set; }
        public DateTime Created_at { get; set; }

    }
}
