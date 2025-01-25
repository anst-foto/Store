using ReactiveUI.Fody.Helpers;

namespace Store.ViewModels;

public abstract class PageViewModelBase : ViewModelBase
{
    [Reactive] public string PageTitle { get; set; }
}
