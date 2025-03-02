// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Store.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ObservableCollection<TogglePagesItem> TogglePages { get; set; } =
    [
        new() { PageViewModel = new AuthPageViewModel() },
        new() { PageViewModel = new ProductsPageViewModel() },
        new() { PageViewModel = new ProfilePageViewModel() }
    ];

    [Reactive] public TogglePagesItem? SelectedPage { get; set; }

    [Reactive] public bool IsPaneOpen { get; set; } = true;

    public ReactiveCommand<Unit, Unit> PaneOpen { get; }

    public MainViewModel()
    {
        SelectedPage = TogglePages[0];

        PaneOpen = ReactiveCommand.Create(() =>
        {
            IsPaneOpen = !IsPaneOpen;
        });
    }
}
