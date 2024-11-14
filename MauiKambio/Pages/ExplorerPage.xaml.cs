using ClassLibraryModels.DTOs;
using MauiKambio.Services;
using System.Collections.ObjectModel;

namespace MauiKambio.Pages;

public partial class ExplorerPage : ContentPage
{
    private readonly ApiProductService _productService;
    public ObservableCollection<ProductDTO> Products { get; set; } = new();

    public ExplorerPage()
    {
        InitializeComponent();
        _productService = new ApiProductService();
        loading.IsVisible = true;
        BindingContext = this;
        LoadProducts();
    }

    private async void LoadProducts()
    {
        var productList = _productService.GetAll();

        foreach (var product in productList)
        {
            Products.Add(product);
        }

        loading.IsVisible = false;
    }

    private async void OnFilterClicked(object sender, EventArgs e)
    {
        //FilterPanel.IsVisible = !FilterPanel.IsVisible;
    }

    private async void OnApplyFilterClicked(object sender, EventArgs e)
    {
        //var selectedCategory = CategoryPicker.SelectedItem as Category; // Example binding to category picker
        //var maxPrice = FilteredPrice; // Example binding to price range slider

        //// Apply the filtering logic
        //var filteredProducts = Products.Where(p => p.Category == selectedCategory && p.Price <= maxPrice).ToList();
        //Products = new ObservableCollection<Product>(filteredProducts);

        // Hide the filter panel after applying filter
        //FilterPanel.IsVisible = false;
    }

    private async void OnPublishClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PublishPage());
    }

    private async void OnProductClicked(object sender, EventArgs e)
    {
        var imageButton = (ImageButton)sender;
        var product = (ProductDTO)((BindableObject)imageButton.Parent).BindingContext;

        if (product != null)
        {
            await Navigation.PushAsync(new ProductPage(product));
        }
    }
}