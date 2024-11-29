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
        var productList = await _productService.GetAll();

        foreach (var product in productList)
        {
            Products.Add(product);
        }

        loading.IsVisible = false;
    }

    private async void OnFilterClicked(object sender, EventArgs e)
    {
        SideMenu.IsVisible = true;
    }

    private async void OnPublishClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PublishPage());
    }

    private async void OnProductClicked(object sender, ProductDTO product)
    {
        if (product != null)
        {
            await Navigation.PushAsync(new ProductPage(product));
        }
    }
}