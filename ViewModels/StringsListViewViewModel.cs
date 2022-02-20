using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using XamlLocalizationHelper.Views;
using XamlLocalizationHelper.XamlParser;
using String = XamlLocalizationHelper.XamlParser.String;

namespace XamlLocalizationHelper;

public class StringsListViewViewModel : ObservableObject
{
    public List<String> Strings = new();
}