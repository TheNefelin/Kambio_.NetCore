# Kambio MauiApp .NET Core 8

### Editar iconos SVG
* [Photopea](https://www.photopea.com/)
* [Controles MAUI](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/?view=net-maui-8.0)

### Dependencias

### Estructura
```
MauiAdminApp/
│
├── Pages/
│   ├── LoginPage.xaml      (.cs)
│   └── SettingsPage.xaml   (.cs)
├── Resources/
│   ├── AppIcon/
│   ├── Fonts/
│   ├── Images/
│   ├── raw/
│   ├── Splash/
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
* Text: El texto que muestra el control (usado en Label, Button, etc.).
* BackgroundColor: El color de fondo del control.
* TextColor: El color del texto.
* Padding: Define el espacio interno entre el contenido y los bordes del control.
* Margin: Define el espacio externo entre el control y otros elementos.
* HorizontalOptions y VerticalOptions: Definen cómo el control se alinea dentro de su contenedor.
* FontSize: Define el tamaño de la fuente del texto.
* IsVisible: Determina si el control es visible o no.

### Controles de contenio singular
```
<Button Text="Click me" Clicked="OnClicked" />

<Label Text="Hello, MAUI!" />

<Image Source="logo.png" />

<ContentPage> </ContentPage>

<Frame Padding="10"> 
</Frame>

<ScrollView> </ScrollView>
```

### Controles de contenido multiple
```
<StackLayout Orientation="Vertical"> </StackLayout>

<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto" />
        <RowDefinition Height="*" />
    </Grid.RowDefinitions>

    <Label Grid.Row="0" Text="Row 1" />
    <Button Grid.Row="1" Text="Button" />
</Grid>

<AbsoluteLayout>
    <Label Text="Positioned Label"
           AbsoluteLayout.LayoutBounds="0.5, 0.5, AutoSize, AutoSize"
           AbsoluteLayout.LayoutFlags="PositionProportional" />
</AbsoluteLayout>

<FlexLayout Direction="Row" JustifyContent="SpaceBetween">
    <Label Text="Item 1" />
    <Button Text="Item 2" />
</FlexLayout>
```

