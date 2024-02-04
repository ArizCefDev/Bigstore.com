using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EntityDTO
{
    public class MessageDTO
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Text { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
