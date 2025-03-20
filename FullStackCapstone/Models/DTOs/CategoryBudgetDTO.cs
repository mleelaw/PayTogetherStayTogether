namespace FullStackCapstone.Models.DTOs
{
    public class CategoryBudgetDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public decimal BudgetAmount { get; set; }
        public decimal RemainingBudget { get; set; }
        public decimal TotalExpenses { get; set; }
        public DateTime Month { get; set; }
    }
}