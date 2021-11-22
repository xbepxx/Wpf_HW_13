using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Lab_13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class Phone
        {
            public string Title { get; set; }
            public string Company { get; set; }
            public int Price { get; set; }
        }


        /*13*/
        public class Font13
        {
            public string FontName13 { get; set; }
            public int FontSize13 { get; set; }
        }
        /*9*/
        public MainWindow()
        {
            InitializeComponent();
            List<string> styles = new List<string>() {"Светлая тема", "Темная тема"};
            styleBox.ItemsSource = styles;
            styleBox.SelectionChanged += ThemeChange;
            styleBox.SelectedIndex = 0;
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            int styleIndex = styleBox.SelectedIndex;
            Uri uri = new Uri("WB.xaml", UriKind.Relative);
            if (styleIndex==1)
            {
                uri=new Uri("BW.xaml", UriKind.Relative);
            }
            ResourceDictionary resource1 = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource1);
        }
        /*1------------------*/
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as String);
            if (Vindou != null)
            {
                Vindou.FontFamily = new FontFamily(fontName);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string FontSize = ((sender as ComboBox).SelectedItem as String);
            double fontSize = double.Parse(FontSize);
            if (Vindou != null)
            {
                Vindou.FontSize = fontSize;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Vindou != null)
            {
                Vindou.FontWeight = FontWeights.Bold;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Vindou != null)
            {
                Vindou.FontStyle= FontStyles.Italic;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Vindou != null)
            {
                Vindou.TextDecorations = TextDecorations.Underline;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //Foreground = "Red"
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
        /*13*/
 








        /*-----------------------------*/
        //private void MenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Text files (*txt)|*txt";
        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        Vindou.Text = File.ReadAllText(openFileDialog.FileName);
        //    }
        //}

        //private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Filter = "Text files (*txt)|*txt";
        //    if (saveFileDialog.ShowDialog() == true)
        //    {
        //        File.WriteAllText(saveFileDialog.FileName, Vindou.Text);
        //    }
        //}

        //private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        //{
        //    Application.Current.Shutdown();
        //}





    }
}
