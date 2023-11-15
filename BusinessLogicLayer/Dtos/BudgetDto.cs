namespace BusinessLogicLayer.Dtos
{
    public class BudgetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double TotalAmount { get; set; }
        public double AmountSpent { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<ExpenseDto> Expenses { get; set; }
    }
}
