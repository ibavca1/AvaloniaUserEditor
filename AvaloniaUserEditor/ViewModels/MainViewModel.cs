using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using AvaloniaUserEditor.Infrastructure;
using AvaloniaUserEditor.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;
using Material.Dialog;
using Material.Dialog.Enums;
using Material.Dialog.Icons;
using Splat;

namespace AvaloniaUserEditor.ViewModels;

public partial class MainViewModel:ObservableObject
{
    private IShared _shared;
    [ObservableProperty] public string? userName;

    [ObservableProperty] public string? password;
    [ObservableProperty] public bool? isOpen;
    public LoginViewModel LoginViewModel { get; }
    public MainViewModel(IShared shared)
    {
        _shared = shared;
        LoginViewModel = new LoginViewModel("Login", LoginDialog);
        
        //_loginViewModel.Command.Execute(LoginDialog);
        //dialogClose = DialogClosingHandlerCommand;

    }

    public TextFieldDialogResult LoginDialog()
    {
        var result = DialogHelper.CreateTextFieldDialog(new TextFieldDialogBuilderParams
        {
            ContentHeader = "Authentication required.",
            SupportingText = "Please login before any action.",
            StartupLocation = WindowStartupLocation.CenterOwner,
            DialogHeaderIcon = DialogIconKind.Blocked,
            Borderless = true,
            Width = 400,
            TextFields = new []
            {
                new TextFieldBuilderParams
                {
                    HelperText = "* Required",
                    Classes = "outline",
                    Label = "Account",
                    MaxCountChars = 24,
                    Validater = ValidateAccount,
                },
                new TextFieldBuilderParams
                {
                    HelperText = "* Required",
                    Classes = "outline",
                    Label = "Password",
                    MaxCountChars = 64,
                    FieldKind = TextFieldKind.Masked,
                    MaskChar = '⬤',
                    Validater = ValidatePassword,                    
                }
            },
            DialogButtons = new[]
            {
                new DialogButton
                {
                    Content = "CANCEL",
                    Result = nameof(LoginButtonResult.Cancel),
                    IsNegative = true
                },
                new DialogButton
                {
                    Content = "LOGIN",
                    Result = nameof(LoginButtonResult.Ok),
                    IsPositive = true
                }
            }
        }).ShowDialog(Program.MainWindow);
        var formResult = result.Result;
        if (formResult.GetResult != nameof(LoginButtonResult.Ok))
        {
            //TODO: Exit application 
            Environment.Exit(0);
        }

        return formResult;
        /*yield return $"Account: {result.GetFieldsResult()[0]}";
        yield return $"Password: {result.GetFieldsResult()[1]}";*/
    }

    private Tuple<bool, string> ValidateAccount(string text)
    {
        var result = text.Length >= 1;
        return new Tuple<bool, string>(result, result ? "" : "Too few account name");
    }
    private Tuple<bool, string> ValidatePassword(string text)
    {
        var result = text.Length >= 1;
        return new Tuple<bool, string>(result, result ? "" : "Field should be filled.");
    }
    /*[ObservableProperty]
    public ICommand dialogClose; 
    [RelayCommand]
    public void DialogClosingHandler()
    {
        var result = _shared.ValidateUser(userName, password);
        if (!result.IsValid)
        {
            IsOpen = true;
            //var idet = DialogHost.;
        }

        IsOpen = false;
        //    DialogHost.Show(new User(), "LoginDialogClosingHandler");
    }*/
}