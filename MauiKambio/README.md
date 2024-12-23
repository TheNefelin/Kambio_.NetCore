﻿# Kambio MauiApp .NET Core 8

## Menu
- [Ir a Editar iconos SVG](#editar-iconos-svg)
- [Ir a Dependencias](#Dependencias)
- [Ir a Estructura](#Estructura)
- [Ir a Configuraciones](#configuraciones)
- [Ir a Binding](#binding)
- [Ir a ](#)
 
### Editar iconos SVG
* [Photopea](https://www.photopea.com/)
* [Controles MAUI](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/?view=net-maui-8.0)

### Dependencias
```
```

### Estructura
```
MauiAdminApp/
│
├── Pages/
│   ├── ExplorerPage.xaml   (.cs)
│   ├── LoginPage.xaml      (.cs)
│   └── UserPage.xaml       (.cs)
├── Resources/
│   ├── AppIcon/    (icon ejecutable)
│   ├── Fonts/
│   ├── Images/
│   ├── raw/        (multimedia video)
│   ├── Splash/     (fondo pantalla de carga)
│   └── Styles/
├── Services/
│   ├── Serv1.cs
│   └── Serv2.cs
├── App.xaml        (.cs)
├── AppShell.xaml   (.cs)
├── MauiProgram.cs
└── README.md
```

## Configuraciones
### Cambiar color barra superior segun plataforma
* MainActivity.cs
```
protected override void OnCreate(Bundle savedInstanceState)
{
    base.OnCreate(savedInstanceState);
    Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#08bdbd"));
    Window.SetNavigationBarColor(Android.Graphics.Color.ParseColor("#08bdbd"));
}
```
* AppDelegate.cs
```
public override bool FinishedLaunching(UIApplication app, NSDictionary options)
{
    // Cambia el color de la barra de estado
    UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);

    // Si estás usando un color específico, puedes establecer el color del fondo de la barra de estado
    UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(8, 189, 189); // Cambia a tu color deseado

    // Configurar el color de la barra de navegación si estás utilizando navegación
    UITabBar.Appearance.BarTintColor = UIColor.FromRGB(8, 189, 189); // Cambia a tu color deseado

    return base.FinishedLaunching(app, options);
}
```

### Cambiar el welcome screen logo y color de fondo segun plataforma
* Modificar el icono en **\Resources\Splash\splash.svg** (Photopea)

### Cambiar en icon de la app  
* Modificar el icono en **\Resources\AppIcon\appiconfg.svg** (Photopea) <br>
* Cambiar el color de fondo en **\Resources\AppIcon\appicon.svg** (Photopea)

### Forzar tema Dark o Light **App.xaml.cs**
```
InitializeComponent();

Application.Current.UserAppTheme = AppTheme.Light;
```

### Colores
* .\Platforms\Android\Resources\values\colors.xml?

## Para Lectura
* **Text:** El texto que muestra el control (usado en Label, Button, etc.).
* **BackgroundColor:** El color de fondo del control.
* **TextColor:** El color del texto.
* **Padding:** Define el espacio interno entre el contenido y los bordes del control.
* **Margin:** Define el espacio externo entre el control y otros elementos.
* **HorizontalOptions y VerticalOptions:** Definen cómo el control se alinea dentro de su contenedor.
* **FontSize:** Define el tamaño de la fuente del texto.
* **IsVisible:** Determina si el control es visible o no.

### Controles de contenido singular
```
<Button Text="Click me" Clicked="OnClicked"/>

<Label Text="Hello, MAUI!" />

<Image Source="logo.png"/>

<ContentPage> </ContentPage>

<Frame Padding="10"> </Frame>

<ScrollView> </ScrollView>
```

### Controles de contenido multiple
* Grid
```
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto" />
        <RowDefinition Height="*" />
    </Grid.RowDefinitions>

    <StackLayout Grid.Row="0">
    </StackLayout>

    <ScrollView Grid.Row="1">
    </ScrollView>
</Grid>
```
* CollectionView
```
<CollectionView ItemsSource="{Binding Products}">
    <CollectionView.ItemsLayout>
        <GridItemsLayout Orientation="Vertical" Span="2" />
    </CollectionView.ItemsLayout>

    <CollectionView.ItemTemplate>
        <DataTemplate>
            <!-- Aqui van lo Elementos a iterar de Products -->
        </DataTemplate>
    </CollectionView.ItemTemplate>
</CollectionView>
```

```
<ScrollView> </ScrollView>

<StackLayout Orientation="Vertical"> </StackLayout>

<FlexLayout Direction="Row" JustifyContent="SpaceBetween"> </FlexLayout>

<AbsoluteLayout> </AbsoluteLayout>

<VerticalStackLayout> </VerticalStackLayout>

<HorizontalStackLayout> </HorizontalStackLayout>
```

## Binding 
> (Vincular Datos con la Vista)
### Iterar una coleccion de elementos.
* ObservableCollection: Permite manipular una colección reactiva.
* El observable se debe llenar con los datos que obtienes del servicio.
* Agregar BindingContext = this en el constructor.
```
public ObservableCollection<ProductDTO> Products { get; set; } = new();

public Constructor()
{
    initializecomponent();
    BindingContext = this;
}

private async void LoadProducts()
{
    var productList = _productService.GetAll();

    foreach (var product in productList)
    {
        Products.Add(product);
    }
}
```
* Los elementos ColectionView permiten iterar el Binding.
* Se asigna la propiedad Img de cada Product de Products en ImageButton
```
<CollectionView ItemsSource="{Binding Products}">
    <ImageButton Clicked="OnProductClicked" Source="{Binding Img}"/>
</CollectionView>
```
* Recuperar el Producto al Hacer clic en ImageButton a través del método
```
private async void OnProductClicked(object sender, EventArgs e)
{
    var imageButton = (ImageButton)sender;
    var product = (ProductDTO)((BindableObject)imageButton.Parent).BindingContext;

    if (product != null)
    {
        await Navigation.PushAsync(new ProductPage(product));
    }
}
```

### Crear Componente y pasar datos staticos
* **Componente:** xaml tipo ContentView
* **BindableProperty:** que permite enlazar datos externos al componente.
* BindableProperty.Create(Nombre, TipoDeDato, ClaseDondeSeDeclara, NuloAlIniciar);
```
```

<hr>
<hr>
<hr>

* En el codigo se crea un observable del elemento que se quiere hacer Bind (en una Lista, sino, Pa Ke po).
* Deberia tener un metodo en donde se mapea los datos del servicio al observable
* Se debe hacer un BindingContext = this en el constructor
```

```