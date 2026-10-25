using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyCrossApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Welcome! The app is running live in the browser.";

    [RelayCommand]
    private void OnButtonClick()
    {
        Greeting = "Button clicked and text changed dynamically in browser!";
    }
}