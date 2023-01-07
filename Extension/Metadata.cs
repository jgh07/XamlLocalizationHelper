namespace XamlLocalizationHelper.Extension;

public static class Metadata
{
    public static string ExtensionName { get; } = "XAML Localization Helper";
    public static string ExtensionDescription { get; } = "An extension to help you localize your XAML-based applications.";
    public static string Tags { get; } = "Tool;WPF;XAML;Productivity;Localization";
    public static string Author { get; } = "Losch";
    public static Version Version { get; } = new(1, 0);
    public static ImageSource Icon { get; } = GetImage();
    public static FlowDocument Document { get; } = (FlowDocument)XamlLocalizationHelperExtension.app.TryFindResource("InfoDocument");

    private static ImageSource GetImage()
    {
        Size size = new(16, 16);

        Viewbox icon = (Viewbox)XamlLocalizationHelperExtension.app.TryFindResource("Localize");
        icon.Measure(size);
        icon.Arrange(new(size));

        RenderTargetBitmap bmp = new(128, 128, 600, 600, PixelFormats.Default);
        bmp.Render(icon);

        return bmp;
    }

    public static Version[] SupportedVersions { get; } = new Version[]
    {
        new(0, 1)
    };
}