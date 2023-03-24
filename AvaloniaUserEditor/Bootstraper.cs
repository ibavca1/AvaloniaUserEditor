using AvaloniaUserEditor.Infrastructure;
using AvaloniaUserEditor.ViewModels;
using Splat;

namespace AvaloniaUserEditor;

public static class Bootstraper
{
    public static void Register(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        services.Register<MainViewModel>(()=>new MainViewModel(
            Locator.Current.GetService<IShared>()
            ));
        services.Register<IShared>(()=>new Shared());
    }
}