namespace MauiKambio.Components;

public partial class LoadingView : ContentView
{
    public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(
    nameof(IsLoading),
    typeof(bool),
    typeof(LoadingView),
    false,
    propertyChanged: OnIsLoadingChanged);

    public bool IsLoading
    {
        get => (bool)GetValue(IsLoadingProperty);
        set => SetValue(IsLoadingProperty, value);
    }

    public LoadingView()
	{
		InitializeComponent();
	}

    private static void OnIsLoadingChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is LoadingView loadingView)
        {
            loadingView.IsVisible = (bool)newValue;
        }
    }
}