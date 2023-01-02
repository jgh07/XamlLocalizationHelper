namespace XamlLocalizationHelper.Extension;

public static class XamlLocalizationHelperExtension
{
    private static Application app;

    public static void ExtMain(Application _app)
    {
        app = _app;

        InitializeMenu();
    }

    private static void InitializeMenu()
    {
        Grid grid = (Grid)(app.MainWindow.Content as Grid).Children.ToArray().First(o => Grid.GetRow((UIElement)o) == 0 && Grid.GetColumn((UIElement)o) == 0 && Grid.GetColumnSpan((UIElement)o) == 7);

        Menu menu = (Menu)grid.Children.ToArray().First(o => Grid.GetColumn((UIElement)o) == 2);

        MenuItem subItem = new()
        {
            Header = "XAML Localization Helper"
        };

        subItem.Click += (_, _) => new MainWindow().ShowDialog();

        if (menu.Items.ToArray().Any(subItem => (subItem as MenuItem)?.Header.ToString().EndsWith("Tools") ?? false))
        {
            MenuItem parentItem = menu.Items.ToArray().First(subItem => (subItem as MenuItem)?.Header.ToString().EndsWith("Tools") ?? false) as MenuItem;
            parentItem!.Items.Add(subItem);

            return;
        }

        MenuItem parentMenu = new()
        {
            Header = "Tools"
        };

        parentMenu.Items.Add(subItem);
    }
}