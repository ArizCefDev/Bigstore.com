using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class User
    {
        public int ID { get; set; }
        public string? Username { get; set; }
        public string? Salt { get; set; }
        public string? PasswordHash { get; set; }
        public int RoleID { get; set; }
        public Role? Role { get; set; }
    }
}
