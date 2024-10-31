using ClassLibraryModels.DTOs;
using MauiKambio.Services;
using System.Collections.ObjectModel;

namespace MauiKambio.Pages;

public partial class ExplorerPage : ContentPage
{
    public ObservableCollection<ProductDTO> Products { get; set; } = new();
    private readonly ApiProductService _productService;

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

    private async void OnProductClicked(object sender, ProductDTO product)
    {
        if (product != null)
        {
            await Navigation.PushAsync(new ProductPage(product));
        }
    }
}