using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetExpensesAsync();
        Task<IEnumerable<Expense>> GetExpensesByBudgetAsync(Guid id);
        Task<Expense> AddExpenseAsync(Expense expense);
        Task<Expense> DeleteExpenseByIdAsync(Guid id);
        Task<Expense> GetExpenseById(Guid id);
    }
}
