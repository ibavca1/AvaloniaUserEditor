using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using AvaloniaUserEditor.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Material.Dialog;

namespace AvaloniaUserEditor.ViewModels;

public partial class LoginViewModel:ObservableObject
{
    private readonly Func<IAsyncEnumerable<string>> _commandHandler;

    [ObservableProperty]
    public string header;
    [ObservableProperty]
    public ICommand command;

    [ObservableProperty]
    public string? result; 

    public LoginViewModel(string header, Func<IAsyncEnumerable<string>> handler)
    {
        Header = header;
        _commandHandler = handler;
        Command = new RelayCommand(OnExecuteCommandHandler);
    }

    private async void OnExecuteCommandHandler()
    {
        var builder = new StringBuilder();
        
        await foreach (var str in _commandHandler())
        {
            builder.AppendLine(str);
            Result = builder.ToString();
        }
    }
}