using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using String = XamlLocalizationHelper.XamlParser.String;

namespace XamlLocalizationHelper;

public class NewDictionaryViewModel : ObservableObject
{
    private List<StringWithId> _strings = new() { new(id++, "ExampleString1", "Example string text") };
    public List<StringWithId> Strings
    {
        get => _strings;
        set => SetProperty(ref _strings, value);
    }

    private static int id = 1;

    public ICommand AddStringCommand => new RelayCommand(() =>
    {
        Strings.Add(new(id++, "", ""));
        SetProperty(ref _strings, Strings);
    });
}

public class StringWithId
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }

    public StringWithId(int id, string key, string value)
    {
        Id = id;
        Key = key;
        Value = value;
    }
}