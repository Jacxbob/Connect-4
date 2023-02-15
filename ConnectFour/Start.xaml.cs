using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Imaging;
using System.Drawing;
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
using System.Windows.Threading;

namespace ConnectFour
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Page
    {
        string Config = "";
        Menu mnuMenu = new Menu();
        List<string> Configuration = new List<string>();
        string[] Colours = { "Red", "Orange", "Yellow", "Green", "Blue", "Purple", "Pink" };
        int ColourIndex = 0;
        double bob = 0;


        public Start(List<string> C, ref Menu M)
        {
            Configuration = C;
            mnuMenu = M;
            InitializeComponent();
            imgPlayer1Nought.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Nought_" + Configuration[4] + ".png"));
            imgPlayer2Nought.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Nought_" + Configuration[5] + ".png"));

            //Animate the counters to bop up and down
            var timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Tick += BopOpposite;
            timer.Start();

            void BopOpposite(object sender, EventArgs e)
            {                
                Thickness t1 = imgPlayer1Nought.Margin;  //Marigns of the images 
                Thickness t2 = imgPlayer2Nought.Margin;

                t1.Top += 3*(Math.Sin(bob)); //Using Math.sin to smooth the animation of the bobbing on the start screen
                t1.Bottom += 3*(-Math.Sin(bob));   //Sine ensures a smooth curve

                t2.Top += 3*(-Math.Sin(bob));
                t2.Bottom += 3*(Math.Sin(bob));

                imgPlayer1Nought.Margin = t1;
                imgPlayer2Nought.Margin = t2;
                bob += 0.5;
            }
        }

        private void tbxPlayer1Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            Configuration[6] = tbxPlayer1Name.Text;
        }

        private void tbxPlayer2Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            Configuration[7] = tbxPlayer2Name.Text;
        }

        private void btnPlayer1Previous_Click(object sender, RoutedEventArgs e)
        {
            if (ColourIndex == 0)
            {
                ColourIndex = 6;
            }
            else
            {
                Configuration[4] = Colours[--ColourIndex];
            }
            imgPlayer1Nought.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Nought_" + Configuration[4] + ".png"));
        }

        private void btnPlayer1Next_Click(object sender, RoutedEventArgs e)
        {
            if (ColourIndex == 6)
            {
                ColourIndex = 0;
            }
            else
            {
                Configuration[4] = Colours[++ColourIndex];
            };
            imgPlayer1Nought.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Nought_" + Configuration[4] + ".png"));
        }

        private void btnPlayer2Previous_Click(object sender, RoutedEventArgs e)
        {
            if (ColourIndex == 0)
            {
                ColourIndex = 6;
            }
            else
            {
                Configuration[5] = Colours[--ColourIndex];
            }
            imgPlayer2Nought.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Nought_" + Configuration[5] + ".png"));
        }

        private void btnPlayer2Next_Click(object sender, RoutedEventArgs e)
        {
            if(ColourIndex == 6)
            {
                ColourIndex = 0;
            }
            else
            {
                Configuration[5] = Colours[++ColourIndex];
            }
           
            imgPlayer2Nought.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Nought_" + Configuration[5] + ".png"));
        }
    }
}
