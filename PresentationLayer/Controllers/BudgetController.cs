using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var budgets = await _budgetService.GetBudgetsAsync();

            return Ok(budgets);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var budget = await _budgetService.GetBudgetByIdAsync(id);

                return Ok(budget);
            }
            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    case "Budget not found!":
                        {
                            return NotFound();
                        }
                    default: return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet("{date:DateTime}")]
        public async Task<IActionResult> GetByMonth(DateTime date)
        {
            try
            {
                var budget = await _budgetService.GetBudgetsByMonthAsync(date);

                return Ok(budget);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(BudgetDto budget)
        {
            try
            {
                var newBudget = await _budgetService.AddBudgetAsync(budget);

                return CreatedAtAction(nameof(Add), newBudget);
            }
            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    case "Budget already exists!":
                        {
                            return Conflict(ex.Message);
                        }
                    default: return BadRequest(ex.Message);
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            {
                var budget = await _budgetService.DeleteBudgetByIdAsync(id);

                return Ok(budget);
            }
            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    case "Budget not found!":
                        {
                            return NotFound();
                        }
                    default: return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(BudgetDto budget)
        {
            await _budgetService.UpdateBudgetAsync(budget);

            return Ok(budget);
        }
    }
}
