# XAML Localization Helper
This tool is designed to help you translate and localize your XAML applications. It provides a graphical user interface allowing you to view a string of text in one language and directly input a translation in another language.

![1](https://user-images.githubusercontent.com/35030845/154850807-c534423f-5f87-4f39-af68-3b178658dc6b.png)

Currently, the only supported localization format is a resource dictionary containing System.String resources. You can use these in your XAML using resource bindings (``{DynamicResource YourStringResource}``).


To use the tool, you first have to have a source resource dictionary in a language of your choice, which you will translate. You can write it yourself or generate it using this tool (not yet supported). Once you have a file, open it using the "Select file..." button. In the text box at the top, type in your target language. After that, you can translate all strings and click on "Save file". This will automatically save your translation in a new file.

## Key bindings
Binding|Description
---|---
Ctrl + O|Opens a resource dictionary.
Ctrl + S|Saves a translated resource dictionary.
Ctrl + Q|Copies the text from the source string text box.
Arrow Right|Next string
Arrow Left|Previous string
