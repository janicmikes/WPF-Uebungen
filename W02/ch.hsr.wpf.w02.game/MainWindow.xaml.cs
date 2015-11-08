using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace W02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NumberGame Game { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            StartGame();
        }

        private void StartGame()
        {
            Game = new NumberGame(16);
        }
        

        /// <summary>
        /// returns the numeric values of all the togglebuttons
        /// with IsChecked set to true inside the given uniform grid
        /// control
        /// </summary>
        /// <param name="grid"></param>
        /// <returns>a list containing all the int values of the checked toggle buttons in the grid</returns>
        private List<int> GetCheckedNumbers(UniformGrid grid)
        {
            var numbers = new List<int>();
            foreach (var c in grid.Children)
            {
                var tb = c as ToggleButton;
                if (tb == null)
                    continue;

                if (tb.IsChecked != true)
                    continue;

                var nStr = tb.Content.ToString();
                var n = int.Parse(nStr);

                numbers.Add(n);
            }

            // make sure smaller values come first
            numbers.Sort();

            return numbers;
        }

        /// <summary>
        /// returns the number of checked togglebuttons inside
        /// the given uniform grid control
        /// </summary>
        /// <param name="grid">the uniform grid to evaluate</param>
        /// <returns></returns>
        private int CountChecked(UniformGrid grid)
        {
            var count = 0;
            foreach (var c in grid.Children)
            {
                var tb = c as ToggleButton;
                if (tb == null)
                    continue;

                if (tb.IsChecked != true)
                    continue;

                ++count;
            }
            return count;

            // shortest possible solution using linq and c# 6 features would have been:
            //return ButtonContainer.Children.Cast<object>().Count(c => (c as ToggleButton)?.IsChecked == true);
        }
    }
}
