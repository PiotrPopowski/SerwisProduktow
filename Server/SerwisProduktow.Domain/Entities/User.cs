using SerwisProduktow.Domain.Exceptions;
using SerwisProduktow.Domain.Interfaces;
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
        public string UserName { get; protected set; }
        public int Status { get; protected set; }
        public string Salt { get; protected set; }
        public int RoleID { get; protected set; }
        public DateTime Created_at { get; protected set; }

        public virtual Role Role { get; protected set; }

        protected User()
        {

        }

        public User(string login, string password, Role role, string name, IEncrypter encrypter)
        {
            SetLogin(login);
            SetPassword(password, encrypter);
            SetUserName(name);
            SetRole(role);
            SetStatus(0);
            Created_at = DateTime.Now;
        }
        public void SetLogin(string login)
        {
            if (login.Length > 15) throw new WojtekException(WojtekCodes.LongLogin);
            if (login.Length < 4) throw new WojtekException(WojtekCodes.ShortLogin);
            if (String.IsNullOrEmpty(login)) throw new WojtekException(WojtekCodes.NullLogin);
            if (!NameRegex.IsMatch(login)) throw new WojtekException(WojtekCodes.WrongCharacterLogin);
            Login = login;
        }
        public void SetUserName(string userName)
        {
            if (userName.Length > 15) throw new WojtekException(WojtekCodes.LongUserName);
            if (userName.Length < 4) throw new WojtekException(WojtekCodes.ShortUserName);
            if (String.IsNullOrEmpty(userName)) throw new WojtekException(WojtekCodes.WrongUserName);
            if (!NameRegex.IsMatch(userName)) throw new WojtekException(WojtekCodes.WrongUserName);
            UserName = userName;
        }
        public void SetPassword(string password, IEncrypter encrypter)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new WojtekException(WojtekCodes.NullPassword);
            if (password.Length < 8) throw new WojtekException(WojtekCodes.ShortPassword);
            if (password.Length > 32) throw new WojtekException(WojtekCodes.LongPassword);
            string salt = encrypter.GetSalt(password);
            string hash = encrypter.GetHash(password, salt);
            Password = hash;
            Salt = salt;
        }
        public void SetRole (Role role)
        {
            RoleID = role.ID;
        }
        public void SetStatus(int status)
        {
            if (status == 0 || status == 1) Status = status;
            else throw new WojtekException(WojtekCodes.WrongStatus);
        }
    }
}
