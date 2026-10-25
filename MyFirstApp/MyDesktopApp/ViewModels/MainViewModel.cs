using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyDesktopApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    // متغير نصي يتم ربطه بالواجهة وتحديثه تلقائياً
    [ObservableProperty]
    private string _greeting = "مرحباً بك في تطبيقات سطح المكتب عبر الويب!";

    // أمر (Command) يتم تنفيذه عند الضغط على الزر
    [RelayCommand]
    private void OnButtonClick()
    {
        Greeting = "تم الضغط على الزر وتغيير النص بنجاح باستخدام MVVM!";
    }
}