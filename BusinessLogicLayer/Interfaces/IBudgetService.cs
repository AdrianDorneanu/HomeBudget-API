using BusinessLogicLayer.Dtos;

namespace BusinessLogicLayer.Interfaces
{
    public interface IBudgetService
    {
        Task<IEnumerable<BudgetDto>> GetBudgetsAsync();
        Task<BudgetDto> GetBudgetByIdAsync(Guid id);
        Task<BudgetDto> AddBudgetAsync(BudgetDto budget);
        Task<BudgetDto> UpdateBudgetAsync(BudgetDto budget);
        Task<BudgetDto> DeleteBudgetByIdAsync(Guid id);
        Task<IEnumerable<BudgetDto>> GetBudgetsByMonthAsync(DateTime date);
    }
}
