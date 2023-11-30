using BusinessLogicLayer.Dtos;

namespace BusinessLogicLayer.Interfaces
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseDto>> GetExpensesAsync();
        Task<IEnumerable<ExpenseDto>> GetExpensesByBudgetAsync(Guid id);
        Task<ExpenseDto> AddExpenseAsync(ExpenseDto expense);
        Task<ExpenseDto> DeleteExpenseByIdAsync(Guid id);
    }
}
