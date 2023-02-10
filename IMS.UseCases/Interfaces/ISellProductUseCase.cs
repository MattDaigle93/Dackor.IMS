using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Interfaces
{
    public interface ISellProductUseCase
    {
        IProductRepository ProductRepository { get; }

        Task ExecuteAsync(string salesOrderNumber, Product product, int quantity, string doneBy);
    }
}