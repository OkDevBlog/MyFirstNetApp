using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MyCrossApp.Helpers;

namespace MyCrossApp.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = "📁";
    public string ColorHex { get; set; } = "#3498db";
    public decimal MonthlyBudget { get; set; }

    /// <summary>
    /// رسم متجه SVG نقي يحل مشكلة مربعات الإيموجي في المتصفح والأنظمة المختلفة
    /// </summary>
    [NotMapped]
    public string IconData => AppIcons.GetCategoryIcon(Icon, Name);

    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
