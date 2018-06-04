using System.Windows;
using System.Windows.Controls;

namespace WpfView
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            btnSalvar.Content = "bla bla bla";
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            btnSalvar.Visibility = Visibility.Hidden;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            btnSalvar.Visibility = Visibility.Visible;
        }

        private void txtNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNome.Text.Length > 3)
            {
                MessageBox.Show("Você passou do limite");
            }
        }
    }
}
