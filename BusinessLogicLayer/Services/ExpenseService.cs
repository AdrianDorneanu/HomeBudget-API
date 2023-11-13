using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<IEnumerable<Expense>> GetExpensesAsync()
        {
            var expenses = await _expenseRepository.GetExpensesAsync();

            return expenses;
        }

        public async Task<IEnumerable<Expense>> GetExpensesByBudgetAsync(Guid id)
        {
            var expenses = await _expenseRepository.GetExpensesByBudgetAsync(id);

            return expenses;
        }
    }
}
