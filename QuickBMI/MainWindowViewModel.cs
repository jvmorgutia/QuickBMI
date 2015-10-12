using System;
using System.Windows.Media;

namespace JesseMorgutia.Projects.QuickBMI
{
    public class MainWindowViewModel : ViewModelBase
    {
        private double _bmi;
        private double _selectedWeight;
        private int _selectedHeight;
        private string _selectedHeightString;
        private string _currentBmiString;
        private SolidColorBrush _currentBmiColor;

        public double Bmi
        {
            get { return _bmi; }
            set
            {
                _bmi = value;
                OnPropertyChanged("Bmi");
            }
        }
        public double SelectedWeight
        {
            get { return _selectedWeight; }
            set
            {
                _selectedWeight = Math.Round(value);
                OnPropertyChanged("SelectedWeight");
                RecalculateBmi();
            }
        }
        public int SelectedHeight
        {
            get { return _selectedHeight; }
            set
            {
                _selectedHeight = value;
                SelectedHeightString = InchesToFeet(_selectedHeight);
                OnPropertyChanged("SelectedHeight");
                RecalculateBmi();
            }
        }

        public string SelectedHeightString
        {
            get { return _selectedHeightString; }
            set
            {
                _selectedHeightString = value;
                OnPropertyChanged("SelectedHeightString");
            }
        }

        public string CurrentBmiString
        {
            get { return _currentBmiString; }
            set
            {
                _currentBmiString = value;
                OnPropertyChanged("CurrentBmiString");
            }
        }
        public SolidColorBrush CurrentBmiColor
        {
            get { return _currentBmiColor; }
            set
            {
                _currentBmiColor = value;
                OnPropertyChanged("CurrentBmiColor");
            }
        }
        public MainWindowViewModel()
        {
            SelectedHeight = 72;
            SelectedWeight = 180;
        }

        private void RecalculateBmi()
        {
            Bmi = Math.Round(SelectedWeight*703/Math.Pow(SelectedHeight, 2), 1);
            CurrentBmiString = AnalizeBmi(Bmi);
        }

        private static string InchesToFeet(int inches)
        {
            int ft = inches / 12;
            int remainder = inches % 12;
            return ft + "\' " + remainder + "\"";
        }

        private string AnalizeBmi(double number)
        {
            if (number >= 30)
            {
                CurrentBmiColor = new SolidColorBrush(Colors.Red);
                return "Obese";
            }
            if (number >= 25)
            {
                CurrentBmiColor = new SolidColorBrush(Colors.Orange);
                return "Overweight";
            }
            if (number >= 18.5)
            {
                CurrentBmiColor = new SolidColorBrush(Colors.Green);
                return "Normal";
            }
            CurrentBmiColor = new SolidColorBrush(Colors.Red);
            return "Underweight";
        }
    }
}

