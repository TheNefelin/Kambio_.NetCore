using ClassLibraryModels.DTOs;
using MauiKambio.Services;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace MauiKambio.Pages;

public partial class FavoritesPage : ContentPage
{
    private readonly ApiProductService _productService;
    public ObservableCollection<ProductDTO> Products { get; set; } = new();

    public FavoritesPage()
	{
		InitializeComponent();
        _productService = new ApiProductService();
        loading.IsVisible = true;
        BindingContext = this;
        LoadFavorites();
    }

    private async void LoadFavorites()
    {
        var productList = await _productService.GetAllLike();

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