using SerwisProduktow.Domain.Entities;
using SerwisProduktow.Domain.Repositories;
using SerwisProduktow.Infrastructure.DTO;
using SerwisProduktow.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisProduktow.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly IDBUserRepository users;
        public UserRepository(IDBUserRepository dBUserRepository)
        {
            this.users = dBUserRepository;
        }
        protected UserRepository()
        {

        }

        public void ChangePassword(int userID, string currentPassword, string newPassword)
        {
            var user = users.Get(userID);
            user.SetPassword(newPassword, user.Salt);
            users.Update();
        }

        public UserDto Get(string login)
        {
            var user = users.Get(login);
            return Mappers.AutoMapperConfig.Initialize().Map<User, UserDto>(user);
        }
        public UserDto Get(int id)
        {
            return Get(users.Get(id).Login);
        }

        public IEnumerable<UserDto> GetAll()
        {
            IEnumerable<User> allUsers = users.GetAll();
            IEnumerable<UserDto> usersDto = Mappers.AutoMapperConfig.Initialize().Map<IEnumerable<User>, IEnumerable<UserDto>>(allUsers);
            return usersDto;
        }

        public void Login(string login, string password)
        {
            throw new NotImplementedException();
        }

        public void Register(UserModel register)
        {
            var user = users.Get(register.Login);
            if (user != null)
            {
                throw new Exception();
            }

            string salt = Guid.NewGuid().ToString();
            user = new User(register.Login, register.Password, Role.User, salt);
            users.Add(user);
        }

        public void SetRole(int userID, string role)
        {
            var user = users.Get(userID);
            Role newRole;
            if (role == "Admin") newRole = Role.Admin;
            else newRole = Role.User;
            user.SetRole(newRole);
            users.Update();
        }
    }
}
