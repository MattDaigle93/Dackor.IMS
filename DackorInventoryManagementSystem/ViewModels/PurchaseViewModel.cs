using IMS.CoreBusiness;
using System.ComponentModel.DataAnnotations;

namespace DackorInventoryManagementSystem.Shared.ViewModels
{
    public class PurchaseViewModel
    {
        [Required(ErrorMessage = "Please enter a PO#")]
        public string PurchaseOrder { get; set; }

        [Required]
        public int InentoryId { get; set; }

        [Required]
        public string InventoryName { get; set; }

        [Required]
        [Range(minimum:1, maximum:int.MaxValue, ErrorMessage ="Quantity must be greater than 0")]
        public int QuantityToPurchase { get; set; }

        public double InventoryPrice { get; set; }
    }
}
