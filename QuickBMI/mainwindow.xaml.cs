using System;
using System.Windows;
using System.Windows.Media;

namespace JesseMorgutia.projects.QuickBMI
{
    public partial class Application 
    {
        public Application()
        {
            InitializeComponent();
        }
        private static int _currentHeight = 1;
        private static double _currentWeight;


        private void heightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            HeightSlider.Value = (int)e.NewValue;
            HeightFieldinFt.Text = InchesToFeet((int)e.NewValue);
            _currentHeight = (int)e.NewValue;
            RecalculateBmi();
        }

        private static string InchesToFeet(int inches)
        {
            int ft = inches / 12;
            int remainder = inches % 12;
            return ft + "\' " + remainder + "\"";
        }

        private void weightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            WeightFieldinLbs.Text = e.NewValue.ToString("F1") + " lbs";
            _currentWeight = e.NewValue;
            RecalculateBmi();
        }


        private void RecalculateBmi()
        {
            double bmi = _currentWeight * 703 / (_currentHeight * _currentHeight);
            Bmi.Text = bmi.ToString("F1");
            BmiResult.Text = AnalizeBmi(bmi);
 
        }

        private String AnalizeBmi(double num)
        {
            if (num >= 30)
            {
                BmiResult.Foreground = new SolidColorBrush(Colors.Red);
                return "Obese";
            }
            if (num >= 25)
            {
                BmiResult.Foreground = new SolidColorBrush(Colors.Orange);
                return "Overweight";
            }
            if (num >= 18.5)
            {
                BmiResult.Foreground = new SolidColorBrush(Colors.Green);
                return "Normal";
            }
                BmiResult.Foreground = new SolidColorBrush(Colors.Red);
                return "Underweight";
        }
    }
}
