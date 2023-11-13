using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _budgetRepository;

        public BudgetService(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public async Task<Budget?> AddBudgetAsync(Budget budget)
        {
            var existingBudget = await _budgetRepository.GetBudgetByName(budget.Name);

            if (existingBudget is not null)
            {
                throw new Exception("Budget already exists!");
            }

            var newBudget = new Budget()
            {
                Id = new Guid(),
                Name = budget.Name,
                TotalAmount = budget.TotalAmount,
                AmountSpent = budget.AmountSpent,
                Date = budget.Date,
                Expenses = Array.Empty<Expense>(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            await _budgetRepository.AddBudgetAsync(newBudget);

            return newBudget;
        }

        public async Task DeleteBudgetByIdAsync(Guid id)
        {
            await _budgetRepository.DeleteBudgetByIdAsync(id);
        }

        public async Task<Budget?> GetBudgetByIdAsync(Guid id)
        {
            var budget = await _budgetRepository.GetBudgetByIdAsync(id);

            if (budget is null)
            {
                return null;
            }

            return budget;
        }

        public async Task<IEnumerable<Budget>> GetBudgetsAsync()
        {
            return await _budgetRepository.GetBudgetsAsync();
        }

        public async Task UpdateBudgetAsync(Budget budget)
        {
            var updatedBudget = new Budget()
            {
                Id = budget.Id,
                Name = budget.Name,
                TotalAmount = budget.TotalAmount,
                AmountSpent = budget.AmountSpent,
                CreatedAt = budget.CreatedAt,
                Date = budget.Date,
                UpdatedAt = DateTime.Now,
            };

            await _budgetRepository.UpdateBudgetAsync(updatedBudget);
        }
    }
}
