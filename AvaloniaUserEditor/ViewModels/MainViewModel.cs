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
using Material.Dialog.Interfaces;
using Splat;

namespace AvaloniaUserEditor.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private IShared _shared;
    private string messageUserName => "Неверное имя пользователя.";
    private string messagePassword => "Неправельный пароль.";
    [ObservableProperty] public string? userName;

    [ObservableProperty] public string? password;
    [ObservableProperty] public bool? isOpen;
    public LoginViewModel LoginViewModel { get; }

    public MainViewModel(IShared shared)
    {
        _shared = shared;
        LoginViewModel = new LoginViewModel("Login", LoginDialog);
    }

    public IDialogWindow<TextFieldDialogResult> DialogWindow;

    public async IAsyncEnumerable<string> LoginDialog()
    {
        var result = DialogHelper.CreateTextFieldDialog(new TextFieldDialogBuilderParams
        {
            ContentHeader = "Authentication required.",
            SupportingText = "Please login before any action.",
            StartupLocation = WindowStartupLocation.CenterOwner,
            DialogHeaderIcon = DialogIconKind.Blocked,
            Borderless = true,
            Width = 400,
            TextFields = new[]
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
        });

        var formResult = await result.ShowDialog(Program.MainWindow);

        if (formResult.GetResult != nameof(LoginButtonResult.Ok))
        {
            Environment.Exit(0);
        }

        ValidateUserResult? serverResult = null;
        try
        {
            userName = formResult.GetFieldsResult()[0].Text;
            password = formResult.GetFieldsResult()[1].Text;
            serverResult = _shared.ValidateUser(userName, password);            
        }
        catch (Exception e)
        {
            //TODO: Установить сообщение о ошибке авторизации пользователя
        }
        
        if (!serverResult.IsValid)
        {
            LoginViewModel.Command.Execute(LoginDialog);
        }

        yield return $"{formResult.GetFieldsResult()[0]}";
    }

    private Tuple<bool, string> ValidateAccount(string text)
    {
        var result = text.Length >= 1;
        return new Tuple<bool, string>(result, result ? "" : messageUserName);
    }

    private Tuple<bool, string> ValidatePassword(string text)
    {
        var result = text.Length >= 1;
        return new Tuple<bool, string>(result, result ? "" : messagePassword);
    }
}