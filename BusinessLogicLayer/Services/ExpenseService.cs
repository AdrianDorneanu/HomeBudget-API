using AutoMapper;
using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _mapper;

        public ExpenseService(IExpenseRepository expenseRepository, IBudgetRepository budgetRepository)
        {
            _expenseRepository = expenseRepository;
            _budgetRepository = budgetRepository;

            var _configExpense = new MapperConfiguration(cfg => cfg.CreateMap<Expense, ExpenseDto>().ReverseMap());

            _mapper = new Mapper(_configExpense);
        }

        private async Task UpdateBudgetAmountWithNewAmount(ExpenseDto expense)
        {
            var budget = await _budgetRepository.GetBudgetByIdAsync(expense.BudgetId);

            if (budget.TotalAmount == 0)
            {
                throw new Exception("Total amount for this budget is 0!");
            }

            budget.AmountSpent = budget.AmountSpent + expense.Amount;
            budget.TotalAmount = budget.TotalAmount - expense.Amount;
        }

        public async Task<ExpenseDto> AddExpenseAsync(ExpenseDto expense)
        {
            var newExpense = new Expense()
            {
                Id = new Guid(),
                Buyer = expense.Buyer,
                Name = expense.Name,
                Amount = expense.Amount,
                DateOfBuying = expense.DateOfBuying,
                BudgetId = expense.BudgetId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            ExpenseDto newExpenseDto = _mapper.Map<Expense, ExpenseDto>(newExpense);

            await UpdateBudgetAmountWithNewAmount(newExpenseDto);
            await _expenseRepository.AddExpenseAsync(newExpense);

            return newExpenseDto;
        }

        public async Task<IEnumerable<ExpenseDto>> GetExpensesAsync()
        {
            var expenses = await _expenseRepository.GetExpensesAsync();

            IEnumerable<ExpenseDto> expensesDto = _mapper.Map<IEnumerable<Expense>, IEnumerable<ExpenseDto>>(expenses);

            return expensesDto;
        }

        public async Task<IEnumerable<ExpenseDto>> GetExpensesByBudgetAsync(Guid id)
        {
            var expenses = await _expenseRepository.GetExpensesByBudgetAsync(id);

            IEnumerable<ExpenseDto> expensesDto = _mapper.Map<IEnumerable<Expense>, IEnumerable<ExpenseDto>>(expenses);

            return expensesDto;
        }

        public async Task<ExpenseDto> DeleteExpenseByIdAsync(Guid id)
        {
            var expense = await _expenseRepository.GetExpenseById(id);
            var budget = await _budgetRepository.GetBudgetByIdAsync(expense.BudgetId);

            budget.TotalAmount += expense.Amount;
            budget.AmountSpent -= expense.Amount;

            var deletedExpense = await _expenseRepository.DeleteExpenseByIdAsync(id);

            ExpenseDto deletedExpenseDto = _mapper.Map<Expense, ExpenseDto>(deletedExpense);

            return deletedExpenseDto;
        }
    }
}
