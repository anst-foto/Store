// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System;
using System.Linq;
using System.Reactive;
using Avalonia;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Store.ViewModels;

public class AuthPageViewModel : PageViewModelBase
{
    [Reactive] public string Login { get; set; }
    [Reactive] public string Password { get; set; }

    public ReactiveCommand<Unit, Unit> CommandLogin { get; }
    public ReactiveCommand<Unit, Unit> CommandCancel { get; }

    public AuthPageViewModel()
    {
        PageTitle = "Auth";

        CommandLogin = ReactiveCommand.Create(Auth);
        CommandCancel = ReactiveCommand.Create(() =>
        {
            Environment.Exit(0);
        });
    }

    private void Auth()
    {
        var storeContext = (Application.Current as App)?.StoreContext;
        var customer = storeContext?.Customers.SingleOrDefault(c => c.Login == Login && c.Password == Password);
        if (customer is not null)
        {
            CurrentCustomer = customer;
        }
    }
}
