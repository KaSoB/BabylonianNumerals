using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace BabylonianNumerals {
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }
        private void ConfirmButton_Click(object sender, RoutedEventArgs e) {
            // Wyczyść pole widoku (wyczyść poprzedni wynik)
            Container.Children.Clear();

            // Sprawdź poprawność danych
            long inputValue;
            if (!long.TryParse(ValueTextBox.Text, out inputValue)) {
                MessageBox.Show("Wprowadzona liczba jest niepoprawna lub przekracza maksymalną wartość typu long (" + long.MaxValue + ")");
                return;
            }
            // Dopóki wartość jest różna od zera:
            // 1. Dodaj resztę z dzielenia przez 60 do stosu.
            // 2. Wykonaj dzielenie całkowite przez 60.
            Stack<long> tmpStack = new Stack<long>();
            while (inputValue != 0) {
                tmpStack.Push(inputValue % 60);
                inputValue /= 60;
            }

            // Dopóki stos nie jest pusty:
            // 1. Zdejmuj wartość ze stosu.
            // 2. Stwórz graficzną reprezentację wartości w systemie 60.
            while (tmpStack.Any()) {
                CreateUIItem(tmpStack.Pop());
            }
        }

        private void ValueTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            // Jeżeli podany znak nie jest cyfrą -> ignoruj
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void ValueTextBox_KeyDown(object sender, KeyEventArgs e) {
            // Jeżeli użytkownik wciśnie enter -> wykonaj event ConfirmButton_Click
            if (e.Key == Key.Enter) {
                ConfirmButton_Click(this, new RoutedEventArgs());
            }
        }
        private void CreateUIItem(long value) {
            StackPanel stackPanel = new StackPanel() {
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(15, 0, 15, 0),
                Width = 200,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            StackPanel stackPanel2 = new StackPanel() {
                Orientation = Orientation.Horizontal
            };
            Image image = new Image() {
                Source = new BitmapImage(new Uri("/Res/" + (value / 10) * 10 + ".png", UriKind.Relative)),
                Height = 100,
                Width = 100
            };
            Image image2 = new Image() {
                Source = new BitmapImage(new Uri("/Res/" + value % 10 + ".png", UriKind.Relative)),
                Height = 100,
                Width = 100
            };
            TextBlock textBlock = new TextBlock() {
                TextAlignment = TextAlignment.Center,
                Text = value.ToString(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 20,
                Margin = new Thickness(0, 10, 0, 10)
            };
            stackPanel2.Children.Add(image);
            stackPanel2.Children.Add(image2);
            stackPanel.Children.Add(stackPanel2);
            stackPanel.Children.Add(textBlock);
            Container.Children.Add(stackPanel);
        }

    }

}
