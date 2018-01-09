using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BabylonianNumerals {
    public partial class Base60ToBase10Window : Window {
        const long MaxSymbols = 25;
        List<long> ValuesList = new List<long>();

        private long _LeftCellValue;
        public long LeftCellValue {
            get { return _LeftCellValue; }
            set {
                _LeftCellValue = value;
                LeftCell.Source = new BitmapImage(new Uri("/Res/" + value + ".png", UriKind.Relative));
            }
        }
        private long _RightCellValue;
        public long RightCellValue {
            get { return _RightCellValue; }
            set {
                _RightCellValue = value;
                RightCell.Source = new BitmapImage(new Uri("/Res/" + value + ".png", UriKind.Relative));
            }
        }

        public Base60ToBase10Window() {
            InitializeComponent();
        }

        private void Image_Click(object sender, RoutedEventArgs e) {
            if (ValuesList.Count >= MaxSymbols) {
                MessageBox.Show("Osiągnięto maksymalną liczbę wprowadzonych symboli.");
                return;
            }
            long imageValue = long.Parse(Regex.Match(((Button) sender).Name, @"\d+").Value);

            if (imageValue >= 10) {
                LeftCellValue = imageValue;
            } else if (imageValue >= 1 && imageValue < 10) {
                RightCellValue = imageValue;
            } else { // "0"
                     // and has already selected leftcell... 
                if (LeftCellValue >= 10) {
                    // clear rightcell
                    RightCellValue = imageValue;
                } else {
                    // else clear both cells
                    LeftCellValue = RightCellValue = 0;
                }
            }
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e) {
            Clear();
        }
        private void ClearCellsButton_Click(object sender, RoutedEventArgs e) {
            ClearCells();
        }
        private void AddCellsButton_Click(object sender, RoutedEventArgs e) {
            long value = LeftCellValue + RightCellValue;

            ValuesList.Add(value);
            // Display figures on displays
            DisplayValue(LeftCellValue);
            DisplayValue(RightCellValue);
            // Calculate and display new result
            ValueTextBlock.Text = Converter.Convert60To10(new Stack<long>(ValuesList)).ToString();
            ClearCells();
        }

        private void Clear() {
            Container.Children.Clear();
            ValueTextBlock.Text = string.Empty;
            ValuesList.Clear();
            ClearCells();
        }
        private void ClearCells() {
            LeftCellValue = 0;
            RightCellValue = 0;
        }
        private void DisplayValue(long value) {
            StackPanel stackPanel = new StackPanel() {
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10, 0, 10, 0),
                Width = 50,
                HorizontalAlignment = HorizontalAlignment.Left,
            };
            Image image = new Image() {
                Source = new BitmapImage(new Uri("/Res/" + value + ".png", UriKind.Relative)),
                Height = 50,
                Width = 50
            };
            stackPanel.Children.Add(image);
            Container.Children.Add(stackPanel);
        }
        private void BackButton_Click(object sender, RoutedEventArgs e) {
            new StartupWindow().Show();
            Close();
        }

    }
}
