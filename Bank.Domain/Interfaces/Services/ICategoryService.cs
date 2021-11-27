using Bank.Domain.Entities;

namespace Bank.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        string GetCategory(Trade trade);
    }
}
