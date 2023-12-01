using DataAccessLayer.Entities;

namespace DataAccessLayer.Data
{
    public static class DBInitializer
    {
        public static void InitializeDatabase(ApplicationDbContext applicationDbContext)
        {
            if (applicationDbContext.Budgets.Any() || applicationDbContext.Expenses.Any())
            {
                return;
            }

            var sportExpense = new Expense
            {
                Id = new Guid(),
                Buyer = "Puiu",
                Name = "Colanti sport",
                Amount = 200,
                DateOfBuying = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                BudgetId = new Guid("d156b2f6-f714-4636-8c55-a7905b7648b5"),
            };

            var sportBudget = new Budget
            {
                Id = new Guid("d156b2f6-f714-4636-8c55-a7905b7648b5"),
                Name = "Sport",
                TotalAmount = 2500,
                AmountSpent = 200,
                Date = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Expenses = new List<Expense> { sportExpense }
            };

            applicationDbContext.Budgets.Add(sportBudget);
            applicationDbContext.Expenses.Add(sportExpense);

            applicationDbContext.SaveChanges();
        }
    }
}
