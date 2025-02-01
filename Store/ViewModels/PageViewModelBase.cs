using ReactiveUI.Fody.Helpers;
using Store.DB;

namespace Store.ViewModels;

public abstract class PageViewModelBase : ViewModelBase
{
    public static Customer? CurrentCustomer { get; set; }
    [Reactive] public string PageTitle { get; set; }
}
