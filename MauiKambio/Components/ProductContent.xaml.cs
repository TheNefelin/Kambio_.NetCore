using ClassLibraryModels.DTOs;

namespace MauiKambio.Components;

public partial class ProductContent : ContentView
{
    public event EventHandler<ProductDTO> ProductClicked;

    public static readonly BindableProperty ProductProperty = 
        BindableProperty.Create(
            nameof(Product), 
            typeof(ProductDTO), 
            typeof(ProductContent), 
            default(ProductDTO),
            propertyChanged: OnProductChanged
        );

    private ProductDTO Product
    {
        get => (ProductDTO)GetValue(ProductProperty);
        set => SetValue(ProductProperty, value);
    }

    public ProductContent()
    {
        InitializeComponent();
    }

    private static void OnProductChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (ProductContent)bindable;
        control.SetStars();
    }

    private void SetStars()
    {
        for (int i = 0; i <= Product.Stars; i++) {
            star1.Source = i >= 1 ? "star_v_32.png" : "star_n_32.png";
            star2.Source = i >= 2 ? "star_v_32.png" : "star_n_32.png";
            star3.Source = i >= 3 ? "star_v_32.png" : "star_n_32.png";
            star4.Source = i >= 4 ? "star_v_32.png" : "star_n_32.png";
            star5.Source = i >= 5 ? "star_v_32.png" : "star_n_32.png";
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