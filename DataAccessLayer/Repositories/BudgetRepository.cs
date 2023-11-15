using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BudgetRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Budget> AddBudgetAsync(Budget budget)
        {
            _dbContext.Budgets.Add(budget);

            await _dbContext.SaveChangesAsync();

            return budget;
        }

        public async Task DeleteBudgetByIdAsync(Guid id)
        {
            var budget = await _dbContext.Budgets.FirstOrDefaultAsync(b => b.Id == id);

            _dbContext.Budgets.Remove(budget);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Budget> GetBudgetByName(string name)
        {
            var budget = await _dbContext.Budgets.SingleOrDefaultAsync(b => b.Name == name);

            return budget;
        }

        public async Task<Budget> GetBudgetByIdAsync(Guid id)
        {
            var budget = await _dbContext.Budgets.FirstOrDefaultAsync(x => x.Id == id);

            return budget;
        }

        public async Task<IEnumerable<Budget>> GetBudgetsAsync()
        {
            return await _dbContext.Budgets.Include(_ => _.Expenses).ToListAsync();
        }

        public async Task UpdateBudgetAsync(Budget budget)
        {
            _dbContext.Budgets.Update(budget);

            await _dbContext.SaveChangesAsync();
        }
    }
}
