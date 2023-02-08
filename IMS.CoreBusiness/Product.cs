using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = " The Product Name field is required.")]
        public string ProductName { get; set; } = string.Empty; 

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to {0}")]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than or equal to {0}")]
        public double Price { get; set; }

    }
}
