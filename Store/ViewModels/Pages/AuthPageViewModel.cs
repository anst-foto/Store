using ReactiveUI.Fody.Helpers;

namespace Store.ViewModels;

public class AuthPageViewModel : PageViewModelBase
{
    [Reactive] public string Login { get; set; }
    [Reactive] public string Password { get; set; }

    public AuthPageViewModel()
    {
        PageTitle = "Auth";
    }
}
