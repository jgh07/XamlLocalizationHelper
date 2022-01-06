namespace XamlLocalizationHelper.XamlParser;

public class String
{
    public string Value { get; set; }
    public string Name { get; set; }

    public String(string name, string value)
    {
        Value = value;
        Name = name;
    }

    public String() { }
}