using ClassLibraryClient.Services;
using ClassLibraryModels.DTOs;
using System.Collections.ObjectModel;

namespace MauiKambio.Components;

public partial class SideMenuView : ContentView
{
    public ObservableCollection<CategoryDTO> Categories { get; set; } = new();
    private readonly ApiCategoryService _categoryService;

    public SideMenuView()
	{
		InitializeComponent();
        this.IsVisible = false;
        _categoryService = new ApiCategoryService();
        BindingContext = this;
        LoadCategories();
    }

    private async void LoadCategories()
    {
        var categoryList = _categoryService.GetAll();

        Categories.Clear();
        foreach (var category in categoryList)
        {
            Categories.Add(category);
        };
    }

    private async void onCleanMenu(object sender, EventArgs e)
    {
        foreach (var item in Categories)
        {
            item.IsSelected = false;
        }
    }

    private async void onMenuClosed(object sender, EventArgs e)
    {
        this.IsVisible = false;
    }
}