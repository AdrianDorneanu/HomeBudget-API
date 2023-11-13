using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> GetExpensesAsync();
        Task<IEnumerable<Expense>> GetExpensesByBudgetAsync(Guid id);
    }
}
