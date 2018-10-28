using System;
using System.Text.RegularExpressions;

namespace SerwisProduktow.Domain.Entities
{
    public class User
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");
        public int ID { get; protected set; }
        public string Login { get; protected set; }
        public string Password { get; protected set; }
        public int Status { get; protected set; }
        public string Salt { get; protected set; }
        public int RoleID { get; protected set; }
        public DateTime Created_at { get; protected set; }

        public virtual Role Role { get; protected set; }

        protected User()
        {

        }

        public User(string login, string password, Role role, string salt)
        {
            SetLogin(login);
            SetPassword(password, salt);
            SetRole(role);
            SetStatus(0);
            Created_at = DateTime.Now;
        }
        public void SetLogin(string login)
        {
            if (String.IsNullOrEmpty(login)) throw new Exception();
            if (!NameRegex.IsMatch(login)) throw new Exception();
            Login = login;
        }
        public void SetPassword(string password, string salt)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new Exception();
            if (string.IsNullOrWhiteSpace(salt)) throw new Exception();
            if (password.Length < 8) throw new Exception();
            if (password.Length > 32) throw new Exception();

            Password = password;
            Salt = salt;
        }
        public void SetRole (Role role)
        {
            RoleID = role.ID;
        }
        public void SetStatus(int status)
        {
            if (status == 0 || status == 1) Status = status;
            else throw new Exception();
        }
    }
}
