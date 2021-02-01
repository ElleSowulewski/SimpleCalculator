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

namespace SimpleCalculator
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
        private void button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void button_Help_Click(object sender, RoutedEventArgs e)
        {
            Help helpWindow = new Help();
            helpWindow.ShowDialog();
        }

        private void button_Operand_Click(object sender, RoutedEventArgs e)
        {

            double.TryParse(textBox_Operand1.Text, out double operand1);
            double.TryParse(textBox_Operand2.Text, out double operand2);

            Button operationButton = (Button)sender;

            string operation = operationButton.Name;
            double answer = 0;
            string userFeedback = "";

            if (ValidInputs(out userFeedback))
            {

                switch (operation)
                {
                    case "button_Add":
                        answer = operand1 + operand2;
                        break;

                    case "button_Subtract":
                        answer = operand1 - operand2;
                        break;

                    case "button_Multiply":
                        answer = operand1 * operand2;
                        break;

                    case "button_Divide":
                        answer = operand1 / operand2;
                        break;

                    default:
                        answer = 0;
                        break;
                }
            }
            else
            {
                MessageBox.Show(userFeedback);
            }

            Label_Answer.Content = answer.ToString();

        }

        private bool ValidInputs(out string userFeedback)
        {

            bool validInputs = true;
            userFeedback = "";

            if (!double.TryParse(textBox_Operand1.Text, out double tempOperand1))
            {
                validInputs = false;
                userFeedback += "Your input for Operand 1 is not valid. Please enter a number." + Environment.NewLine;
            }
            if (!double.TryParse(textBox_Operand2.Text, out double tempOperand2))
            {
                validInputs = false;
                userFeedback += "Your input for Operand 2 is not valid. Please enter a number." + Environment.NewLine;
            }

            return validInputs;

        }

        private void textChanged1(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(textBox_Operand1.Text, out double tempOperand1))
            {
                textBox_Operand1.Foreground = Brushes.Red;
            }
            else
            {
                textBox_Operand1.Foreground = Brushes.Black;
            }
        }

        private void textChanged2(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(textBox_Operand2.Text, out double tempOperand2))
            {
                textBox_Operand2.Foreground = Brushes.Red;
            }
            else
            {
                textBox_Operand2.Foreground = Brushes.Black;
            }
        }
    }
}
