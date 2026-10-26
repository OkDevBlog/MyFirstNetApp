using System;

namespace MyCrossApp.Helpers;

public static class AppIcons
{
    // General / UI Vector Paths (Material Design SVG 24x24)
    public const string Wallet = "M21 18v1c0 1.1-.9 2-2 2H5c-1.11 0-2-.9-2-2V5c0-1.1.89-2 2-2h14c1.1 0 2 .9 2 2v1h-9c-1.11 0-2 .9-2 2v8c0 1.1.89 2 2 2h9zm-9-2h10V8H12v8zm4-2.5c-.83 0-1.5-.67-1.5-1.5s.67-1.5 1.5-1.5 1.5.67 1.5 1.5-.67 1.5-1.5 1.5z";
    public const string Refresh = "M17.65 6.35C16.2 4.9 14.21 4 12 4c-4.42 0-7.99 3.58-7.99 8s3.57 8 7.99 8c3.73 0 6.84-2.55 7.73-6h-2.08c-.82 2.33-3.04 4-5.65 4-3.31 0-6-2.69-6-6s2.69-6 6-6c1.66 0 3.14.69 4.22 1.78L13 11h7V4l-2.35 2.35z";
    public const string Add = "M19 13h-6v6h-2v-6H5v-2h6V5h2v6h6v2z";
    public const string Edit = "M3 17.25V21h3.75L17.81 9.94l-3.75-3.75L3 17.25zM20.71 7.04c.39-.39.39-1.02 0-1.41l-2.34-2.34c-.39-.39-1.02-.39-1.41 0l-1.83 1.83 3.75 3.75 1.83-1.83z";
    public const string Delete = "M6 19c0 1.1.9 2 2 2h8c1.1 0 2-.9 2-2V7H6v12zM19 4h-3.5l-1-1h-5l-1 1H5v2h14V4z";
    public const string Save = "M17 3H5c-1.11 0-2 .9-2 2v14c0 1.1.89 2 2 2h14c1.1 0 2-.9 2-2V7l-4-4zm-5 16c-1.66 0-3-1.34-3-3s1.34-3 3-3 3 1.34 3 3-1.34 3-3 3zm3-10H5V5h10v4z";
    public const string Close = "M19 6.41L17.59 5 12 10.59 6.41 5 5 6.41 10.59 12 5 17.59 6.41 19 12 13.41 17.59 19 19 17.59 13.41 12z";
    public const string Search = "M15.5 14h-.79l-.28-.27C15.41 12.59 16 11.11 16 9.5 16 5.91 13.09 3 9.5 3S3 5.91 3 9.5 5.91 16 9.5 16c1.61 0 3.09-.59 4.23-1.57l.27.28v.79l5 4.99L20.49 19l-4.99-5zm-6 0C7.01 14 5 11.99 5 9.5S7.01 5 9.5 5 14 7.01 14 9.5 11.99 14 9.5 14z";

