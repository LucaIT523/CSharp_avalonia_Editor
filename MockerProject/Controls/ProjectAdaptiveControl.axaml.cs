using Avalonia;
using Avalonia.Controls.Primitives;

namespace MockerProject.Controls;

public class ProjectAdaptiveControl : TemplatedControl
{
	public static readonly StyledProperty<object?> HeaderProperty =
		AvaloniaProperty.Register<ProjectAdaptiveControl, object?>(nameof(Header));

	public static readonly StyledProperty<object?> LeftProperty =
		AvaloniaProperty.Register<ProjectAdaptiveControl, object?>(nameof(Left));

	public static readonly StyledProperty<object?> RightProperty =
		AvaloniaProperty.Register<ProjectAdaptiveControl, object?>(nameof(Right));

	public object? Header
	{
		get => GetValue(HeaderProperty);
		set => SetValue(HeaderProperty, value);
	}

	public object? Left
	{
		get => GetValue(LeftProperty);
		set => SetValue(LeftProperty, value);
	}

	public object? Right
	{
		get => GetValue(RightProperty);
		set => SetValue(RightProperty, value);
	}
}
