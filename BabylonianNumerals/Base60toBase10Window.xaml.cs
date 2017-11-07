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
    /// <summary>
    /// Interaction logic for Base60ToBase10Window.xaml
    /// </summary>
    public partial class Base60ToBase10Window : Window {
        const long MaxSymbols = 25;
        bool bugFix = true; // TODO: fix it :/
        long previousValue;
        List<long> list = new List<long>();

        public Base60ToBase10Window() {
            InitializeComponent();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e) {
            Container.Children.Clear();
            ValueTextBlock.Text = string.Empty;
            list.Clear();
            previousValue = 0;
            bugFix = true;
        }
        private void Image_Click(object sender, RoutedEventArgs e) {
            if (list.Count >= MaxSymbols) {
                MessageBox.Show("Osiągnięto maksymalną liczbę wprowadzonych symboli.");
                return;
            }

            Button button = (Button) sender;
            long imageValue = long.Parse(Regex.Match(button.Name, @"\d+").Value);
            AddMissingZero(imageValue);
            AddItem(imageValue);
            
            ValueTextBlock.Text = Converter.ConvertTo10(MergeValues()).ToString();
            previousValue = imageValue;
        }

        private void AddMissingZero(long value) {
            // Metoda zapobiega przed niepoprawnymi wyrażeniami wprowadzonymi przez użytkownika.
            // Np. wprowadzenie dwóch 10-tek bez określenia cyfry jedności

            if ((bugFix && value > 0 && value < 10) || // Jeżeli użytkownik wpisał cyfrę jedności (Na początku)
                (value > 0 && value < 10 && previousValue > 0 && previousValue < 10) || // Jeżeli użytkownik wpisał 2 lub więcej cyfr jedności 
                value >= 10 && previousValue >= 10) { // Jeżeli użytkownik wpisał x-dziesiątek
                AddItem(0);
                bugFix = false;
            }
        }

        // Example: 30 6  50 2  0 7 => 36 52 7
        private Stack<long> MergeValues() => new Stack<long>(list
           .Select((s, i) => new { s, i })
           .GroupBy(n => n.i / 2)
           .Select(g => g.Sum(p => p.s)).ToList());

        private void AddItem(long value) {
            list.Add(value);

            StackPanel stackPanel = new StackPanel() {
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(15, 0, 15, 0),
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
            StartupWindow window = new StartupWindow();
            window.Show();
            Close();
        }
    }
}