    // Category Vector Paths
    public const string Food = "M11 9H9V2H7v7H5V2H3v7c0 2.12 1.66 3.84 3.75 3.97V22h2.5v-8.03c2.09-.13 3.75-1.85 3.75-3.97V2h-2v7zm5-3v8h2.5v8H21V2c-2.76 0-5 2.24-5 4z";
    public const string Shopping = "M19 6h-2c0-2.76-2.24-5-5-5S7 3.24 7 6H5c-1.1 0-2 .9-2 2v12c0 1.1.9 2 2 2h14c1.1 0 2-.9 2-2V8c0-1.1-.9-2-2-2zm-7-3c1.66 0 3 1.34 3 3H9c0-1.66 1.34-3 3-3zm7 17H5V8h14v12zm-7-8c-1.66 0-3-1.34-3-3H7c0 2.76 2.24 5 5 5s5-2.24 5-5h-2c0 1.66-1.34 3-3 3z";
    public const string Transport = "M18.92 6.01C18.72 5.42 18.16 5 17.5 5h-11c-.66 0-1.21.42-1.42 1.01L3 12v8c0 .55.45 1 1 1h1c.55 0 1-.45 1-1v-1h12v1c0 .55.45 1 1 1h1c.55 0 1-.45 1-1v-8l-2.08-5.99zM6.85 7h10.29l1.04 3H5.81l1.04-3zM19 17H5v-4.66l.12-.34h13.77l.11.34V17z M7.5 13c.83 0 1.5.67 1.5 1.5S8.33 16 7.5 16 6 15.33 6 14.5 6.67 13 7.5 13zm9 0c.83 0 1.5.67 1.5 1.5s-.67 1.5-1.5 1.5-1.5-.67-1.5-1.5.67-1.5 1.5-1.5z";
    public const string Bills = "M9 21c0 .55.45 1 1 1h4c.55 0 1-.45 1-1v-1H9v1zm3-19C8.14 2 5 5.14 5 9c0 2.38 1.19 4.47 3 5.74V17c0 .55.45 1 1 1h6c.55 0 1-.45 1-1v-2.26c1.81-1.27 3-3.36 3-5.74 0-3.86-3.14-7-7-7zm2.85 11.1l-.85.6V16h-4v-1.3l-.85-.6C7.8 13.16 7 11.42 7 9c0-2.76 2.24-5 5-5s5 2.24 5 5c0 2.42-.8 4.16-2.15 5.1z";
    public const string Health = "M19 10.5h-4.5V6c0-.83-.67-1.5-1.5-1.5s-1.5.67-1.5 1.5v4.5H7c-.83 0-1.5.67-1.5 1.5s.67 1.5 1.5 1.5h4.5V18c0 .83.67 1.5 1.5 1.5s1.5-.67 1.5-1.5v-4.5H19c.83 0 1.5-.67 1.5-1.5s-.67-1.5-1.5-1.5z";
    public const string Salary = "M11.8 10.9c-2.27-.59-3-1.2-3-2.15 0-1.09 1.01-1.85 2.7-1.85 1.78 0 2.44.85 2.5 2.1h2.21c-.07-1.72-1.12-3.3-3.21-3.81V3h-3v2.16c-1.94.42-3.5 1.68-3.5 3.61 0 2.31 1.91 3.46 4.7 4.13 2.5.6 3 1.48 3 2.41 0 .69-.49 1.79-2.7 1.79-2.06 0-2.87-.92-2.98-2.1h-2.2c.12 2.19 1.76 3.42 3.68 3.83V21h3v-2.15c1.95-.37 3.5-1.5 3.5-3.55 0-2.84-2.43-3.81-4.7-4.4z";
    public const string Other = "M21.41 11.58l-9-9C12.05 2.22 11.55 2 11 2H4c-1.1 0-2 .9-2 2v7c0 .55.22 1.05.59 1.42l9 9c.36.36.86.58 1.41.58.55 0 1.05-.22 1.41-.59l7-7c.37-.36.59-.86.59-1.41 0-.55-.23-1.06-.59-1.42zM5.5 7C4.67 7 4 6.33 4 5.5S4.67 4 5.5 4 7 4.67 7 5.5 6.33 7 5.5 7z";
    public const string AllCategories = "M4 11h5V5H4v6zm0 7h5v-6H4v6zm6 0h5v-6h-5v6zm6 0h5v-6h-5v6zm-6-7h5V5h-5v6zm6-6v6h5V5h-5z";

    public static string GetCategoryIcon(string? iconKey, string? categoryName = null)
    {
        // If iconKey is already an SVG path (starts with M or m)
        if (!string.IsNullOrEmpty(iconKey) && (iconKey.StartsWith("M") || iconKey.StartsWith("m")))
            return iconKey;

        // Match by key or emoji
        switch (iconKey)
        {
            case "🍔":
            case "food":
                return Food;
            case "🛍️":
            case "shopping":
                return Shopping;
            case "🚗":
            case "transport":
                return Transport;
            case "💡":
            case "bills":
                return Bills;
            case "💊":
            case "health":
                return Health;
            case "💰":
            case "salary":
                return Salary;
            case "🌐":
            case "all":
                return AllCategories;
            case "📌":
            case "other":
                return Other;
        }

        // Match by category name keywords
        if (!string.IsNullOrEmpty(categoryName))
        {
            var name = categoryName.ToLower();
            if (name.Contains("طعام") || name.Contains("مشروب") || name.Contains("أكل")) return Food;
            if (name.Contains("تسوق") || name.Contains("شراء") || name.Contains("مشتريات")) return Shopping;
            if (name.Contains("مواصلات") || name.Contains("نقل") || name.Contains("سيارة") || name.Contains("بنزين")) return Transport;
            if (name.Contains("فواتير") || name.Contains("خدمات") || name.Contains("كهرباء") || name.Contains("ماء") || name.Contains("انترنت")) return Bills;
            if (name.Contains("صحة") || name.Contains("علاج") || name.Contains("دواء") || name.Contains("مستشفى")) return Health;
            if (name.Contains("راتب") || name.Contains("دخل") || name.Contains("أرباح")) return Salary;
            if (name.Contains("جميع")) return AllCategories;
        }

        return Other;
    }
}
