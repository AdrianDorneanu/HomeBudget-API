using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var expenses = await _expenseService.GetExpensesAsync();

            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByBudget(Guid id)
        {
            var expenses = await _expenseService.GetExpensesByBudgetAsync(id);

            return Ok(expenses);
        }
    }
}
