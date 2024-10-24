using Foundation;
using UIKit;

namespace MauiKambio
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

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
    }
}
