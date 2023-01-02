namespace XamlLocalizationHelper.Extension;

public static class Metadata
{
    public static string ExtensionName { get; } = "Xaml Localization Helper";
    public static string ExtensionDescription { get; } = "An extension to help you localizing your XAML-based applications.";
    public static string Tags { get; } = "Tool;WPF;XAML;Productivity;Localization";
    public static string Author { get; } = "Losch";
    public static Version Version { get; } = new(1, 0);

    public static Version[] SupportedVersions { get; } = new Version[]
    {
        new(0, 1)
    };
}