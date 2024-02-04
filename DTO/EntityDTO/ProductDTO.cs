using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EntityDTO
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string? ImageURL { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }

        [Range(1, 100)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Range(1, 100)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }
        public string? Status { get; set; }
        public string? Star1 { get; set; }
        public string? Star2 { get; set; }
        public string? Star3 { get; set; }
        public string? Star4 { get; set; }
        public string? Star5 { get; set; }
        public DateTime Date { get; set; }

        public int CategoryID { get; set; }
        public CategoryDTO? CategoryDTO { get; set; }
    }
}
