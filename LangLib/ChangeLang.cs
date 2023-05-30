using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LangLib
{
    public class ChangeLang
    {
        private static string lang;

        public static string Lang
        {
            get { return lang; }
            set
            {
                lang = value;
                var dict = new ResourceDictionary { Source = new Uri($"pack://application:,,,/LangLib;component/Themes/{value}.xaml", UriKind.Absolute) };
                Application.Current.Resources.MergedDictionaries.RemoveAt(1);
                Application.Current.Resources.MergedDictionaries.Insert(1, dict);

                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                File.WriteAllText($"{desktop}\\lang.txt", value);
            }
        }

        public static void CheckLang()
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (File.Exists($"{desktop}\\theme.txt") && File.Exists($"{desktop}\\lang.txt"))
            {
                Lang = File.ReadAllText($"{desktop}\\lang.txt");
            }
        }
    }
}
