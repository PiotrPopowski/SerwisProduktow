using SerwisProduktow.Domain.Entities;
using SerwisProduktow.Domain.Exceptions;
using SerwisProduktow.Domain.Interfaces;
using SerwisProduktow.Domain.Repositories;
using SerwisProduktow.Infrastructure.DTO;
using SerwisProduktow.Infrastructure.Services;
using SerwisProduktow.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisProduktow.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDBUserRepository users;
        private readonly IEncrypter encrypter;

        public UserRepository(IDBUserRepository dBUserRepository, IEncrypter encrypter)
        {
            this.users = dBUserRepository;
            this.encrypter = encrypter;
        }

        protected UserRepository()
        {

        }

        public void ChangePassword(int userID, string currentPassword, string newPassword)
        {
            var user = users.Get(userID);
            user.SetPassword(newPassword, encrypter);
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

        public UserDto Login(string login, string password)
        {
            var user = users.Get(login);
            if (user == null) throw new WojtekException("Invalid credentials");
            string hash = encrypter.GetHash(password, user.Salt);
            if (hash != user.Password)
            {
                throw new WojtekException("Invalid credentials");
            }
            return Mappers.AutoMapperConfig.Initialize().Map<User, UserDto>(user);
        }

        public void Register(UserModel register)
        {
            var user = users.Get(register.Login);
            if (user != null)
            {
                throw new WojtekException($"The user with login {register.Login} already exist.");
            }
            user = new User(register.Login, register.Password, Role.User, encrypter);
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
