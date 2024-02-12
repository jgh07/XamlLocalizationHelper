using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using XamlLocalizationHelper.Views;

namespace XamlLocalizationHelper;

public class Commands : ObservableObject
{
    MainWindow window = Application.Current.MainWindow as MainWindow;

    public ICommand CreateNewFileCommand => new RelayCommand(() =>
    {
        new CreateNewDictionaryView().ShowDialog();
    });

    public ICommand OpenFileCommand => new RelayCommand(() =>
    {
        window.LoadFile();
    });

    public ICommand SaveFileCommand => new RelayCommand(() =>
    {
        window.SaveFile();
    });

    public ICommand CopySourceKeyText => new RelayCommand(() =>
    {
        if (window.SourceString.Text == "")
            return;

        window.SourceString.SelectAll();
        window.SourceString.Copy();
        window.SourceString.Select(0, 0);
    });
}