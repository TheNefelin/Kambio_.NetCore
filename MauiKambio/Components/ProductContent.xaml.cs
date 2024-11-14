using ClassLibraryModels.DTOs;

namespace MauiKambio.Components;

public partial class ProductContent : ContentView
{
    // Evento que será manejado por el contenedor (la página que lo usa)
    public event EventHandler<ProductDTO> ProductClicked;

    // Método que dispara el evento cuando se hace clic en el contenido del producto
    private void OnProductClicked(object sender, EventArgs e)
    {
        if (Product != null)
        {
            ProductClicked?.Invoke(this, Product);  // Dispara el evento
        }
    }

    // BindableProperty para enlazar el producto a este componente
    public static readonly BindableProperty ProductProperty =
        BindableProperty.Create(
            nameof(Product),
            typeof(ProductDTO),
            typeof(ProductContent),
            default(ProductDTO)
        );

    // Propiedad de enlace para el producto
    public ProductDTO Product
    {
        get => (ProductDTO)GetValue(ProductProperty);
        set => SetValue(ProductProperty, value);
    }

    // Constructor donde se inicializa el componente
    public ProductContent()
    {
        InitializeComponent();
    }
}