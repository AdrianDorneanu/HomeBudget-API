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
            var newBudget = await _budgetRepository.AddBudgetAsync(budget);

            if (newBudget == null)
            {
                return null;
            }

            return newBudget;
        }

        public async Task DeleteBudgetByIdAsync(Guid id)
        {
            await _budgetRepository.DeleteBudgetByIdAsync(id);
        }

        public async Task<Budget?> GetBudgetByIdAsync(Guid id)
        {
            var budget = await _budgetRepository.GetBudgetByIdAsync(id);

            if (budget == null)
            {
                return null;
            }

            return budget;
        }

        public async Task<IEnumerable<Budget>> GetBudgetsAsync()
        {
            return await _budgetRepository.GetBudgetsAsync();
        }

        public Task UpdateBudgetAsync(Budget budget)
        {
            throw new NotImplementedException();
        }
    }
}
