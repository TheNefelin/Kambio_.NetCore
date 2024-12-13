using ClassLibraryClient.Services;
using ClassLibraryModels.DTOs;
using System.Collections.ObjectModel;

namespace MauiKambio.Pages;

public partial class ExplorerPage : ContentPage
{
    private readonly ApiProductService _apiProductService;
    public ObservableCollection<ProductDTO> Products { get; set; } = new();

    public ExplorerPage(ApiProductService apiProductService)
    {
        InitializeComponent();
        _apiProductService = apiProductService;
        loading.IsVisible = true;
        BindingContext = this;
        LoadProducts();
    }

    private async void LoadProducts()
    {
        var productList = await _apiProductService.GetAll();

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
            await Navigation.PushAsync(new ProductPage(product, _apiProductService));
        }
    }
}