using IMS.CoreBusiness;
using IMS.UseCases.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories
{
    public class ViewInventoriesByNameUseCase : IViewInventoriesByNameUseCase
    {
        private readonly IInventoryRepository inventoryRepository;

        public ViewInventoriesByNameUseCase(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }

        public async Task<IEnumerable<Inventory>> ExcecuteAsync(string name = "")
        {
            return await this.inventoryRepository.GetInventoriesByName(name);
        }
    }
}