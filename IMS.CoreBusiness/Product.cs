using IMS.CoreBusiness.Validations;
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

        [Required(ErrorMessage = "The Product Name field is required.")]
        public string ProductName { get; set; } = string.Empty; 

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to {0}")]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than or equal to {0}")]
        [Product_EnsurePriceIsGreatherThanInventoriesPrice]
        public double Price { get; set; }

        public bool IsActive { get; set; } = true;

        public List<ProductInventory>? ProductInventories { get; set; }

        public double TotalInventoryCost()
        {
            return this.ProductInventories.Sum(x => x.Inventory?.Price * x.InventoryQuantity ?? 0);
        }

        public bool ValidatePricing()
        {
            if (ProductInventories == null || ProductInventories.Count <= 0) return true;
           
            if (this.TotalInventoryCost() > Price) return false;

            return true;
        }
    }
}
