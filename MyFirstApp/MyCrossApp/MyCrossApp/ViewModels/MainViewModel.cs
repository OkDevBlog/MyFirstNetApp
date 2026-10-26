using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyCrossApp.Models;
using MyCrossApp.Services;

namespace MyCrossApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly IBudgetService _budgetService;
    private bool _isInitialized = false;

    // الإحصائيات العامة
    [ObservableProperty]
    private decimal _totalBalance;

    [ObservableProperty]
    private decimal _totalExpensesMonth;

    [ObservableProperty]
    private decimal _totalIncomeMonth;

    [ObservableProperty]
    private string _statusMessage = "مرحباً بك في مدير المصاريف الذكي";

    // حقول نموذج الإدخال والتعديل
    [ObservableProperty]
    private string _newTitle = string.Empty;

    [ObservableProperty]
    private string _newAmountText = string.Empty;

    [ObservableProperty]
    private string _newNotes = string.Empty;

    [ObservableProperty]
    private DateTimeOffset? _selectedDate = DateTimeOffset.Now;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsIncome))]
    private bool _isExpense = true;

    public bool IsIncome
    {
        get => !IsExpense;
        set
        {
            if (value != !IsExpense)
            {
                IsExpense = !value;
            }
        }
    }

    [ObservableProperty]
    private Category? _selectedCategory;

    // حالة التعديل
    [ObservableProperty]
    private bool _isEditing = false;

    [ObservableProperty]
    private int _editingTransactionId;

    [ObservableProperty]
    private string _formHeader = "إضافة معاملة جديدة";

    [ObservableProperty]
    private string _submitButtonText = "حفظ المعاملة";

    // حالة تأكيد الحذف
    [ObservableProperty]
    private bool _isConfirmingDelete = false;

    [ObservableProperty]
    private Transaction? _transactionToDelete;

    [ObservableProperty]
    private string _deleteConfirmMessage = string.Empty;

    // البحث والفلترة
    [ObservableProperty]
    private string _searchQuery = string.Empty;

    [ObservableProperty]
    private Category? _selectedFilterCategory;

    partial void OnSearchQueryChanged(string value)
    {
        if (_isInitialized)
        {
            _ = FilterAsync();
        }
    }

    partial void OnSelectedFilterCategoryChanged(Category? value)
    {
        if (_isInitialized)
        {
            _ = FilterAsync();
        }
    }

    // المجموعات المرتبطة بالواجهة
    public ObservableCollection<Transaction> Transactions { get; } = new();
    public ObservableCollection<Category> Categories { get; } = new();
    public ObservableCollection<Category> FilterCategories { get; } = new();

    public MainViewModel() : this(new BudgetService())
    {
    }

    public MainViewModel(IBudgetService budgetService)
    {
        _budgetService = budgetService;
        _ = InitializeAsync();
    }

    private async Task InitializeAsync()
    {
        try
        {
            await _budgetService.InitializeDatabaseAsync();
            await LoadDataAsync();
            _isInitialized = true;
        }
        catch (Exception ex)
        {
            StatusMessage = $"خطأ في الاتصال بقاعدة البيانات: {ex.Message}";
        }
    }

    [RelayCommand]
    public async Task LoadDataAsync()
    {
        var categories = await _budgetService.GetCategoriesAsync();
        Categories.Clear();
        FilterCategories.Clear();

        FilterCategories.Add(new Category { Id = 0, Name = "جميع التصنيفات", Icon = "all" });

        foreach (var cat in categories)
        {
            Categories.Add(cat);
            FilterCategories.Add(cat);
        }

        if (Categories.Count > 0 && SelectedCategory == null)
        {
            SelectedCategory = Categories[0];
        }

        SelectedFilterCategory = FilterCategories[0];
        await RefreshTransactionsAndSummaryAsync();
    }

    [RelayCommand]
    public async Task SaveTransactionAsync()
    {
        if (string.IsNullOrWhiteSpace(NewTitle))
        {
            StatusMessage = "يرجى كتابة عنوان المعاملة!";
            return;
        }

        if (!decimal.TryParse(NewAmountText, out var amount) || amount <= 0)
        {
            StatusMessage = "يرجى إدخال مبلغ صحيح أكبر من الصفر!";
            return;
        }

        if (SelectedCategory == null)
        {
            StatusMessage = "يرجى اختيار التصنيف!";
            return;
        }

        var txDate = SelectedDate?.DateTime ?? DateTime.Now;

        try
        {
            if (IsEditing)
            {
                // تعديل معاملة حالية
                var updatedTx = new Transaction
                {
                    Id = EditingTransactionId,
                    Title = NewTitle.Trim(),
                    Amount = amount,
                    IsExpense = IsExpense,
                    CategoryId = SelectedCategory.Id,
                    Notes = NewNotes.Trim(),
                    TransactionDate = txDate
                };

                var result = await _budgetService.UpdateTransactionAsync(updatedTx);

                // تحديث العنصر في القائمة
                var existingIndex = Transactions.ToList().FindIndex(t => t.Id == EditingTransactionId);
                if (existingIndex >= 0)
                {
                    Transactions[existingIndex] = result;
                }

                StatusMessage = "تم تحديث المعاملة بنجاح!";
                CancelEdit();
            }
            else
            {
                // إضافة معاملة جديدة
                var newTx = new Transaction
                {
                    Title = NewTitle.Trim(),
                    Amount = amount,
                    IsExpense = IsExpense,
                    CategoryId = SelectedCategory.Id,
                    Notes = NewNotes.Trim(),
                    TransactionDate = txDate
                };

                var added = await _budgetService.AddTransactionAsync(newTx);
                Transactions.Insert(0, added);

                ResetForm();
                StatusMessage = "تم حفظ المعاملة بنجاح في SQLite!";
            }

            await UpdateTotalsAsync();
        }
        catch (Exception ex)
        {
            StatusMessage = $"فشل الحفظ: {ex.Message}";
        }
    }

    [RelayCommand]
    public void StartEditTransaction(Transaction? transaction)
    {
        if (transaction == null) return;

        IsEditing = true;
        EditingTransactionId = transaction.Id;
        NewTitle = transaction.Title;
        NewAmountText = transaction.Amount.ToString("0.##");
        IsExpense = transaction.IsExpense;
        SelectedCategory = Categories.FirstOrDefault(c => c.Id == transaction.CategoryId) ?? Categories.FirstOrDefault();
        NewNotes = transaction.Notes;
        SelectedDate = new DateTimeOffset(transaction.TransactionDate);

        FormHeader = "تعديل المعاملة";
        SubmitButtonText = "حفظ التعديلات";
        StatusMessage = $"جاري تعديل المعاملة: {transaction.Title}";
    }

    [RelayCommand]
    public void CancelEdit()
    {
        IsEditing = false;
        EditingTransactionId = 0;
        ResetForm();
        FormHeader = "إضافة معاملة جديدة";
        SubmitButtonText = "حفظ المعاملة";
        StatusMessage = "جاهز لإضافة معاملة جديدة.";
    }

    [RelayCommand]
    public void RequestDelete(Transaction? transaction)
    {
        if (transaction == null) return;

        TransactionToDelete = transaction;
        IsConfirmingDelete = true;
        DeleteConfirmMessage = $"هل أنت متأكد من حذف '{transaction.Title}' بمبلغ {transaction.FormattedAmount}؟";
    }

    [RelayCommand]
    public async Task ConfirmDeleteAsync()
    {
        if (TransactionToDelete == null) return;

        try
        {
            var title = TransactionToDelete.Title;
            await _budgetService.DeleteTransactionAsync(TransactionToDelete.Id);
            Transactions.Remove(TransactionToDelete);

            StatusMessage = $"تم حذف المعاملة '{title}' بنجاح.";
            CancelDelete();
            await UpdateTotalsAsync();
        }
        catch (Exception ex)
        {
            StatusMessage = $"فشل الحذف: {ex.Message}";
        }
    }

    [RelayCommand]
    public void CancelDelete()
    {
        IsConfirmingDelete = false;
        TransactionToDelete = null;
        DeleteConfirmMessage = string.Empty;
    }

    [RelayCommand]
    public async Task FilterAsync()
    {
        var catId = SelectedFilterCategory?.Id > 0 ? (int?)SelectedFilterCategory.Id : null;
        var list = await _budgetService.GetTransactionsAsync(catId, SearchQuery);

        Transactions.Clear();
        foreach (var tx in list)
        {
            Transactions.Add(tx);
        }
    }

    [RelayCommand]
    public async Task ClearFilterAsync()
    {
        SearchQuery = string.Empty;
        if (FilterCategories.Count > 0)
        {
            SelectedFilterCategory = FilterCategories[0];
        }
        await FilterAsync();
    }

    private void ResetForm()
    {
        NewTitle = string.Empty;
        NewAmountText = string.Empty;
        NewNotes = string.Empty;
        SelectedDate = DateTimeOffset.Now;
        IsExpense = true;
        if (Categories.Count > 0)
        {
            SelectedCategory = Categories[0];
        }
    }

    private async Task RefreshTransactionsAndSummaryAsync()
    {
        await FilterAsync();
        await UpdateTotalsAsync();
    }

    private async Task UpdateTotalsAsync()
    {
        TotalBalance = await _budgetService.GetTotalBalanceAsync();
        TotalExpensesMonth = await _budgetService.GetTotalExpensesCurrentMonthAsync();
        TotalIncomeMonth = await _budgetService.GetTotalIncomeCurrentMonthAsync();
    }
}
