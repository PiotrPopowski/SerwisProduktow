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
            var user = users.Get(id);
            return Mappers.AutoMapperConfig.Initialize().Map<User, UserDto>(user);
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
            if (user == null) throw new WojtekException(WojtekCodes.WrongCredentials);
            string hash = encrypter.GetHash(password, user.Salt);
            if (hash != user.Password)
            {
                throw new WojtekException(WojtekCodes.WrongCredentials);
            }
            return Mappers.AutoMapperConfig.Initialize().Map<User, UserDto>(user);
        }

        public void Register(UserModel register)
        {
            var user = users.Get(register.Login);
            if (user != null)
            {
                throw new WojtekException(WojtekCodes.LoginTaken);
            }

            foreach (User u in users.GetAll())
            {
                if (u.UserName == register.UserName) throw new WojtekException(WojtekCodes.UserNameTaken);
            }

            user = new User(register.Login, register.Password, Role.User, register.UserName, encrypter);
            users.Add(user);
        }

        public void Remove(int userID, int userIdToRemove)
        {
            User currentUser = users.Get(userID);
            if(currentUser.Role.Name=="Admin" || currentUser.ID==userIdToRemove)
                users.Remove(userIdToRemove);
            else
                throw new WojtekException(WojtekCodes.PermissionDenied);
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
        public void SetUserName(string name,  int userID)
        {
            var user = users.Get(userID);
            foreach(User u in users.GetAll())
            {
                if (u.UserName == name) throw new WojtekException(WojtekCodes.UserNameTaken); 
            }
            user.SetUserName(name);
            
        }
    }
}
