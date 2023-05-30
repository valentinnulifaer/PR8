using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ThemeLib
{
    public class ChangeTheme
    {
        private static string theme;

        public static string Theme
        {
            get { return theme; }
            set
            {
                theme = value;
                var dict = new ResourceDictionary { Source = new Uri($"pack://application:,,,/ThemeLib;component/Themes/{value}.xaml", UriKind.Absolute) };
                Application.Current.Resources.MergedDictionaries.RemoveAt(0);
                Application.Current.Resources.MergedDictionaries.Insert(0, dict);

                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                File.WriteAllText($"{desktop}\\theme.txt", value);
            }
        }

        public static void CheckTheme()
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (File.Exists($"{desktop}\\theme.txt") && File.Exists($"{desktop}\\lang.txt"))
            {
                Theme = File.ReadAllText($"{desktop}\\theme.txt");
            }
        }
    }
}
