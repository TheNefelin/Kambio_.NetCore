using ClassLibraryModels.DTOs;
using MauiKambio.Services;
using System.Collections.ObjectModel;

namespace MauiKambio.Pages;

public partial class PublishPage : ContentPage
{
    public ObservableCollection<CategoryDTO> Categories { get; set; } = new();
    private readonly CategoryDTO newCategory = new CategoryDTO();
    private readonly List<ImageSource> uploadedImages = new List<ImageSource>();
    private readonly ApiCategoryService _categoryService;

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
            PickerTitle = "Selecciona im�genes"
        });

        if (result != null)
        {
            var images = result.ToList();
            uploadedImages.Clear();

            if (images.Count > 0)
            {
                var imageSource = ImageSource.FromFile(images[0].FullPath);
                image1.Source = imageSource;
                uploadedImages.Add(imageSource);
            }
            if (images.Count > 1)
            {
                var imageSource = ImageSource.FromFile(images[1].FullPath);
                image2.Source = imageSource;
                uploadedImages.Add(imageSource);
            }
            if (images.Count > 2)
            {
                var imageSource = ImageSource.FromFile(images[2].FullPath);
                image3.Source = imageSource;
                uploadedImages.Add(imageSource);
            }
        }
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        errorProductName.IsVisible = false;
        errorProductDescription.IsVisible = false;
        errorProductCategory.IsVisible = false;
        errorProductCategoryOfInterest.IsVisible = false;

        ProductRequestDTO newProduct = new ProductRequestDTO()
        {
            Product_Name = productNameEntry.Text,
            Product_Description = descriptionEditor.Text,
            Product_IsNew = isNewRadioButton.IsChecked,
            Product_Category = categoryPicker.SelectedItem as CategoryDTO,
            Product_CategoryOfInterest = Categories.Where(category => category.IsSelected).ToList(),
        };

        if (string.IsNullOrEmpty(newProduct.Product_Name))
            errorProductName.IsVisible = true;

        if (string.IsNullOrEmpty(newProduct.Product_Description))
            errorProductDescription.IsVisible = true;

        if (newProduct.Product_Category == null)
            errorProductCategory.IsVisible = true;

        if(newProduct.Product_CategoryOfInterest.Count == 0)
            errorProductCategoryOfInterest.IsVisible = true;

        if (errorProductName.IsVisible || errorProductDescription.IsVisible || errorProductCategory.IsVisible || errorProductCategoryOfInterest.IsVisible)
        {
            await DisplayAlert("Error", "Por favor completa todos los campos.", "OK");
            return;
        }

        if (uploadedImages.Count == 0)
        {
            await DisplayAlert("Error", "Por favor sube al menos una imagen.", "OK");
            return;
        }

        // L�gica para manejar la acci�n de env�o del formulario
        DisplayAlert("Formulario Enviado", "�Gracias por tu informaci�n!", "OK");
    }
}