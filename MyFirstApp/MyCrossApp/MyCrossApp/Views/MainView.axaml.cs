using Avalonia;
using Avalonia.Controls;

namespace MyCrossApp.Views;

public partial class MainView : UserControl
{
    private bool? _isNarrowMode = null;
    private bool? _isVeryNarrowMode = null;

    public MainView()
    {
        InitializeComponent();
        SizeChanged += OnMainViewSizeChanged;
    }

    private void OnMainViewSizeChanged(object? sender, SizeChangedEventArgs e)
    {
        ApplyResponsiveLayout(e.NewSize.Width);
    }

    private void ApplyResponsiveLayout(double width)
    {
        if (width <= 0) return;

        // 1. التبديل التلقائي بين عمودين للشاشات الكبيرة وعمود واحد متكدس للشاشات الصغيرة
        bool narrow = width < 820;
        if (_isNarrowMode != narrow)
        {
            _isNarrowMode = narrow;
            if (narrow)
            {
                MainContentGrid.ColumnDefinitions = new ColumnDefinitions("*");
                MainContentGrid.RowDefinitions = new RowDefinitions("Auto, *");

                Grid.SetColumn(FormBorder, 0);
                Grid.SetRow(FormBorder, 0);
                FormBorder.Margin = new Thickness(0, 0, 0, 16);

                Grid.SetColumn(ListGrid, 0);
                Grid.SetRow(ListGrid, 1);
            }
            else
            {
                MainContentGrid.RowDefinitions = new RowDefinitions("*");
                MainContentGrid.ColumnDefinitions = new ColumnDefinitions("350, *");

                Grid.SetColumn(FormBorder, 0);
                Grid.SetRow(FormBorder, 0);
                FormBorder.Margin = new Thickness(0, 0, 16, 0);

                Grid.SetColumn(ListGrid, 1);
                Grid.SetRow(ListGrid, 0);
            }
        }

        // 2. تكييف بطاقات الإحصائيات وشريط البحث للشاشات الضيقة جداً (< 600px)
        bool veryNarrow = width < 600;
        if (_isVeryNarrowMode != veryNarrow)
        {
            _isVeryNarrowMode = veryNarrow;
            if (veryNarrow)
            {
                // بطاقات الإحصائيات مكدسة
                StatsGrid.ColumnDefinitions = new ColumnDefinitions("*");
                StatsGrid.RowDefinitions = new RowDefinitions("Auto, Auto, Auto");

                Grid.SetColumn(CardTotal, 0);
                Grid.SetRow(CardTotal, 0);
                CardTotal.Margin = new Thickness(0, 0, 0, 8);

                Grid.SetColumn(CardExpenses, 0);
                Grid.SetRow(CardExpenses, 1);
                CardExpenses.Margin = new Thickness(0, 0, 0, 8);

                Grid.SetColumn(CardIncome, 0);
                Grid.SetRow(CardIncome, 2);
                CardIncome.Margin = new Thickness(0);

                // شريط البحث مكدس لسطرين
                SearchBarGrid.ColumnDefinitions = new ColumnDefinitions("*, Auto");
                SearchBarGrid.RowDefinitions = new RowDefinitions("Auto, Auto");

                Grid.SetColumn(SearchTextBox, 0);
                Grid.SetRow(SearchTextBox, 0);
                Grid.SetColumnSpan(SearchTextBox, 2);
                SearchTextBox.Margin = new Thickness(0, 0, 0, 8);

                Grid.SetColumn(FilterComboBox, 0);
                Grid.SetRow(FilterComboBox, 1);
                Grid.SetColumnSpan(FilterComboBox, 1);
                FilterComboBox.Margin = new Thickness(0, 0, 8, 0);

                Grid.SetColumn(ClearFilterButton, 1);
                Grid.SetRow(ClearFilterButton, 1);
            }
            else
            {
                // بطاقات الإحصائيات في صف واحد بثلاثة أعمدة
                StatsGrid.RowDefinitions = new RowDefinitions("Auto");
                StatsGrid.ColumnDefinitions = new ColumnDefinitions("*, *, *");

                Grid.SetColumn(CardTotal, 0);
                Grid.SetRow(CardTotal, 0);
                CardTotal.Margin = new Thickness(0, 0, 10, 0);

                Grid.SetColumn(CardExpenses, 1);
                Grid.SetRow(CardExpenses, 0);
                CardExpenses.Margin = new Thickness(5, 0, 5, 0);

                Grid.SetColumn(CardIncome, 2);
                Grid.SetRow(CardIncome, 0);
                CardIncome.Margin = new Thickness(10, 0, 0, 0);

                // شريط البحث في صف واحد
                SearchBarGrid.RowDefinitions = new RowDefinitions("Auto");
                SearchBarGrid.ColumnDefinitions = new ColumnDefinitions("*, 150, Auto");

                Grid.SetColumn(SearchTextBox, 0);
                Grid.SetRow(SearchTextBox, 0);
                Grid.SetColumnSpan(SearchTextBox, 1);
                SearchTextBox.Margin = new Thickness(0, 0, 10, 0);

                Grid.SetColumn(FilterComboBox, 1);
                Grid.SetRow(FilterComboBox, 0);
                Grid.SetColumnSpan(FilterComboBox, 1);
                FilterComboBox.Margin = new Thickness(0, 0, 10, 0);

                Grid.SetColumn(ClearFilterButton, 2);
                Grid.SetRow(ClearFilterButton, 0);
            }
        }
    }
}
