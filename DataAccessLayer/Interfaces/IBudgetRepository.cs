using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IBudgetRepository
    {
        Task<IEnumerable<Budget>> GetBudgetsAsync();
        Task<Budget> GetBudgetByIdAsync(Guid id);
        Task<Budget> AddBudgetAsync(Budget budget);
        Task<Budget> UpdateBudgetAsync(Budget budget);
        Task DeleteBudgetByIdAsync(Guid id);
        Task<Budget> GetBudgetByName(string name);
    }
}
