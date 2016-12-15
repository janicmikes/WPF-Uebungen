using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AsciiGenerator.UI.ViewModels;
using AsciiGenerator.UI.Views;

namespace AsciiGenerator.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public AsciiGeneratorViewModel AppVm { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            AppVm = new AsciiGeneratorViewModel();
            MainWindow = new MainWindow();
            MainWindow.DataContext = AppVm;
            MainWindow.Show();
        }
    }
}
