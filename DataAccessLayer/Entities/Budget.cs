namespace DataAccessLayer.Entities
{
    public class Budget
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double TotalAmount { get; set; }
        public double AmountSpent { get; set; }
        public ICollection<Expense>? Expenses { get; set; }
        public DateTime Date {  get; set; }
        public DateTime CreatedAt {  get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
