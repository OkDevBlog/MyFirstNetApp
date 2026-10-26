using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using MyCrossApp.Models;

namespace MyCrossApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Transaction> Transactions => Set<Transaction>();

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string dbPath;
            if (OperatingSystem.IsBrowser())
            {
                dbPath = "smartbudget.db";
            }
            else
            {
                try
                {
                    var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    if (!string.IsNullOrEmpty(folder))
                    {
                        var appDir = Path.Combine(folder, "SmartBudget");
                        if (!Directory.Exists(appDir))
                        {
                            Directory.CreateDirectory(appDir);
                        }
                        dbPath = Path.Combine(appDir, "smartbudget.db");
                    }
                    else
                    {
                        dbPath = "smartbudget.db";
                    }
                }
                catch
                {
                    dbPath = "smartbudget.db";
                }
            }

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ضبط علاقة المعاملات بالتصنيفات
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Category)
            .WithMany(c => c.Transactions)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        // بذر تصنيفات افتراضية شائعة (Seed Data) برموز موحدة
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "طعام ومشروبات", Icon = "food", ColorHex = "#E74C3C", MonthlyBudget = 1000 },
            new Category { Id = 2, Name = "تسوق ومشتريات", Icon = "shopping", ColorHex = "#9B59B6", MonthlyBudget = 500 },
            new Category { Id = 3, Name = "مواصلات ونقل", Icon = "transport", ColorHex = "#3498DB", MonthlyBudget = 400 },
            new Category { Id = 4, Name = "فواتير وخدمات", Icon = "bills", ColorHex = "#E67E22", MonthlyBudget = 600 },
            new Category { Id = 5, Name = "صحة وعناية", Icon = "health", ColorHex = "#1ABC9C", MonthlyBudget = 300 },
            new Category { Id = 6, Name = "راتب ودخل إضافي", Icon = "salary", ColorHex = "#2ECC71", MonthlyBudget = 0 },
            new Category { Id = 7, Name = "أخرى", Icon = "other", ColorHex = "#7F8C8D", MonthlyBudget = 200 }
        );
    }
}
