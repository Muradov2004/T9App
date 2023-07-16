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

namespace T9App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<char, string> t9Mappings = new Dictionary<char, string>
        {
            {'2', "abc"},
            {'3', "def"},
            {'4', "ghi"},
            {'5', "jkl"},
            {'6', "mno"},
            {'7', "pqrs"},
            {'8', "tuv"},
            {'9', "wxyz"}
        };

        private StringBuilder inputBuffer = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string buttonText = clickedButton.Content.ToString();
            inputBuffer.Append(buttonText);

            //// Check if the button represents a number or a letter
            //if (char.IsDigit(buttonText[0]))
            //{
            //    // It's a number, add it to the input buffer
            //    inputBuffer.Append(buttonText);
            //}
            //else
            //{
            //    // It's a letter, find the corresponding number and add it to the input buffer
            //    char letter = buttonText[0];
            //    char number = t9Mappings.FirstOrDefault(x => x.Value.Contains(letter)).Key;
            //    if (number != default(char))
            //    {
            //        inputBuffer.Append(number);
            //    }
            //}

            //// Update the UI to show the current input buffer
            UpdateInputDisplay();
        }

        private void UpdateInputDisplay()
        {
            // Assuming you have a TextBlock named "txtInput" to display the input
            txtInput.Text = inputBuffer.ToString();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = string.Empty;
        }
    }
}
