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
                cfg.CreateMap<Category_Services, CategoryDto>().ForMember(categoryDto => categoryDto.Name, opt => opt.MapFrom(category => category.NameOfCategory));
                cfg.CreateMap<Comment, CommentDto>();
                cfg.CreateMap<Rating, RatingDto>();
                cfg.CreateMap<User, UserDto>().ForMember(userDto => userDto.Role, opt => opt.MapFrom(user => Role.GetRoleName(user.RoleID)));
                cfg.CreateMap<Service, ServiceDto>();
            })
            .CreateMapper();
    
    }
}
