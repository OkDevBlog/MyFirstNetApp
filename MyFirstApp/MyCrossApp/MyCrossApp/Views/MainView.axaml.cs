using Avalonia.Controls;
using Avalonia.Interactivity;
using MyCrossApp.Data;
using MyCrossApp.Models;

namespace MyCrossApp.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        // التأكد من إنتاج قاعدة البيانات والجدول عند تشغيل التطبيق
        using var db = new AppDbContext();
        db.Database.EnsureCreated();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        // حفظ بيانات حقيقية في ملف SQLite عند النقر على الزر
        using var db = new AppDbContext();
        db.Notes.Add(new NoteModel { Content = "Hello from SQLite!" });
        db.SaveChanges();

        var textBlock = this.FindControl<TextBlock>("MyMessageText");
        if (textBlock != null)
        {
            textBlock.Text = "Saved to SQLite database successfully!";
        }
    }
}