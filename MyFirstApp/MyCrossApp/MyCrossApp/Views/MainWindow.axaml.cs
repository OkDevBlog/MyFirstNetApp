using Avalonia.Controls;
using Avalonia.Interactivity;

namespace MyCrossApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        // تغيير النص فوراً عند الضغط على الزر داخل المتصفح
        var textBlock = this.FindControl<TextBlock>("MyMessageText");
        if (textBlock != null)
        {
            textBlock.Text = "Button clicked and text changed successfully in browser!";
        }
    }
}