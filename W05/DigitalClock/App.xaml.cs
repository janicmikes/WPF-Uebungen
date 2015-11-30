using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace DigitalClock
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public DispatcherTimer Timer { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Timer = new DispatcherTimer();
            // Jede Sekunde das Tick-Event auslösen:
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Tick += (sender, args) =>
            {
                // Do something...
            };
            Timer.Start();

            MainWindow = new DigitalClock.MainWindow();
            
            // set the data context of the main window, here:
            // ...

            MainWindow.Show();
        }
    }
}
