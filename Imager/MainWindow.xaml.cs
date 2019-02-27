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
using Path = System.IO.Path;

namespace Imager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string
            mode,
            format,
            input,
            output;
        private bool inputIsFolder;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NumberInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = (new Regex("[^0-9]+")).IsMatch(e.Text);
        }

        private void Mode_Checked(object sender, RoutedEventArgs e)
        {
            mode = ((RadioButton)sender).Name.Replace("mode", "").ToLower();
            //System.Diagnostics.Debug.WriteLine(mode);
        }

        private void Format_Checked(object sender, RoutedEventArgs e)
        {
            format = ((RadioButton)sender).Name.Replace("format", "").ToLower();
        }

        private void BtnInput_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            // enable folder selection and make it default
            ofd.ValidateNames = false;
            ofd.CheckFileExists = false;
            ofd.CheckPathExists = true;
            ofd.FileName = "Whole folder";

            if(ofd.ShowDialog() == true)
            {
                string dirName = Path.GetDirectoryName(ofd.FileName);
                string fileName = Path.GetFileName(ofd.FileName);

                inputIsFolder = fileName == "Whole folder";
                textInput.Text = input = dirName + (!inputIsFolder ? ("\\" + fileName) : "");
            }
        }

        private void BtnOutput_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            // enable folder selection and make it default
            ofd.ValidateNames = false;
            ofd.CheckFileExists = false;
            ofd.CheckPathExists = true;
            ofd.FileName = "Output folder";

            if(ofd.ShowDialog() == true)
            {
                textOutput.Text = output = Path.GetDirectoryName(ofd.FileName);
            }
        }
    }
}
