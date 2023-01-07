namespace XamlLocalizationHelper.Extension;

public static class Metadata
{
    public static string ExtensionName { get; } = "XAML Localization Helper";
    public static string ExtensionDescription { get; } = "An extension to help you localize your XAML-based applications.";
    public static string Tags { get; } = "Tool;WPF;XAML;Productivity;Localization";
    public static string Author { get; } = "Losch";
    public static Version Version { get; } = new(1, 0);
    public static ImageSource Icon { get; } = GetImage();
    public static FlowDocument Document { get; } = GetDocument();/*(FlowDocument)Application.Current.TryFindResource("InfoDocument");*/

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

    private static FlowDocument GetDocument()
    {
        FlowDocument doc = new()
        {
            FontFamily = new("Segoe UI")
        };

        Paragraph header = new(new Run("XAML Localization Helper"))
        {
            FontSize = 18,
            TextDecorations = TextDecorations.Underline,
            FontWeight = FontWeights.SemiBold
        };

        Paragraph text = new();
        text.Inlines.Add("This utility helps you translate your XAML-based applications (WPF, WinUI,...) that use resource dictionaries for their translated strings. It is accessible under the ");

        Run highlight = new("Tools")
        {
            FontWeight = FontWeights.SemiBold
        };
        text.Inlines.Add(highlight);

        text.Inlines.Add(" menu.");

        doc.Blocks.Add(header);
        doc.Blocks.Add(text);

        return doc;
    }

    public static Version[] SupportedVersions { get; } = new Version[]
    {
        new(0, 1)
    };
}