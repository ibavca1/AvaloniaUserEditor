using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaUserEditor.ViewModels;

public class LoginViewModel:ObservableObject
{
    private readonly Func<IAsyncEnumerable<string>> _commandHandler;

    private string _header;
    private ICommand _command;

    public ICommand Command
    {
        get => _command;
        set
        {
            _command = value;
            OnPropertyChanged();
        }
    }
    private string _result; 
    public string? Result
    {
        get => _result;
        set
        {
            _result = value;
            OnPropertyChanged();
        }
    }
    public LoginViewModel(string header, Func<IAsyncEnumerable<string>> handler)
    {
        _header = header;
        _commandHandler = handler;
        _command = new RelayCommand(OnExecuteCommandHandler);
    }

    private async void OnExecuteCommandHandler()
    {
        Result = "Waiting result...";
        var builder = new StringBuilder();
        await foreach (var str in _commandHandler())
        {
            builder.AppendLine(str);
            Result = builder.ToString();
        }
    }
}