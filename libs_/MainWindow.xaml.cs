using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JsonLibb;
using Microsoft.Win32;
using ThemeLib;
using LangLib;

namespace libs_
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ChangeTheme.CheckTheme();
            ChangeLang.CheckLang();
        }

        private void serializeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (msgTbx.Text != "")
            {
                Json.Serialize(msgTbx.Text);
            }
            else
                MessageBox.Show("текстовое поле должно быть заполнено");
        }

        private void deserializeBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true) 
            {
                string path = dialog.FileName;
                MessageBox.Show(Json.Deserialize<string>(path));
            }
        }

        private void darkBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme.Theme = "DarkTheme";
        }

        private void whiteBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeTheme.Theme = "WhiteTheme";
        }

        private void engBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeLang.Lang = "eng";
        }

        private void rusBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeLang.Lang = "rus";
        }
    }
}
