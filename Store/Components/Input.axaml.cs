using Avalonia;

namespace Store.Components;

public partial class Input : Component
{
    public static readonly StyledProperty<string> LabelContentProperty =
        AvaloniaProperty.Register<Input, string>(nameof(LabelContent));
    public static readonly StyledProperty<string> PlaceholderContentProperty =
        AvaloniaProperty.Register<Input, string>(nameof(PlaceholderContent));
    public static readonly StyledProperty<string> InputTextProperty =
        AvaloniaProperty.Register<Input, string>(nameof(InputText));

    public string LabelContent
    {
        get => GetValue(LabelContentProperty);
        set => SetValue(LabelContentProperty, value);
    }

    public string PlaceholderContent
    {
        get => GetValue(PlaceholderContentProperty);
        set => SetValue(PlaceholderContentProperty, value);
    }

    public string InputText
    {
        get => GetValue(InputTextProperty);
        set => SetValue(InputTextProperty, value);
    }

    public Input()
    {
        InitializeComponent();
    }
}
