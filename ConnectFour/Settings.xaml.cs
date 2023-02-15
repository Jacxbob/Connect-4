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

namespace ConnectFour
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        List<string> Configuration = new List<string>();
        Menu mnuMenu = new Menu();

        public Settings(List<string> C, ref Menu M)
        {
            Configuration = C;
            mnuMenu = M;
            InitializeComponent();
        }

        private void cbxBackground_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var window = (MainWindow)Application.Current.MainWindow;
            window.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/gradient_" + ((ComboBoxItem)cbxBackground.SelectedItem).Content.ToString() + ".jpg")));
        }

        private void cbxMusic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
