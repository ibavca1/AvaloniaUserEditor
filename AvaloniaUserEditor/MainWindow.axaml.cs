using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaUserEditor.Infrastructure;
using AvaloniaUserEditor.ViewModels;
using Splat;

namespace AvaloniaUserEditor;

public partial class MainWindow : Window
{
    private void InitializeComponentCustom()
    {
        AvaloniaXamlLoader.Load(this);
    }
    public MainWindow()
    {
        InitializeComponentCustom();
        //_shared = Locator.Current.GetService<IShared>();
    }
}