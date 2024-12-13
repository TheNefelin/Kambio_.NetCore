using ClassLibraryClient.Services;
using ClassLibraryModels.DTOs;
using System.Collections.ObjectModel;

namespace MauiKambio.Pages;

public partial class FavoritesPage : ContentPage
{
    private readonly ApiProductService _apiProductService;
    public ObservableCollection<ProductDTO> Products { get; set; } = new();

    public FavoritesPage(ApiProductService apiProductService)
	{
		InitializeComponent();
        _apiProductService = apiProductService;
        loading.IsVisible = true;
        BindingContext = this;
        LoadFavorites();
    }

    private async void LoadFavorites()
    {
        var productList = await _apiProductService.GetAllLike();

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
            await Navigation.PushAsync(new ProductPage(product, _apiProductService));
        }
    }
}