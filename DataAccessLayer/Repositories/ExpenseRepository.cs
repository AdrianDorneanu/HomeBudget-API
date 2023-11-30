using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ExpenseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Expense>> GetExpensesAsync()
        {
            return await _dbContext.Expenses.ToListAsync();
        }

        public async Task<IEnumerable<Expense>> GetExpensesByBudgetAsync(Guid id)
        {
            var expenses = await _dbContext.Expenses.Where(x => x.Budget.Id == id).ToListAsync();

            return expenses;
        }
        public async Task<Expense> GetExpenseById(Guid id)
        {
            var expense = await _dbContext.Expenses.FirstOrDefaultAsync(x => x.Id == id);

            return expense;
        }

        public async Task<Expense> AddExpenseAsync(Expense expense)
        {
            _dbContext.Expenses.Add(expense);

            await _dbContext.SaveChangesAsync();

            return expense;
        }
        public async Task<Expense> DeleteExpenseByIdAsync(Guid id)
        {
            var expense = await _dbContext.Expenses.FirstAsync(expense => expense.Id == id);

            _dbContext.Expenses.Remove(expense);

            await _dbContext.SaveChangesAsync();

            return expense;
        }
    }
}
