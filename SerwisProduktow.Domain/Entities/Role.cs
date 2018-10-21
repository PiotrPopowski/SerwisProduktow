using System.Collections.Generic;

namespace SerwisProduktow.Domain.Entities
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        public int ID { get; protected set; }
        public string Name { get; protected set; }

        public virtual ICollection<User> Users { get; set; }

        public static Role User => new Role { ID = 1, Name = "User" };
        public static Role Admin => new Role { ID = 2, Name = "Admin" };
        public static string GetRoleName(int id)
        {
            switch(id)
            {
                case 1: return "User";
                case 2: return "Admin";
                default: return "";
            }
        }
    }
}
