// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using ReactiveUI.Fody.Helpers;

namespace Store.ViewModels;

public class ProfilePageViewModel : PageViewModelBase
{
    [Reactive] public string? LastName { get; set; }
    [Reactive] public string? FirstName { get; set; }
    [Reactive] public string? Email { get; set; }

    public ProfilePageViewModel()
    {
        PageTitle = "Profile";

        LastName = CurrentCustomer?.LastName;
        FirstName = CurrentCustomer?.FirstName;
        Email = CurrentCustomer?.Email;
    }
}
