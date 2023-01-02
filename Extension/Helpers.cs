namespace XamlLocalizationHelper.Extension;

internal static class Helpers
{
    public static object[] ToArray(this UIElementCollection collection)
    {
        object[] array = new object[collection.Count];
        collection.CopyTo(array, 0);
        return array;
    }

    public static object[] ToArray(this ItemCollection collection)
    {
        object[] array = new object[collection.Count];
        collection.CopyTo(array, 0);
        return array;
    }
}