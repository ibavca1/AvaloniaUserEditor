using System.ComponentModel;
using AvaloniaUserEditor.Infrastructure;
using Splat;

namespace AvaloniaUserEditor.ViewModels;

public class MainViewModel
{
    private IShared _shared;
    public string Gretting => "AVALONIA";
    public MainViewModel(IShared shared)
    {
        _shared = shared;
    }

    
}