using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaUserEditor.ViewModels;
using Splat;

namespace AvaloniaUserEditor;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            Bootstraper.Register(Locator.CurrentMutable, Locator.Current);
            desktop.MainWindow = new MainWindow
            {
                DataContext = Locator.Current.GetService<MainViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}