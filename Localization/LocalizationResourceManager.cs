using System.Globalization;
using System.Resources;

namespace NotatnikSilowy.Localization;

public static class LocalizationResourceManager
{
    private static readonly ResourceManager ResourceManager =
        new("NotatnikSilowy.Resources.Localization.AppResources", typeof(LocalizationResourceManager).Assembly);

    public static string GetString(string key)
    {
        return ResourceManager.GetString(key, CultureInfo.CurrentUICulture)
               ?? ResourceManager.GetString(key, CultureInfo.GetCultureInfo("en"))
               ?? key;
    }
}
