using System.IO;
using System.Windows.Markup;

namespace XamlLocalizationHelper.XamlParser;

public static class XamlFileParser
{
    public static List<String> GetStrings(string path)
    {
        List<String> strings = new();
        List<string> keys = new();
        List<string> values = new();

        if (!File.Exists(path))
        {
            AdonisUI.Controls.MessageBox.Show($"Could not find file '{path}'.", "XAML Localization Helper", icon: AdonisUI.Controls.MessageBoxImage.Error);
            return null;
        }

        ResourceDictionary rd = (ResourceDictionary)XamlReader.Parse(File.ReadAllText(path));

        foreach (string key in rd.Keys)
            keys.Add(key);

        foreach (string value in rd.Values)
            values.Add(value);

        for (int i = 0; i < keys.Count; i++)
            strings.Add(new(keys[i], values[i]));

        return strings;
    }

    public static void SaveAsXaml(List<String> strings, string filePath)
    {
        ResourceDictionary rd = new();

        foreach (String s in strings)
        {
            try
            {
                rd.Add(s.Name, s.Value);
            }
            catch (Exception) { }
        }

        if (File.Exists(filePath))
            File.Delete(filePath);

        using StreamWriter sw = new(filePath);
        XamlWriter.Save(rd, sw);
    }
}