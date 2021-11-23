using Microsoft.Win32;
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

namespace Wpf_13_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Font13();
            styleBox.SelectionChanged += ThemeChange;
            styleBox.SelectedIndex = 0;
        }
        /*12_Binding*/
        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            int styleIndex = styleBox.SelectedIndex;
            Uri uri = new Uri("WB.xaml", UriKind.Relative);
            if (styleIndex == 1)
            {
                uri = new Uri("BW.xaml", UriKind.Relative);
            }
            ResourceDictionary resource1 = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource1);
        }
        /*13_Binding*/
        public class Font13
        {
            public List<string> FontName13 { get; set; }
            public List<string> FontSize13 { get; set; }
            public Font13()
            {
                FontName13 = new List<string> { "Arial", "Times New Roman", "Verdana" };
                FontSize13 = new List<string> { "12", "14", "16" };
            }
        }
        /*RadioButton*/
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (Vindou != null)
            {
                Vindou.Foreground = Brushes.Black;
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (Vindou != null)
            {
                Vindou.Foreground = Brushes.Red;
            }
        }
        /*Button*/
        private void Button_Bold(object sender, RoutedEventArgs e)
        {
            if (Vindou != null)
            {
                Vindou.FontWeight = FontWeights.Bold;
            }
        }

        private void Button_Italic(object sender, RoutedEventArgs e)
        {
            if (Vindou != null)
                if (Vindou != null)
                {
                    Vindou.FontStyle = FontStyles.Italic;
                }
        }

        private void Button_Underline(object sender, RoutedEventArgs e)
        {
            if (Vindou != null)
            {
                Vindou.TextDecorations = TextDecorations.Underline;
            }
        }
        /*Menu*/
        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*txt)|*txt";
            if (openFileDialog.ShowDialog() == true)
            {
                Vindou.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }
        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*txt)|*txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, Vindou.Text);
            }
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        /*Fonts*/
        private void Font_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as String);
            if (Vindou != null)
            {
                Vindou.FontFamily = new FontFamily(fontName);
            }
        }

        private void Size_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string FontSize = ((sender as ComboBox).SelectedItem as String);
            double fontSize = double.Parse(FontSize);
            if (Vindou != null)
            {
                Vindou.FontSize = fontSize;
            }
        }
    }
}
