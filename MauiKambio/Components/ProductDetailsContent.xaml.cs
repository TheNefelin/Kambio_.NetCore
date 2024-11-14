using ClassLibraryModels.DTOs;

namespace MauiKambio.Components;

public partial class ProductDetailsContent : ContentView
{
    // propiedad para el evento click del btn
    public event EventHandler<ProductDTO> ProductClicked;

    // propiedad que recibe el objeto ProductDTO
    public static readonly BindableProperty ProductProperty =
        BindableProperty.Create(
            nameof(Product),
            typeof(ProductDTO),
            typeof(ProductDetailsContent),
            default(ProductDTO),
            propertyChanged: OnProductChanged
        );

    // Propiedad pública para el enlace en XAML
    public ProductDTO Product
    {
        get => (ProductDTO)GetValue(ProductProperty);
        set => SetValue(ProductProperty, value);
    }

    // propiedad que recibe un string
    public static readonly BindableProperty ButtonTextProperty =
        BindableProperty.Create(
            nameof(ButtonText),
            typeof(string),
            typeof(ProductDetailsContent),
            default(string)
        );

    // Propiedad pública para el enlace en XAML
    public string ButtonText
    {
        get => (string)GetValue(ButtonTextProperty);
        set => SetValue(ButtonTextProperty, value);
    }

    // constructor
    public ProductDetailsContent()
	{
		InitializeComponent();
	}

    private static void OnProductChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (ProductDetailsContent)bindable;
        control.SetStars();
    }

    private void SetStars()
    {
        btnProduct.Text = ButtonText;

        if (string.IsNullOrEmpty(Product.Description))
            textContent.IsVisible = false;

        for (int i = 1; i <= 5; i++)
        {
            var star = (Image)this.FindByName($"star{i}");
            star.Source = i <= Product.Stars ? "icon_star_v_512.png" : "icon_star_n_512.png";
        }
    }

    private void OnGalleryScrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        if (e.FirstVisibleItemIndex >= 0)
        {
            indicatorView.Position = e.FirstVisibleItemIndex;
        }
    }

    private void OnProductClicked(object sender, EventArgs e)
    {
        if (Product != null)
        {
            ProductClicked?.Invoke(this, Product);
        }
    }
}