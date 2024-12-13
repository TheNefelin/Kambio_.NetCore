using ClassLibraryClient.Utills;
using ClassLibraryClient.Services;
using ClassLibraryModels.DTOs;
using System.Collections.ObjectModel;

namespace MauiKambio.Pages;

public partial class PublishPage : ContentPage
{
    private readonly ApiCategoryService _categoryService;
    private readonly ApiProductService _apiProductService;
    private readonly List<ImageSource> uploadedImages = new List<ImageSource>();
    private readonly ProductRequestDTO newProduct = new ProductRequestDTO();
    public ObservableCollection<CategoryDTO> Categories { get; set; } = new();

    public PublishPage(ApiCategoryService apiCategoryService, ApiProductService apiProductService)
	{
		InitializeComponent();
        _categoryService = apiCategoryService;
        _apiProductService = apiProductService;
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

        await Navigation.PushModalAsync(new LoadingPage());

        if (result != null)
        {
            var images = result.ToList();
            uploadedImages.Clear();
            newProduct.Images.Clear();

            for (int i = 0; i < images.Count; i++) 
            {
                var originalPath = images[i].FullPath;
                var webpData = ImageConverter.ConvertToWebP(originalPath);
                var webpImageSource = ImageSource.FromStream(() => new MemoryStream(webpData));

                uploadedImages.Add(webpImageSource);

                newProduct.Images.Add(new ImageDTO
                {
                    FileName = $"image{i + 1}.webp",
                    Data = webpData,
                    ContentType = "image/webp"
                });

                switch (i)
                {
                    case 0:
                        //image1.Source = imageSource;
                        image1.Source = webpImageSource;
                        break;
                    case 1:
                        image2.Source = webpImageSource;
                        break;
                    case 2:
                        image3.Source = webpImageSource;
                        break;
                }
            }
        }

        await Navigation.PopModalAsync();
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        errorProductName.IsVisible = false;
        errorProductDescription.IsVisible = false;
        errorProductCategory.IsVisible = false;
        errorProductCategoryOfInterest.IsVisible = false;

        newProduct.Product_IsNew = isNewRadioButton.IsChecked;
        newProduct.Product_Name = productNameEntry.Text;
        newProduct.Product_Description = descriptionEditor.Text;
        newProduct.Product_Category = (CategoryDTO)categoryPicker.SelectedItem;
        newProduct.Product_CategoryOfInterest = Categories.Where(category => category.IsSelected).ToList();

        if (string.IsNullOrEmpty(newProduct.Product_Name))
            errorProductName.IsVisible = true;

        if (string.IsNullOrEmpty(newProduct.Product_Description))
            errorProductDescription.IsVisible = true;

        if (newProduct.Product_Category == null)
            errorProductCategory.IsVisible = true;

        if (newProduct.Product_CategoryOfInterest.Count == 0)
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

        //await _apiProductService.Insert(newProduct);
        await _apiProductService.InsertImage(newProduct.Images);
        
        // Lógica para manejar la acción de envío del formulario
        await DisplayAlert("Formulario Enviado", "¡Gracias por tu información!", "OK");
    }
}