using ClassLibraryClient.Services;
using ClassLibraryModels.DTOs;
using System.Collections.ObjectModel;

namespace MauiKambio.Pages;

public partial class ProductPage : ContentPage
{
    public ObservableCollection<ProductDTO> Products { get; set; } = new();
    private readonly ApiProductService _productService;

    public ProductPage(ProductDTO productDTO, ApiProductService apiProductService)
	{
		InitializeComponent();

        Loading.IsLoading = true;
		_productService = apiProductService;
        BindingContext = this;
        LoadProduct(productDTO);
    }

    private async void LoadProduct(ProductDTO productDTO)
    {
        var product = await _productService.GetById(productDTO.Id);

        if (product != null) {
            Products.Add(product);
        }

        Loading.IsLoading = false;
    }

    private async void OnProductClicked(object sender, ProductDTO product)
    {

    }
}