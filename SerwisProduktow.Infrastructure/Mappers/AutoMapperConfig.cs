using AutoMapper;
using SerwisProduktow.Domain.Entities;
using SerwisProduktow.Infrastructure.DTO;

namespace SerwisProduktow.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category_Services, CategoryDto>();
                cfg.CreateMap<Comment, CommentDto>();
                cfg.CreateMap<Rating, RatingDto>();
                cfg.CreateMap<Service, ServiceDto>();
                cfg.CreateMap<User, UserDto>().ForMember(userDto => userDto.Role, opt => opt.MapFrom(user => user.Role.Name));
            })
            .CreateMapper();
    
    }
}
