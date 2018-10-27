using SerwisProduktow.Domain.Entities;
using SerwisProduktow.Infrastructure.DTO;
using SerwisProduktow.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisProduktow.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        UserDto Get(string login);
        UserDto Get(int id);
        IEnumerable<UserDto> GetAll();
        void Register(UserModel register);
        void Login(string login, string password);
        void ChangePassword(int userID, string currentPassword, string newPassword);
        void SetRole(int userID, string role);
    }
}
