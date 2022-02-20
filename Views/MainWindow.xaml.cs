using Microsoft.Win32;
using XamlLocalizationHelper.XamlParser;

namespace XamlLocalizationHelper;

public partial class MainWindow : AdonisWindow
{
    int index = 0;
    string sourceLanguageCode;
    string targetLanguageCode;
    string currentFilePath;
    bool overrideNextKey = false;

    private List<XamlParser.String> SourceStrings = new();
    private List<XamlParser.String> LocalizedStrings = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void TargetLanguageTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        TargetLanguageKeyText.Text = TargetLanguageTextBox.Text;
        targetLanguageCode = TargetLanguageTextBox.Text;
    }

    private void GetPrevKeyButton_Click(object sender, RoutedEventArgs e)
    {
        if (index == 0)
        {
            AdonisUI.Controls.MessageBox.Show("Reached first string.", "XAML Localization Helper", icon: AdonisUI.Controls.MessageBoxImage.Information);
            return;
        }

        LocalizedStrings.Add(new(SourceStrings[index].Name, LocalizedStringTextBox.Text));

        index--;
        LocalizedStringTextBox.Clear();
        SourceString.Text = SourceStrings[index].Value;
        CurrentKeyText.Text = SourceStrings[index].Name;

        LocalizedStringTextBox.Text = LocalizedStrings[index].Value;

        overrideNextKey = true;
    }

    private void GetNextKeyButton_Click(object sender, RoutedEventArgs e)
    {
        if (SourceStrings.Count == 0)
        {
            AdonisUI.Controls.MessageBox.Show("No strings to localize.", "XAML Localization Helper", icon: AdonisUI.Controls.MessageBoxImage.Information);
            return;
        }

        if (overrideNextKey)
        {
            LocalizedStrings[index] = new(SourceStrings[index].Name, LocalizedStringTextBox.Text);
            overrideNextKey = false;
        }
        else
            LocalizedStrings.Add(new(SourceStrings[index].Name, LocalizedStringTextBox.Text));

        index++;
        if (index == SourceStrings.Count)
        {
            AdonisUI.Controls.MessageBox.Show("No more strings to localize.", "XAML Localization Helper", icon: AdonisUI.Controls.MessageBoxImage.Information);
            return;
        }

        LocalizedStringTextBox.Clear();
        SourceString.Text = SourceStrings[index].Value;
        CurrentKeyText.Text = SourceStrings[index].Name;
    }

    public void LoadFile() => LoadXamlFileButton_Click(this, new());

    private void LoadXamlFileButton_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog ofd = new()
        {
            Multiselect = false,
            Filter = "XAML files (*.xaml)|*.xaml|All files (*.*)|*.*"
        };

        if (ofd.ShowDialog(this) == true)
        {
            currentFilePath = ofd.FileName;
            LocalizedStrings = new();
            index = 0;

            sourceLanguageCode = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName).Split('_').Last();
            SourceLanguageKeyText.Text = sourceLanguageCode;

            SelectedFileText.Text = System.IO.Path.GetFileName(ofd.FileName);
            SourceStrings = XamlFileParser.GetStrings(ofd.FileName);

            SourceString.Text = SourceStrings[index].Value;
            CurrentKeyText.Text = SourceStrings[index].Name;
            LocalizedStringTextBox.Text = "";
        }
    }

    public void SaveFile() => SaveFileButton_Click(this, new());

    private void SaveFileButton_Click(object sender, RoutedEventArgs e)
    {
        if (LocalizedStrings.Count == 0)
        {
            AdonisUI.Controls.MessageBox.Show("No strings to save.", "XAML Localization Helper", icon: AdonisUI.Controls.MessageBoxImage.Information);
            return;
        }

        try
        {
            LocalizedStrings.Add(new(SourceStrings[index].Name, LocalizedStringTextBox.Text));
        }
        catch (Exception) { }

        // split the '_en-US' from the file path
        string fileNameWithoutLang = string.Concat(System.IO.Path.GetFileNameWithoutExtension(currentFilePath).Split('_').Take(System.IO.Path.GetFileNameWithoutExtension(currentFilePath).Split('_').Length - 1));
        // rebuild the path with different language at the end
        string endFilePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(currentFilePath), $"{fileNameWithoutLang}_{targetLanguageCode}{System.IO.Path.GetExtension(currentFilePath)}");

        XamlFileParser.SaveAsXaml(LocalizedStrings, endFilePath);
        AdonisUI.Controls.MessageBox.Show("Successfully saved to disk.", "XAML Localization Helper", icon: AdonisUI.Controls.MessageBoxImage.Information);
    }

    private void AdonisWindow_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (!e.IsDown)
            return;

        if (e.Key == Key.Right)
        {
            GetNextKeyButton_Click(this, new());
            return;
        }

        if (e.Key == Key.Left)
        {
            GetPrevKeyButton_Click(this, new());
            return;
        }
    }
}