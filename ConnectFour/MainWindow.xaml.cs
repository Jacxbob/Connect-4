using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ConnectFour
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        //Settings- as seen below
        List<string> Configuration = new List<string>();
        string[] Songs = new string[10];

        bool BarExpanding = false;
        bool BarCollapsing = false;
        bool MenuCollapsed = false;
        bool MenuExpanded = true;
        int sizeMenu = 812;
        int sizeBar = 0;
        int tick = 0;
        double WidthWas = 600;
        double HeightWas = 460;
        bool IsMaximised = false;
        bool PlayPause = true;
        MediaPlayer player = new MediaPlayer();
        int SongMax = 3;
        int SongIndex = 0;

        List<Uri> Music = new List<Uri>
        {
            new Uri(Directory.GetCurrentDirectory() + "/Songs/DropIt.mp3"),
            new Uri(Directory.GetCurrentDirectory() + "/Songs/MountainPath.mp3"),
            new Uri(Directory.GetCurrentDirectory() + "/Songs/PasswordInfinity.mp3"),
            new Uri(Directory.GetCurrentDirectory() + "/Songs/LifeLike.mp3")
        };
        public MainWindow()
        {
            InitializeComponent();
            Configuration.Add("6");
            Configuration.Add("7");
            Configuration.Add("eternal_constance");
            Configuration.Add("0");
            Configuration.Add("Pink");
            Configuration.Add("Purple");
            Configuration.Add("Jacob");
            Configuration.Add("Computer");
            Configuration.Add("2"); //Max index; needs to be changed when songs are added


            player.Open(Music[0]);

            //sizeMenu = Convert.ToInt32(mnuMenu.ActualWidth);
            mnuBar.Width = 0;

            this.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/gradient_" + Configuration[2] + ".jpg")));
            frmShowFrame.Content = new Start(Configuration, ref mnuMenu);
        }
        
        private void itmFullScreen_Click(object sender, RoutedEventArgs e)
        {
            if(IsMaximised)
            {
                IsMaximised = false;
                this.Width = WidthWas;
                this.Height= HeightWas;
            }
            else
            {
                WidthWas = this.Width;
                HeightWas = this.Height;
                this.WindowState = WindowState.Maximized;
                IsMaximised = true;
            }
        }

        private void itmCross_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void itmMinimise_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState=WindowState.Minimized;
        }

        private void itmSettings_Click(object sender, RoutedEventArgs e)
        {
            frmShowFrame.Content = new Settings(Configuration, ref mnuMenu);
        }
        private void itmStart_Click(object sender, RoutedEventArgs e)
        {
            frmShowFrame.Content = new Start(Configuration, ref mnuMenu);
        }

        private void itmGame_Click(object sender, RoutedEventArgs e)
        {
            frmShowFrame.Content = new Game(Configuration, ref mnuMenu);
        }

        private void btnOpenCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            if(MenuExpanded)
            {                
                var timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
                timer.Tick += CollapseMenu;
                timer.Start();

                void CollapseMenu(object s, EventArgs eva)
                {

                    if (MenuExpanded)
                    {
                        if (!MenuCollapsed)
                        {
                            int sizetick = 0;
                            if (sizeMenu > 0)
                            {
                                if(sizeMenu < 300)
                                {
                                    sizetick = 3;
                                }
                                if(sizeMenu < 150)
                                {
                                    sizetick = 5;
                                }
                                sizeMenu += -30;
                                if (sizeMenu < 0)//ensures no errors due to negative widths
                                {
                                    mnuMenu.Width = 0;
                                    sizeMenu = 0;
                                    return;
                                }
                                else
                                {
                                    mnuMenu.Width = sizeMenu;
                                }
                            }
                        }
                        if (sizeMenu <= 0)
                        {
                            MenuCollapsed = true;
                            MenuExpanded = false;
                            btnOpenCloseMenu.Content = "<";
                            timer.Stop();
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if(MenuCollapsed)
            {
                var timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
                timer.Tick += ExpandMenu;
                timer.Start();

                void ExpandMenu(object s, EventArgs eva)
                {
                    if (MenuCollapsed)
                    {
                        if (!MenuExpanded)
                        {
                            int sizetick = 0;
                            if (sizeMenu > 100) //Control decelleration of the bar
                            {
                                sizetick = 5;
                            }
                            if (sizeMenu > 300) //Control decelleration of the bar
                            {
                                sizetick = 7;
                            }
                            if (sizeMenu < 812)
                            {
                                sizeMenu += 30 - sizetick;
                                mnuMenu.Width = sizeMenu;
                            }
                        }
                        if (sizeMenu >= 812)
                        {
                            MenuExpanded = true;
                            MenuCollapsed = false;
                            btnOpenCloseMenu.Content = ">";
                            sizeMenu = 812;
                            timer.Stop();
                        }
                    }
                    else
                    {
                        return;
                    }
                    
                }
            }
        }

        private void btnHoverWhenClosed_MouseEnter(object sender, MouseEventArgs e)
        {
            if(BarCollapsing) //ensures thers no fighting between animations
            {
                return;               
            }
            var timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 5);
            timer.Tick += ExpandBar;
            BarExpanding = true;
            timer.Start();
            
            void ExpandBar(object s, EventArgs eva)
            {
                if(!BarCollapsing && BarExpanding)
                {
                    int sizetick = 0;
                    if (sizeBar > 200) //Control decelleration of the bar
                    {
                        sizetick = 5;
                    }
                    if (sizeBar > 280) //Control decelleration of the bar
                    {
                        sizetick = 7;
                    }
                    if (sizeBar < 300)
                    {
                        sizeBar += 10 - sizetick;
                        mnuBar.Width = sizeBar;
                        bdrmnuBar.Width = sizeBar + 50;
                    }
                }
                if (sizeBar >= 300)
                {
                    BarExpanding = false;
                    sizeBar = 300;
                }
            }
        }

        private void bdrmnuBar_MouseLeave(object sender, MouseEventArgs e)
        {
            if(BarExpanding) //ensures thers no fighting between animations
            {
                return;
            }
            var timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 5);
            BarCollapsing = true;
            timer.Tick += CollapseBar;
            timer.Start();


            void CollapseBar(object s, EventArgs eva)
            {
                if (!BarExpanding && BarCollapsing)
                {
                    int sizetick = 0;
                    if (sizeBar < 180) //Control decelleration of the bar
                    {
                        sizetick = 7;
                    }
                    if (sizeBar < 100) //Control decelleration of the bar
                    {
                        sizetick = 5;
                    }
                    if (sizeBar > 0)
                    {
                        sizeBar += -10 + sizetick;
                        if(sizeBar < 0)//ensures no errors due to negative widths
                        {
                            mnuBar.Width = 0;
                            bdrmnuBar.Width = 50;
                            sizeBar = 0;
                            return;
                        }
                        else
                        {
                            mnuBar.Width = sizeBar;
                            bdrmnuBar.Width = sizeBar + 50;
                        }
                        
                        bdrmnuBar.Width = sizeBar + 50;
                    }
                }
                if (sizeBar <= 0)
                {
                    BarCollapsing = false;
                }
            }
        }

        private void itmPrevious_Click(object sender, RoutedEventArgs e)
        {
            if(SongIndex - 1 == -1)
            {
                SongIndex = SongMax;
            }
            else
            {
                SongIndex--;
            }
            player.Open(Music[SongIndex]);
            player.Play();
        }

        private void itmPlayPause_Click(object sender, RoutedEventArgs e)
        {
            if(PlayPause)
            {
                player.Play();
                PlayPause = false;
                itmPlayPause.Header = "⏸";
                itmPlayPause.FontSize -= -5;
            }
            else
            {
                player.Stop();
                PlayPause = true;
                itmPlayPause.Header = "▶️";
                itmPlayPause.FontSize += -5;
            }
        }

        private void itmNext_Click(object sender, RoutedEventArgs e)
        {
            if(SongIndex + 1 == SongMax)
            {
                SongIndex = 0;
            }
            else
            {
                SongIndex++;
            }
            player.Open(Music[SongIndex]);
            player.Play();
        }

        private void itmRestart_Click(object sender, RoutedEventArgs e)
        {
            frmShowFrame.Content = new Game(Configuration, ref mnuMenu, Player1Score.Text, Player2Score.Text);
        }

        private void itmBackToStart_Click(object sender, RoutedEventArgs e)
        {
            frmShowFrame.Content = new Start(Configuration, ref mnuMenu);
        }

    }

}
