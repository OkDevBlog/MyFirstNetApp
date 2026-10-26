using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCrossApp.Data;
using MyCrossApp.Models;

namespace MyCrossApp.Services;

public class BudgetService : IBudgetService
{
    public async Task InitializeDatabaseAsync()
    {
        using var db = new AppDbContext();
        await db.Database.EnsureCreatedAsync();
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        using var db = new AppDbContext();
        return await db.Categories.AsNoTracking().ToListAsync();
    }

    public async Task<List<Transaction>> GetTransactionsAsync(int? categoryId = null, string? searchQuery = null)
    {
        using var db = new AppDbContext();
        var query = db.Transactions
            .Include(t => t.Category)
            .AsNoTracking()
            .AsQueryable();

        if (categoryId.HasValue && categoryId.Value > 0)
        {
            query = query.Where(t => t.CategoryId == categoryId.Value);
        }

        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            var search = searchQuery.Trim().ToLower();
            query = query.Where(t => t.Title.ToLower().Contains(search) ||
                                     t.Notes.ToLower().Contains(search));
        }

        return await query
            .OrderByDescending(t => t.TransactionDate)
            .ToListAsync();
    }

    public async Task<Transaction> AddTransactionAsync(Transaction transaction)
    {
        using var db = new AppDbContext();
        db.Transactions.Add(transaction);
        await db.SaveChangesAsync();

        return await db.Transactions
            .Include(t => t.Category)
            .FirstAsync(t => t.Id == transaction.Id);
    }

    public async Task<Transaction> UpdateTransactionAsync(Transaction transaction)
    {
        using var db = new AppDbContext();
        var existing = await db.Transactions.FindAsync(transaction.Id);
        if (existing != null)
        {
            existing.Title = transaction.Title;
            existing.Amount = transaction.Amount;
            existing.IsExpense = transaction.IsExpense;
            existing.CategoryId = transaction.CategoryId;
            existing.Notes = transaction.Notes;
            existing.TransactionDate = transaction.TransactionDate;
            await db.SaveChangesAsync();
        }

        return await db.Transactions
            .Include(t => t.Category)
            .FirstAsync(t => t.Id == transaction.Id);
    }

    public async Task DeleteTransactionAsync(int transactionId)
    {
        using var db = new AppDbContext();
        var item = await db.Transactions.FindAsync(transactionId);
        if (item != null)
        {
            db.Transactions.Remove(item);
            await db.SaveChangesAsync();
        }
    }

    public async Task<decimal> GetTotalBalanceAsync()
    {
        using var db = new AppDbContext();
        var income = await db.Transactions.Where(t => !t.IsExpense).SumAsync(t => (decimal?)t.Amount) ?? 0m;
        var expense = await db.Transactions.Where(t => t.IsExpense).SumAsync(t => (decimal?)t.Amount) ?? 0m;
        return income - expense;
    }

    public async Task<decimal> GetTotalExpensesCurrentMonthAsync()
    {
        using var db = new AppDbContext();
        var now = DateTime.Now;
        var startOfMonth = new DateTime(now.Year, now.Month, 1);
        var endOfMonth = startOfMonth.AddMonths(1).AddTicks(-1);

        return await db.Transactions
            .Where(t => t.IsExpense && t.TransactionDate >= startOfMonth && t.TransactionDate <= endOfMonth)
            .SumAsync(t => (decimal?)t.Amount) ?? 0m;
    }

    public async Task<decimal> GetTotalIncomeCurrentMonthAsync()
    {
        using var db = new AppDbContext();
        var now = DateTime.Now;
        var startOfMonth = new DateTime(now.Year, now.Month, 1);
        var endOfMonth = startOfMonth.AddMonths(1).AddTicks(-1);

        return await db.Transactions
            .Where(t => !t.IsExpense && t.TransactionDate >= startOfMonth && t.TransactionDate <= endOfMonth)
            .SumAsync(t => (decimal?)t.Amount) ?? 0m;
    }
}
