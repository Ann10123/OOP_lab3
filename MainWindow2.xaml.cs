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

namespace OOP3_2_
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
        public void More_Buttons(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBoxInput1.Text, out int from) &&
                int.TryParse(TextBoxInput2.Text, out int to) &&
                int.TryParse(TextBoxInput3.Text, out int through))
            {
                for (int i = from; i <= to; i += through)
                {
                    Button btn = new Button { Content = $"{i}", Margin = new Thickness(5), Width = 50, Height = 20 };
                    btn.Click += Message_Click;
                    MyWrapPanel.Children.Add(btn);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть коректні числа.");
            }
        }
        public void Message_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                string text = clickedButton.Content.ToString();
                if (int.TryParse(text, out int number))
                {
                    int divisor = IsPrime(number);
                    if (divisor == -1)
                    {
                        MessageBox.Show($"Число просте!");
                    }
                    else
                    {
                        MessageBox.Show($"Число не просте, бо ділиться на {divisor}");
                    }
                }
            }
        }
        private int IsPrime(int number)
        {
            if (number <= 1) return -1;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return i; 
            }
            return -1; 
        }
    }
}
