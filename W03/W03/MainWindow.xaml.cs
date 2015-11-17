using System;
using System.Collections.Generic;
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
using Microsoft.Win32;

namespace W03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// displays an open file dialog and reads the contents
        /// of the chosen file
        /// </summary>
        /// <returns>contents of the chosen file (or null if the dialog is cancelled)</returns>
        private string ReadFile()
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog(this) == true)
            {
                var file = dlg.FileName;
                var contents = System.IO.File.ReadAllText(file);
                return contents;
            }
            return null;
        }

        /// <summary>
        /// displays a save file dialog and saves the given string
        /// to the chosen file
        /// </summary>
        /// <returns>true on successful save operation (or false if the dialog is cancelled or an exception occurs)</returns>
        private bool SaveFile(string contents)
        {
            var dlg = new SaveFileDialog();
            if (dlg.ShowDialog(this) == true)
            {
                var file = dlg.FileName;
                try
                {
                    System.IO.File.WriteAllText(file, contents, Encoding.UTF8);
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error while trying to save the file '{file}'");
                }
            }
            return false;
        }
    }
}
