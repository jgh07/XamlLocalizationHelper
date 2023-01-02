namespace XamlLocalizationHelper.Extension;

public static class XamlLocalizationHelperExtension
{
    internal static Application app;

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
            Header = app.TryFindResource("StringXamlLocalizationHelperMenu")
        };

        subItem.Click += (_, _) => new MainWindow().ShowDialog();

        if (menu.Items.ToArray().Any(subItem => (subItem as MenuItem)?.Header == app.TryFindResource("StringToolsMenu")))
        {
            MenuItem parentItem = menu.Items.ToArray().First(subItem => (subItem as MenuItem)?.Header == app.TryFindResource("StringToolsMenu")) as MenuItem;
            parentItem!.Items.Add(subItem);

            return;
        }

        MenuItem parentMenu = new()
        {
            Header = app.TryFindResource("StringToolsMenu")
        };

        parentMenu.Items.Add(subItem);
    }
}