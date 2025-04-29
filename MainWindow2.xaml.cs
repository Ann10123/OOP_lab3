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
                if (to >= 1 && to / through <= 10000 && through >= 1)
                {
                    for (int i = from; i <= to; i += through)
                    {
                        Button btn = new Button { Content = $"{i}", Margin = new Thickness(5), Width = 45, Height = 20};
                        btn.Background = Brushes.LightPink;
                        btn.Click += Message_Click;
                        MyWrapPanel.Children.Add(btn);
                        btn.Tag = false;
                    }
                }
                else if (to / through > 10000)
                {
                    MessageBox.Show($"Я не буду створювати {to / through} кнопок!");
                }
                else
                {
                    MessageBox.Show($"Введіть коректні числа!");
                }
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
                        if (clickedButton.Tag is bool wasClicked && wasClicked)
                        {
                            MessageBox.Show($"Скільки можна питати те саме, число {number} просте!");
                            return;
                        }
                        else 
                        {
                            MessageBox.Show($"Число просте!");
                        }
                        clickedButton.Tag = true;
                    }
                    else
                    {
                        if (clickedButton.Tag is bool wasClicked && wasClicked)
                        {
                            MessageBox.Show($"Скільки можна питати те саме, число {number} складене, бо ділиться на {divisor}!");
                            return;
                        }
                        else
                        {
                            MessageBox.Show($"Число {number} складене, бо ділиться на {divisor}!");
                        }
                        clickedButton.Tag = true;
                    }
                }
            }
        }
        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBoxInput4.Text, out int divisor) && divisor != 0)
            {
                var buttonsToDelete = new List<UIElement>();
                foreach (UIElement button in MyWrapPanel.Children)
                {
                    if (button is Button btn && int.TryParse(btn.Content.ToString(), out int numb))
                    {
                        if (numb % divisor == 0)
                        {
                            buttonsToDelete.Add(button);
                        }
                    }
                }
                foreach (var btn in buttonsToDelete)
                {
                    MyWrapPanel.Children.Remove(btn);
                }
            }
            else
            {
                MessageBox.Show($"Число не може бути кратне 0!"); 
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
