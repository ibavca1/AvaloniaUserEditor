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

    protected override void OnLoaded()
    {
        base.OnLoaded();
        var vm = Locator.Current.GetService<MainViewModel>();
        vm.LoginViewModel.command.Execute(vm.LoginDialog);
    }

    public MainWindow()
    {
        InitializeComponentCustom();
        //_shared = Locator.Current.GetService<IShared>();
    }
}