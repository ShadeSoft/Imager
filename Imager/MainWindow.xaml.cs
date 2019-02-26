using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Imager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Regex number = new Regex("[^0-9]+");

        private string mode;

        public MainWindow()
        {
            InitializeComponent();
        }

        private static bool IsTextAllowed(string text)
        {
            return !number.IsMatch(text);
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Mode_Checked(object sender, RoutedEventArgs e)
        {
            mode = ((RadioButton)sender).Name.Replace("mode", "").ToLower();
            //System.Diagnostics.Debug.WriteLine(mode);
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void BtnFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == true)
            {
                textFile.Text = ofd.FileName;
            }
        }
    }
}
