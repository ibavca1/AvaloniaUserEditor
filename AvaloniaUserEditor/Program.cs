using Avalonia;
using System;
using Avalonia.Controls;
using AvaloniaUserEditor.Infrastructure;
using AvaloniaUserEditor.ViewModels;
using Splat;

namespace AvaloniaUserEditor;

class Program
{
    public static MainWindow MainWindow { get; private set; }
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        BuildAvaloniaApp().Start(AppMain, args);        
    }


    private static void AppMain(Application app, string[] args)
    {
        Bootstraper.Register(Locator.CurrentMutable, Locator.Current);
        
        MainWindow = new MainWindow
        {
            DataContext = new MainViewModel(Locator.Current.GetService<IShared>())
        };
        
        app.Run(MainWindow);
    }
    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .UseSkia()
            .LogToTrace(); 
    }
}