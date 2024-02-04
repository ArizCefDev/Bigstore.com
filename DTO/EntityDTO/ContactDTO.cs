using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EntityDTO
{
    public class ContactDTO
    {
        public int ID { get; set; }
        public string? ImageURL { get; set; }
        public string? Address { get; set; }
        public string? Text { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public string? Map { get; set; }
    }
}
