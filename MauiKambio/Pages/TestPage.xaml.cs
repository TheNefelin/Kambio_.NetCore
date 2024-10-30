using ClassLibraryModels.DTOs;
using MauiKambio.Services;
using System.Collections.ObjectModel;

namespace MauiKambio.Pages;

public partial class TestPage : ContentPage
{
    private readonly ApiProductService _productService;
    public ObservableCollection<ProductDTO> Products { get; set; } = new();

    public TestPage()
	{
		InitializeComponent();
        BindingContext = this;

        _productService = new ApiProductService();

        LoadProducts();
    }

    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();
    //}

    private async void LoadProducts()
    {
        await Navigation.PushModalAsync(new LoadingPage());

        // Simular carga de datos
        var productList = _productService.GetAll();
        foreach (var product in productList)
        {
            Products.Add(product);
        }

        await Navigation.PopModalAsync();
    }
    
    private void OnGalleryScrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        // Actualizar el indicador con la imagen actualmente visible
        //if (sender is CollectionView collectionView)
        //{
        //    var indicatorView = collectionView.FindByName<IndicatorView>("IndicatorView");
        //    if (indicatorView != null && e.FirstVisibleItemIndex >= 0)
        //    {
        //        indicatorView.Position = e.FirstVisibleItemIndex;
        //    }
        //}
    }
}