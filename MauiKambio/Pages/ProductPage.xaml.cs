using ClassLibraryModels.DTOs;
using MauiKambio.Services;
using System.Collections.ObjectModel;

namespace MauiKambio.Pages;

public partial class ProductPage : ContentPage
{
    public ObservableCollection<ProductDTO> Products { get; set; } = new();
    private readonly ApiProductService _productService;

    public ProductPage(ProductDTO productDTO)
	{
		InitializeComponent();

		_productService = new ApiProductService();
        BindingContext = this;
        LoadProduct(productDTO);
    }

    private async void LoadProduct(ProductDTO productDTO)
    {
        var product = _productService.GetById(productDTO.Id);

        if (product != null) {
            Products.Add(product);
        }
    }

    private async void OnProductClicked(object sender, ProductDTO product)
    {

    }
}