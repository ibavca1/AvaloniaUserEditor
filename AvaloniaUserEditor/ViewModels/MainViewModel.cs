using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using AvaloniaUserEditor.Infrastructure;
using AvaloniaUserEditor.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;
using Splat;

namespace AvaloniaUserEditor.ViewModels;

public partial class MainViewModel:ObservableObject
{
    private IShared _shared;
    [ObservableProperty] public string userName;

    [ObservableProperty] public string password;
    public string Gretting => "AVALONIA";
    public MainViewModel(IShared shared)
    {
        _shared = shared;
        dialogClose = DialogClosingHandlerCommand;
    }

    [ObservableProperty]
    public ICommand dialogClose; 
    [RelayCommand]
    public void DialogClosingHandler()
    {
        
        //    DialogHost.Show(new User(), "LoginDialogClosingHandler");
    }
}