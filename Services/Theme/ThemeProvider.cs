using System.Windows;

namespace TestTrainee.Services.Theme
{
    /// <summary>
    /// Theme provider for working with theme
    /// </summary>
    public class ThemeProvider
    {
        /// <summary>
        /// Current theme name for theme synchronization
        /// </summary>
        public static string CurrentTheme = "LightTheme";

        /// <summary>
        /// Switching themes
        /// </summary>
        /// <param name="theme"> Current theme name </param>
        /// <returns> New theme name </returns>
        public string SwitchTheme(string theme)
        {
            var app = App.Current;

            if (app is null)
                return theme;

            string themeFile = $"{theme}.xaml";

            ResourceDictionary? currentTheme = null;

            foreach (var dict in app.Resources.MergedDictionaries)
            {
                if (dict.Source.OriginalString.EndsWith(themeFile)) {
                    currentTheme = dict;
                    break;
                }
            }
            if (currentTheme is not null)
                app.Resources.MergedDictionaries.Remove(currentTheme);

            var newThemeName = theme.Equals("LightTheme") ?
                "DarkTheme" : "LightTheme";

            var newTheme = new ResourceDictionary { Source = 
                new Uri($"Components/Themes/{newThemeName}.xaml", 
                UriKind.RelativeOrAbsolute) };
            app.Resources.MergedDictionaries.Add(newTheme);
            CurrentTheme = newThemeName;
            return newThemeName;
        }
    }
}
