using AutoMapper;
using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _mapper;

        public BudgetService(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;

            var _configBudget = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Budget, BudgetDto>().ReverseMap();
                cfg.CreateMap<Expense, ExpenseDto>().ReverseMap();
            });

            _mapper = new Mapper(_configBudget);

        }

        public async Task<BudgetDto> AddBudgetAsync(BudgetDto budget)
        {
            var existingBudget = await _budgetRepository.GetBudgetByName(budget.Name, budget.Date);

            if (existingBudget is not null)
            {
                throw new Exception("Budget already exists!");
            }

            var createdBudget = await _budgetRepository.AddBudgetAsync(new Budget
            {
                Id = new Guid(),
                Name = budget.Name,
                TotalAmount = budget.TotalAmount,
                AmountSpent = budget.AmountSpent,
                Date = budget.Date,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            });

            BudgetDto createdBudgetDto = _mapper.Map<Budget, BudgetDto>(createdBudget);

            return createdBudgetDto;
        }

        public async Task<BudgetDto> DeleteBudgetByIdAsync(Guid id)
        {
            var budget = await _budgetRepository.DeleteBudgetByIdAsync(id);

            if (budget is null)
            {
                throw new Exception("Budget not found!");
            }

            BudgetDto budgetDto = _mapper.Map<Budget, BudgetDto>(budget);


            return budgetDto;
        }

        public async Task<BudgetDto> GetBudgetByIdAsync(Guid id)
        {
            var budget = await _budgetRepository.GetBudgetByIdAsync(id);

            BudgetDto budgetDto = _mapper.Map<Budget, BudgetDto>(budget);

            if (budgetDto is null)
            {
                throw new Exception("Budget not found!");
            }

            return budgetDto;
        }

        public async Task<IEnumerable<BudgetDto>> GetBudgetsAsync()
        {
            var budgets = await _budgetRepository.GetBudgetsAsync();

            IEnumerable<BudgetDto> budgetsDto = _mapper.Map<IEnumerable<Budget>, IEnumerable<BudgetDto>>(budgets);

            return budgetsDto;
        }

        public async Task<BudgetDto> UpdateBudgetAsync(BudgetDto budget)
        {
            var updatedBudget = await _budgetRepository.UpdateBudgetAsync(new Budget()
            {
                Id = budget.Id,
                Name = budget.Name,
                TotalAmount = budget.TotalAmount,
                AmountSpent = budget.AmountSpent,
                CreatedAt = budget.CreatedAt,
                Date = budget.Date,
                UpdatedAt = DateTime.Now,
            });

            BudgetDto updatedBudgetDto = _mapper.Map<Budget, BudgetDto>(updatedBudget);

            return updatedBudgetDto;
        }
        public async Task<IEnumerable<BudgetDto>> GetBudgetsByMonthAsync(DateTime date)
        {
            var budgets = await _budgetRepository.GetBudgetsByMonthAsync(date);

            IEnumerable<BudgetDto> budgetsDto = _mapper.Map<IEnumerable<Budget>, IEnumerable<BudgetDto>>(budgets);

            return budgetsDto;
        }

    }
}
