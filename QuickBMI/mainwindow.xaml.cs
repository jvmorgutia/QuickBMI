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

namespace JesseMorgutia.projects.QuickBMI
{
    public partial class Application : Window
    {
        public Application()
        {
            InitializeComponent();
        }
        private static int currentHeight = 1;
        private static double currentWeight = 0;


        private void heightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            heightSlider.Value = (int)e.NewValue;
            heightFieldinFt.Text = inchesToFeet((int)e.NewValue);
            currentHeight = (int)e.NewValue;
            recalculateBMI();
        }

        private string inchesToFeet(int inches)
        {
            int ft = inches / 12;
            int remainder = inches % 12;
            return ft + "\' " + remainder + "\"";
        }

        private void weightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            weightFieldinLbs.Text = e.NewValue.ToString("F1") + " lbs";
            currentWeight = e.NewValue;
            recalculateBMI();
        }


        private void recalculateBMI()
        {
            double bmi = currentWeight * 703 / (currentHeight * currentHeight);
            BMI.Text = bmi.ToString("F1");
            BMI_result.Text = analizeBMI(bmi);
 
        }

        private String analizeBMI(double num)
        {
            if (num >= 30)
            {
                BMI_result.Foreground = new SolidColorBrush(Colors.Red);
                return "Obese";
            }
            else if (num >= 25)
            {
                BMI_result.Foreground = new SolidColorBrush(Colors.Orange);
                return "Overweight";
            }
            else if (num >= 18.5)
            {
                BMI_result.Foreground = new SolidColorBrush(Colors.Green);
                return "Normal";
            }
            else
            {
                BMI_result.Foreground = new SolidColorBrush(Colors.Red);
                return "Underweight";
            }
                
        }
    }
}
