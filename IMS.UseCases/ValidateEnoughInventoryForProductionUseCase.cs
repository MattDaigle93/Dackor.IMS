using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases
{
    public class ValidateEnoughInventoryForProductionUseCase
    {
        private readonly IProductRepository productRepository;

        public ValidateEnoughInventoryForProductionUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<bool> ExecuteAsync(Product product, int quantity)
        {
            var prod = await productRepository.GetProductByIdAsync(product.ProductId);
            foreach(var pi in prod.ProductInventories)
            {
                if (pi.InventoryQuantity * quantity > pi.Inventory.Quantity)
                    return false;
            }

            return true;
        }
    }
}
