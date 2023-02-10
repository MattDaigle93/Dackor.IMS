using System.ComponentModel.DataAnnotations;

namespace DackorInventoryManagementSystem.ViewModels
{
    public class SellViewModel
    {
        [Required(ErrorMessage = "Please enter a Sales Order Number.")]
        public string SalesOrderNumber { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter a Product Name.")]
        public string ProductName { get; set; }

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int QuantityToSell { get; set; }

        /*[Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Price must be greater than 0.")]*/
        public double ProductPrice { get; set; }
    }
}
