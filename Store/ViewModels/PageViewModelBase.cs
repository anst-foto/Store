// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using ReactiveUI.Fody.Helpers;
using Store.DB;

namespace Store.ViewModels;

public abstract class PageViewModelBase : ViewModelBase
{
    public static Customer? CurrentCustomer { get; set; }
    [Reactive] public string PageTitle { get; set; }
}
