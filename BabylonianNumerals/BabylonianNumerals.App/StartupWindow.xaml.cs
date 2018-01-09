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
using System.Windows.Shapes;

namespace BabylonianNumerals {
    public partial class StartupWindow : Window {
        public StartupWindow() {
            InitializeComponent();
        }
        private void DecimalToSexagesimalButton_Click(object sender, RoutedEventArgs e) {
            Base10ToBase60Window window = new Base10ToBase60Window();
            window.Show();
            Close();
        }

        private void SexagesimalToDecimalButton_Click(object sender, RoutedEventArgs e) {
            Base60ToBase10Window window = new Base60ToBase10Window();
            window.Show();
            Close();
        }
    }
}
