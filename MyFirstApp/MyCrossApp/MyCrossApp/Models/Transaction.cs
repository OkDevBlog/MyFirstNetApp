using System;

namespace MyCrossApp.Models;

public class Transaction
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.Now;
    public string Notes { get; set; } = string.Empty;
    public bool IsExpense { get; set; } = true;

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public string FormattedAmount => IsExpense 
        ? $"-{Amount:N2} ريال" 
        : $"+{Amount:N2} ريال";

    public string AmountColor => IsExpense ? "#E74C3C" : "#2ECC71";

    public bool HasNotes => !string.IsNullOrWhiteSpace(Notes);
}
