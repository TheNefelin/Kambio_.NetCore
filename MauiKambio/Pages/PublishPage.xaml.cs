using ClassLibraryModels.DTOs;
using MauiKambio.Services;
using System.Collections.ObjectModel;

namespace MauiKambio.Pages;

public partial class PublishPage : ContentPage
{
    private readonly ApiCategoryService _categoryService;
    public ObservableCollection<CategoryDTO> Categories { get; set; } = new();

	public PublishPage()
	{
		InitializeComponent();
        _categoryService = new ApiCategoryService();
        BindingContext = this;
        LoadCategories();
    }

    private void LoadCategories()
    {
        var categoryList = _categoryService.GetAll();

        Categories.Clear();
        foreach (var category in categoryList)
        {
            Categories.Add(category);
        };
    }

    private async void OnUploadImageClicked(object sender, EventArgs e)
    {
        var result = await FilePicker.PickMultipleAsync(new PickOptions
        {
            PickerTitle = "Selecciona imágenes"
        });

        if (result != null)
        {
            var images = result.ToList();

            if (images.Count > 0)
                image1.Source = ImageSource.FromFile(images[0].FullPath);
            if (images.Count > 1)
                image2.Source = ImageSource.FromFile(images[1].FullPath);
            if (images.Count > 2)
                image3.Source = ImageSource.FromFile(images[2].FullPath);
        }
    }

    private void OnSubmitClicked(object sender, EventArgs e)
    {
        // Lógica para manejar la acción de envío del formulario
        DisplayAlert("Formulario Enviado", "¡Gracias por tu información!", "OK");
    }
}