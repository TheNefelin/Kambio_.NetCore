using ClassLibraryModels.DTOs;
using System.Collections.ObjectModel;

namespace MauiKambio.Pages;

public partial class ExplorerPage : ContentPage
{
    public ObservableCollection<string> Images { get; set; }

    public ExplorerPage()
	{
		InitializeComponent();

        Images = new ObservableCollection<string>
            {
                "image1.png",
                "image2.png",
                "image3.png",
            };

        galleryCollectionView.ItemsSource = Images;
        galleryCollectionView.Scrolled += OnGalleryScrolled;
        indicatorView.Count = Images.Count;
    }

    private void OnGalleryScrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        // Actualizar el indicador con la imagen actualmente visible
        if (e.FirstVisibleItemIndex >= 0)
        {
            indicatorView.Position = e.FirstVisibleItemIndex;
        }
    }

}