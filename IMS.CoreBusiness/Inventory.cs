using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness
{
    public class Inventory
    {
        public int InventoryId { get; set; }

        [Required(ErrorMessage = "The Inventory Name field is required.")]
        public string? InventoryName { get; set; }

        [Range(0, int.MaxValue, ErrorMessage ="Quantity must be greater than or equal to {0}")]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than or equal to {0}")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please Select a Size.")]
        public string Size { get; set; }

        public bool IsItemActive { get; set; } = true;

        public List<ProductInventory>? ProductInventories { get; set; }
    }
}