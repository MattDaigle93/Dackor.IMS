using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Interfaces
{
    public interface ISellProductUseCase
    {
        Task ExecuteAsync(string salesOrderNumber, Product product, int quantity, string doneBy);
    }
}