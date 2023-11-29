using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IBudgetRepository
    {
        Task<IEnumerable<Budget>> GetBudgetsAsync();
        Task<Budget> GetBudgetByIdAsync(Guid id);
        Task<Budget> AddBudgetAsync(Budget budget);
        Task<Budget> UpdateBudgetAsync(Budget budget);
        Task<Budget?> DeleteBudgetByIdAsync(Guid id);
        Task<Budget> GetBudgetByName(string name, DateTime date);
        Task<IEnumerable<Budget>> GetBudgetsByMonthAsync(DateTime date);
    }
}
