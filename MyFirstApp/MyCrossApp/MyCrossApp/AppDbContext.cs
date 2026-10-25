using Microsoft.EntityFrameworkCore;
using MyCrossApp.Models;

namespace MyCrossApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<NoteModel> Notes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // هذا السطر سينشئ ملف قاعدة البيانات تلقائياً
        optionsBuilder.UseSqlite("Data Source=myapp.db");
    }
}