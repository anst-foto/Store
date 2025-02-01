using System;
using System.Collections.ObjectModel;
using System.Reactive;
using DynamicData.Binding;
using Microsoft.EntityFrameworkCore;
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
