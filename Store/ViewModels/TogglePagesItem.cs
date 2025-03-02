// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using ReactiveUI.Fody.Helpers;

namespace Store.ViewModels;

public class TogglePagesItem
{
    [Reactive] public PageViewModelBase? PageViewModel { get; set; }
    public string? PageTitle => PageViewModel?.PageTitle;
}
