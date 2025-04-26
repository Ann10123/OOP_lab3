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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOP3
{
    public partial class MainWindow : Window
    {
        private Random _random = new Random();
        public void YesButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ніхто й не сумнівався!");
        }
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            double currentX = ButtonTranslateTransform.X;
            double currentY = ButtonTranslateTransform.Y;
            double randomX = _random.Next(-75, 75);
            double randomY = _random.Next(-75, 75);

            var animationX = new DoubleAnimation
            {
                From = currentX,
                To = currentX + randomX,
                Duration = new Duration(TimeSpan.FromMilliseconds(250)),
            };

            var animationY = new DoubleAnimation
            {
                From = currentY, 
                To = currentY + randomY,
                Duration = new Duration(TimeSpan.FromMilliseconds(250)),
            };
            ButtonTranslateTransform.BeginAnimation(TranslateTransform.XProperty, animationX);
            ButtonTranslateTransform.BeginAnimation(TranslateTransform.YProperty, animationY);
        }
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
