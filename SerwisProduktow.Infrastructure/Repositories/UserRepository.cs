using SerwisProduktow.Domain.Entities;
using SerwisProduktow.Domain.Repositories;
using SerwisProduktow.Infrastructure.DTO;
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
            return new UserDto()
            {
                ID = user.ID,
                Login = user.Login,
                Role = Role.GetRoleName(user.RoleID),
                Status = user.Status,
                Created_at = user.Created_at
            };
        }
        public UserDto Get(int id)
        {
            return Get(users.Get(id).Login);
        }

        public IEnumerable<UserDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Login(string login, string password)
        {
            throw new NotImplementedException();
        }

        public void Register(string login, string password)
        {
            var user = users.Get(login);
            if (user != null)
            {
                throw new Exception();
            }

            string salt = Guid.NewGuid().ToString();
            user = new User(login, password, Role.User, salt);
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
