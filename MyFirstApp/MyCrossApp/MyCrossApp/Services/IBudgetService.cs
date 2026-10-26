using System.Collections.Generic;
using System.Threading.Tasks;
using MyCrossApp.Models;

namespace MyCrossApp.Services;

public interface IBudgetService
{
    Task InitializeDatabaseAsync();
    Task<List<Category>> GetCategoriesAsync();
    Task<List<Transaction>> GetTransactionsAsync(int? categoryId = null, string? searchQuery = null);
    Task<Transaction> AddTransactionAsync(Transaction transaction);
    Task<Transaction> UpdateTransactionAsync(Transaction transaction);
    Task DeleteTransactionAsync(int transactionId);
    Task<decimal> GetTotalBalanceAsync();
    Task<decimal> GetTotalExpensesCurrentMonthAsync();
    Task<decimal> GetTotalIncomeCurrentMonthAsync();
}
