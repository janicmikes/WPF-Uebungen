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

        /// <summary>
        /// checks if the selection in the rich text box is bold
        /// </summary>
        /// <param name="box">the rich text box</param>
        /// <returns>true if it is bold, false otherwise (including
        /// if state could not be determined)</returns>
        private bool IsSelectionBold(RichTextBox box)
        {
            // here's how this works:

            // box.Selection.GetPropertyValue(...) gets the value
            // of the Dependency Property called FontWeightProperty
            // from the xaml object (e.g. a Run- or TextBlock-object)
            // which is currently selected in the Rich Text Box

            // the return value, however, is of type object

            var propVal = box.Selection.GetPropertyValue(FontWeightProperty);


            // type of return value in case of an invalid state:

            // the special (static) value DependencyProperty.UnsetValue
            // is returned if the state could not have been determined
            // (e.g. if the selection contains both, bold and normal weight
            // text). so this case needs to be treated!


            // type of regular return value:

            // if the value could have been determined, it is of the type
            // (= class/struct name) which is encapsulated in the given Dependency
            // Property. In this case, this is the type FontWeight (in other
            // cases it can be a simple double -> use the object browser
            // to find out more about each property if you are interested).


            // Static lookup classes:

            // for types like FontWeight, WPF provides you usually with a
            // static class of the same name and an appended "s" which
            // supplies you with static instances of all the possible
            // values. An example would be FontWeights which contains
            // static properties like e.g. FontWeights.Bold etc.

            // so to check if the selection is bold, we can simply compare
            // it to the static value FontWeights.Bold:

            return (propVal != DependencyProperty.UnsetValue) && (propVal.Equals(FontWeights.Bold));
        }

        /// <summary>
        /// checks if the selection in the rich text box is italic
        /// </summary>
        /// <param name="box">the rich text box</param>
        /// <returns>true if it is italic, false otherwise (including
        /// if state could not be determined)</returns>
        private bool IsSelectionItalic(RichTextBox box)
        {
            var propVal = box.Selection.GetPropertyValue(FontStyleProperty);
            return (propVal != DependencyProperty.UnsetValue) && (propVal.Equals(FontStyles.Italic));
        }

        /// <summary>
        /// checks if the selection in the rich text box is underlined
        /// </summary>
        /// <param name="box">the rich text box</param>
        /// <returns>true if it is underlined, false otherwise (including
        /// if state could not be determined)</returns>
        private bool IsSelectionUnderline(RichTextBox box)
        {
            var propVal = box.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            return (propVal != DependencyProperty.UnsetValue) && (propVal.Equals(TextDecorations.Underline));
        }

        /// <summary>
        /// extracts the font family used in the current selection of
        /// the rich text box
        /// </summary>
        /// <param name="box">the rich text box</param>
        /// <returns>the font family name or null if the state could not
        /// be determined</returns>
        private string GetSelectedFontFamily(RichTextBox box)
        {
            var propVal = box.Selection.GetPropertyValue(FontFamilyProperty);
            if (propVal == DependencyProperty.UnsetValue)
                return null;
            return ((FontFamily)propVal).Source;
        }

        /// <summary>
        /// extracts the font size (double) out of the current selection of
        /// the rich text box
        /// </summary>
        /// <param name="box">the rich text box</param>
        /// <returns>the font size or null (therefore the
        /// nullable type double? is used) if the state could not
        /// be determined</returns>
        private double? GetSelectedFontSize(RichTextBox box)
        {
            var propVal = box.Selection.GetPropertyValue(FontSizeProperty);
            if (propVal == DependencyProperty.UnsetValue)
                return null;
            return (double)propVal;
        }

    }
}
