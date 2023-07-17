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

        Button lastClickedButton = null!;
        int clickCount = 1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            if (lastClickedButton == clickedButton) clickCount++;
            else
            {
                lastClickedButton = clickedButton;
                clickCount = 1;
            }
            if (clickCount > 4) clickCount = 1;

            string buttonText = clickedButton.Content.ToString()!;


            if (clickedButton.Content is StackPanel stackPanel)
            {
                // Get the first child of the StackPanel, which is the TextBlock
                if (stackPanel.Children.Count > 0 && stackPanel.Children[0] is TextBlock textBlock)
                {
                    // Access the Text property of the first TextBlock
                    switch (clickCount)
                    {
                        case 1:
                            buttonText = textBlock.Text;
                            break;
                        case 2:
                            inputBuffer.Remove(inputBuffer.Length - 1, 1);
                            buttonText = t9Mappings[textBlock.Text[0]][0].ToString();
                            break;
                        case 3:
                            inputBuffer.Remove(inputBuffer.Length - 1, 1);
                            buttonText = t9Mappings[textBlock.Text[0]][1].ToString();
                            break;
                        case 4:
                            inputBuffer.Remove(inputBuffer.Length - 1, 1);
                            buttonText = t9Mappings[textBlock.Text[0]][2].ToString();
                            break;
                    }

                    inputBuffer.Append(buttonText);
                }
            }
            else
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
            inputBuffer.Clear();
            UpdateInputDisplay();
        }

        private void txtInput_PreviewKeyDown(object sender, KeyEventArgs e) => e.Handled = true;
    }
}
