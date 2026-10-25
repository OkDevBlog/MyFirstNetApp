using Avalonia.Controls;
using Avalonia.Interactivity;

namespace MyCrossApp.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var textBlock = this.FindControl<TextBlock>("MyMessageText");
        if (textBlock != null)
        {
            textBlock.Text = "Button clicked and text changed successfully in browser!";
        }
    }
}