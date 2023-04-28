using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace AvaloniaUserEditor.Components;

public class UserCard : TemplatedControl
{
    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static StyledProperty<string> TextProperty = AvaloniaProperty.Register<UserCard, string>(nameof(Text));
}