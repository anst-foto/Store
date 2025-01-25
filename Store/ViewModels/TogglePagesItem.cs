using ReactiveUI.Fody.Helpers;

namespace Store.ViewModels;

public class TogglePagesItem
{
    [Reactive] public PageViewModelBase? PageViewModel { get; set; }
    public string? PageTitle => PageViewModel?.PageTitle;
}
