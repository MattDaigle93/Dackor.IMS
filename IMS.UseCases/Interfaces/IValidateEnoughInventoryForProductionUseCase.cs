using IMS.CoreBusiness;

namespace IMS.UseCases
{
    public interface IValidateEnoughInventoryForProductionUseCase
    {
        Task<bool> ExecuteAsync(Product product, int quantity);
    }
}