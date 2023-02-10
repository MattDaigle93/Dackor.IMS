using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases
{
    public interface ISellProductUseCase
    {
        IProductRepository ProductRepository { get; }

        Task ExecuteAsync(string salesOrderNumber, Product product, int quantity, string doneBy);
    }
}