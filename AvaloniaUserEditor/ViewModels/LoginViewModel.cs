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
    private readonly Func<TextFieldDialogResult> _commandHandler;

    [ObservableProperty]
    public string header;
    [ObservableProperty]
    public ICommand command;

    [ObservableProperty]
    public TextFieldDialogResult result; 

    public LoginViewModel(string header, Func<TextFieldDialogResult> handler)
    {
        result = new TextFieldDialogResult();
        Header = header;
        _commandHandler = handler;
        Command = new RelayCommand(OnExecuteCommandHandler);
    }

    private void OnExecuteCommandHandler()
    {
        /*var account = Result.GetFieldsResult()[0];
        var password = Result.GetFieldsResult()[1];*/
        //var builder = new StringBuilder();
        
        /*await foreach (var str in _commandHandler())
        {
            builder.AppendLine(str);
            Result = builder.ToString();
        }*/
    }
}