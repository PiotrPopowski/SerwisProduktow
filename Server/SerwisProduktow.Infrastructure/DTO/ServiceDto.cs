using System;
using System.Collections.Generic;

namespace SerwisProduktow.Infrastructure.DTO
{
    public class ServiceDto
    {
        public int ID { get; set; }
        public UserDto User { get; set; }
        public string Descryption { get; set; }
        public int Status { get; set; }
        public DateTime DateOfAddition { get; set; }
        public CategoryDto Category { get; set; }
        public RatingDto Rating { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
        public string ServiceName { get; set; }
        public string ImageName { get; set; }
    }
}
