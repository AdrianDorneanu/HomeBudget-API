using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Interfaces
{
    public interface IBudgetService
    {
        Task<IEnumerable<Budget>> GetBudgetsAsync();
        Task<Budget> GetBudgetByIdAsync(Guid id);
        Task<Budget> AddBudgetAsync(Budget budget);
        Task UpdateBudgetAsync(Budget budget);
        Task DeleteBudgetByIdAsync(Guid id);
    }
}
