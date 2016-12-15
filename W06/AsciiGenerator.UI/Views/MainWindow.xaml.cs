using AsciiGenerator.UI.ViewModels;
using System.Windows;

namespace AsciiGenerator.UI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AsciiGeneratorViewModel vm = new AsciiGeneratorViewModel();
        public MainWindow()
        {
            InitializeComponent();
        }
        
    }
}
