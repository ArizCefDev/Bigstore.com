using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EntityDTO
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string? Username { get; set; }
        public string? Salt { get; set; }
        public string? Password { get; set; }
        public string? PasswordHash { get; set; }
       
        
    }
}
