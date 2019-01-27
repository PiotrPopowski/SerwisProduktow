using System;

namespace SerwisProduktow.Infrastructure.DTO
{
    public class CommentDto
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public UserDto User { get; set; }
        public DateTime DateOfAddition { get; set; }
    }
}
