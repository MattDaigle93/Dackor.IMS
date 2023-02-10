using IMS.CoreBusiness;
using IMS.UseCases.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Activities
{
    public class PurchaseInventoryUseCase : IPurchaseInventoryUseCase
    {
        private readonly IInventoryTransactionRepository inventoryTransactionRepository;

        public PurchaseInventoryUseCase(
            IInventoryTransactionRepository inventoryTransactionRepository,
            IInventoryRepository inventoryRepository)
        {
            this.inventoryTransactionRepository = inventoryTransactionRepository;
            InventoryRepository = inventoryRepository;
        }

        public IInventoryRepository InventoryRepository { get; }

        public async Task ExecuteAsync(string poNumber, Inventory inventory, int quantity, string doneBy)
        {
            await inventoryTransactionRepository.PurchaseAsync(poNumber, inventory, quantity, inventory.Price, doneBy);

            //increases inventory quantity
            inventory.Quantity += quantity;
            await InventoryRepository.UpdateInventoryAsync(inventory);
        }
    }
}
