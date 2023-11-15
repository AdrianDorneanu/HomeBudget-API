﻿using AutoMapper;
using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
            var _configExpense = new MapperConfiguration(cfg => cfg.CreateMap<Expense, ExpenseDto>().ReverseMap());

            _mapper = new Mapper(_configExpense);
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
    }
}
