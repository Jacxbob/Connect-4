using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ConnectFour
{
    //Restart Swtich Draw ... Play Pause Skip
    public partial class Game : Page
    {
        Menu mnuMenu;
        List<List<int>> Board = new List<List<int>>();
        List<string> Configuration = new List<string>();
        int PlayerGo = 1; // 1/2 = Player1/2
        int PositionOfCounter = 1;
        int counterNumber = 0;
        bool AIPlayer = true;

        public Game(List<string> C, ref Menu M)
        {
            Configuration = C;
            mnuMenu = M;
            InitializeComponent();

            tblPlayer1Name.Text = Configuration[6];
            tblPlayer2Name.Text = Configuration[7];

            for (int Rows = 0; Rows < Int32.Parse(Configuration[0]); Rows++)
            {
                List<int> lstTemp = new List<int>();
                for (int Columns = 0; Columns < Int32.Parse(Configuration[1]); Columns++)
                {
                    lstTemp.Add(0);
                }
                Board.Add(lstTemp);
            }


            //Create grid on screen
            btnimgNought.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/Nought_" + Configuration[4] + ".png")));

            for (int col = 0; col < Int32.Parse(Configuration[1]); col++)
            {
                grdBoard.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int row = 0; row < Int32.Parse(Configuration[0]); row++)
            {
                grdBoard.RowDefinitions.Add(new RowDefinition());
            }


            //Place In Black board

            for (int Rows = 0; Rows < Int32.Parse(Configuration[0]); Rows++)
            {
                for (int Columns = 0; Columns < Int32.Parse(Configuration[1]); Columns++)
                {
                    System.Windows.Controls.Image imgTemplate = new System.Windows.Controls.Image();
                    imgTemplate.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/NoughtBackground.png"));
                    Grid.SetRow(imgTemplate, Rows);
                    Grid.SetColumn(imgTemplate, Columns);
                    grdBoard.Children.Add(imgTemplate);
                }
            }
        } //Main Constructor

        public Game(List<string> C, ref Menu M, string Player1Score, string Player2Score)
        {
            InitializeComponent();
            mnuMenu = M;
            Configuration = C;
            tblPlayer1Score.Text = Player1Score;
            tblPlayer2Score.Text = Player2Score;
            tblPlayer1Name.Text = Configuration[6];
            tblPlayer2Name.Text = Configuration[7];


            for (int Rows = 0; Rows < Int32.Parse(Configuration[0]); Rows++)
            {
                List<int> lstTemp = new List<int>();
                for (int Columns = 0; Columns < Int32.Parse(Configuration[1]); Columns++)
                {
                    lstTemp.Add(0);
                }
                Board.Add(lstTemp);
            }


            //Create grid on screen
            btnimgNought.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/Nought_" + Configuration[4] + ".png")));

            for (int col = 0; col < Int32.Parse(Configuration[1]); col++)
            {
                grdBoard.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int row = 0; row < Int32.Parse(Configuration[0]); row++)
            {
                grdBoard.RowDefinitions.Add(new RowDefinition());
            }


            //Place In Black board

            for (int Rows = 0; Rows < Int32.Parse(Configuration[0]); Rows++)
            {
                for (int Columns = 0; Columns < Int32.Parse(Configuration[1]); Columns++)
                {
                    System.Windows.Controls.Image imgTemplate = new System.Windows.Controls.Image();
                    imgTemplate.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/NoughtBackground.png"));
                    Grid.SetRow(imgTemplate, Rows);
                    Grid.SetColumn(imgTemplate, Columns);
                    grdBoard.Children.Add(imgTemplate);
                }
            }
        } //The constructor for game restart
        bool GameState() //Returns false if the game can continue returns true if an end has been reached
        {
            if (BoardIsFull())
            {
                MessageBox.Show("Full Board");
                return true;
            }
            for (int col = 0; col < Int32.Parse(Configuration[1]) - 3; col++)//Loop through the grid and seperate into grids of 4x4 called Current4By4
            {
                for (int row = 0; row < Int32.Parse(Configuration[0]) - 3; row++)//Create the 4x4
                {
                    List<List<int>> Current4By4 = new List<List<int>>();
                    for (int row4x4 = 0; row4x4 < 4; row4x4++)//Cretae 4x4 from larger board
                    {
                        List<int> lstTemp = new List<int>();
                        for (int col4x4 = 0; col4x4 < 4; col4x4++)
                        {
                            lstTemp.Add(Board.ElementAt(row + row4x4)[col + col4x4]);
                        }
                        Current4By4.Add(lstTemp);
                    }

                    //Check the 4x4
                    {
                        for (int col4By4 = 0; col4By4 < 4; col4By4++)//Check columns in 4x4
                        {
                            int ColSize = 0;
                            for (int row4By4 = 0; row4By4 < 4; row4By4++)
                            {
                                ColSize += Current4By4.ElementAt(row4By4)[col4By4];
                            }
                            if (ColSize == 40)
                            {
                                EndGame(1);
                                return true;
                            }
                            if (ColSize == 4)
                            {
                                EndGame(2);
                                return true;
                            }
                        }//Check columns

                        for (int row4By4 = 0; row4By4 < 4; row4By4++)//Check rows in 4x4
                        {
                            int RowSize = 0;
                            for (int col4By4 = 0; col4By4 < 4; col4By4++)
                            {
                                RowSize += Current4By4.ElementAt(row4By4)[col4By4];
                            }
                            if (RowSize == 40)
                            {
                                EndGame(1);
                                return true;
                            }
                            if (RowSize == 4)
                            {
                                EndGame(2);
                                return true;
                            }
                        }//Check rows

                        {

                            int DiagonalSize = 0;
                            for (int ind4By4 = 0; ind4By4 < 4; ind4By4++)//Check Diagonals in 4x4
                            {
                                DiagonalSize += Current4By4.ElementAt(ind4By4)[ind4By4];
                            }
                            if (DiagonalSize == 40)
                            {
                                EndGame(1);
                                return true;
                            }
                            if (DiagonalSize == 4)
                            {
                                EndGame(2);
                                return true;
                            }
                            DiagonalSize = 0;

                            for (int ind4By4 = 0; ind4By4 < 4; ind4By4++)
                            {
                                DiagonalSize += Current4By4.ElementAt(ind4By4)[3 - ind4By4];
                            }
                            if (DiagonalSize == 40)
                            {
                                EndGame(1);
                                return true;
                            }
                            if (DiagonalSize == 4)
                            {
                                EndGame(2);
                                return true;
                            }
                        }//Check Diagonals
                    }


                }
            }
            return false;
        }

        bool BoardIsFull() //Check if board is full
        {
            for(int col = 0; col < Int32.Parse(Configuration[1]); col++)//Loop through the grid and seperate into grids of 3x3 called Current3By3
            {
                for(int row = 0; row < Int32.Parse(Configuration[0]); row++)
                {
                    if (Board.ElementAt(row)[col] == 0)
                    {
                        return false;
                    }
                }                
            }
            return true;
        }
        void EndGame(int Winner)
        {
            if(Winner == 1)
            {
                var window = (MainWindow)Application.Current.MainWindow;
                window.Player1Score.Text = (Int32.Parse(tblPlayer1Score.Text) + 1).ToString();
                tblPlayer1Score.Text = (Int32.Parse(tblPlayer1Score.Text) + 1).ToString();
                DrawLine(new int[] { 0, 3, 0, 3 });
            }
            else if(Winner == 2)
            {
                var window = (MainWindow)Application.Current.MainWindow;
                window.Player2Score.Text = (Int32.Parse(tblPlayer2Score.Text) + 1).ToString();
                tblPlayer2Score.Text = (Int32.Parse(tblPlayer2Score.Text) + 1).ToString();
                DrawLine(new int[] { 0, 3, 0, 3 });
            }
        }        
        int MiniMax(List<List<int>> tempBoard, int depth, bool isMaximiser) //AI Code  //IsMaximiser == true for ai //depth = 0 at a leaf node
        {
            if(depth == 0)
            {
                //GetBestMove out of the 7 options for the maxer or minimer
                return BoardValue(PlaceCounter((isMaximiser ? 1 : 2),5,false,tempBoard),  isMaximiser) ;
            }
            if(isMaximiser)
            {
                int maxevaluation = int.MinValue;
                for(int boardindex = 0; boardindex < 7; boardindex++)
                {
                    Max(ref maxevaluation, MiniMax(PlaceCounter((isMaximiser ? 1 : 2), boardindex, false, tempBoard), depth - 1, !isMaximiser));
                }
                return maxevaluation;
            }
            else  //Minimiser
            {
                int minevaluation = int.MaxValue;
                for(int boardindex = 0; boardindex < 7; boardindex++)
                {
                    Min(ref minevaluation, MiniMax(PlaceCounter((isMaximiser ? 1 : 2), boardindex, false, tempBoard), depth - 1, !isMaximiser));
                }
                return minevaluation;
            }
        }
        List<List<int>> PlaceCounter(int Player, int Position, bool Animate, List<List<int>> tempBoard)
        {
            int Row = 0;

            if (!Animate)
            {
                for (int index = Int32.Parse(Configuration[0]) - 1; index >= 0; index--) //Finds the available space in the board
                {
                    if (Board.ElementAt(index)[Position] == 0)
                    {
                        Row = index;
                        break;
                    }
                }
                if(Player == 1)
                {
                    tempBoard[Row][Position] = 1;
                }
                else
                {
                    tempBoard[Row][Position] = 10;
                }
                return tempBoard;

            }
            else
            {

                for (int index = Int32.Parse(Configuration[0]) - 1; index >= 0; index--) //Finds the available space in the board
                {
                    if (Board.ElementAt(index)[Position] == 0)
                    {
                        Row = index;
                        break;
                    }
                }

                System.Windows.Controls.Image imgCounter = new System.Windows.Controls.Image();
                imgCounter.Width = 46;
                imgCounter.Height = 46;
                imgCounter.Name = "imgCounter" + counterNumber.ToString();
                //Select the counter colour/type
                if (PlayerGo == 1)
                {
                    imgCounter.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Nought_" + Configuration[4] + ".png"));
                    Board.ElementAt(Row)[Position] = 10;
                }
                if (PlayerGo == 2 && !AIPlayer)
                {

                    imgCounter.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Nought_" + Configuration[5] + ".png"));
                    Board.ElementAt(Row)[Position] = 1;

                }
                if (PlayerGo == 2 && AIPlayer)
                {
                    imgCounter.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Nought_" + Configuration[5] + ".png"));

                }

                //Animate the counter down to the level

                grdBoard.Children.Add(imgCounter);
                Grid.SetColumn(imgCounter, Position);
                Grid.SetRow(imgCounter, Row);
                imgCounter.VerticalAlignment = VerticalAlignment.Center;
                var Margin = imgCounter.Margin;
                Margin.Top = 0 - 50 * Row; //Rows from top * row height
                Margin.Bottom = -Margin.Top;
                imgCounter.Margin = Margin;
                //Animate to the position (Drop down)

                var timer = new DispatcherTimer();
                bool HasStopped = false;
                timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
                timer.Tick += DropCounter;
                timer.Start();

                void DropCounter(object sender, EventArgs e)
                {
                    var tick = -20;
                    if (imgCounter.Margin.Top < (6 - Row) * 25 - (6 - Row) * 27 && !HasStopped)//
                    {
                        var preImage = imgCounter.Margin;
                        preImage.Top -= tick;
                        preImage.Bottom += tick;
                        imgCounter.Margin = preImage;
                    }
                    else
                    {
                        var preImage = imgCounter.Margin;
                        preImage.Top = 0;
                        preImage.Bottom = 0;
                        imgCounter.Margin = preImage;
                        HasStopped = true;
                    }
                }
            }
            return new List<List<int>>();
        }
        void Max(ref int no1, int no2)
        {
            if(no1 > no2)
            {
                no1 = no2;
            }
        }
        void Min(ref int no1, int no2)
        {
            if(no1 < no2)
            {
                no1 = no2;
            }
        }
        private void bdrimgNought_MouseMove(object sender, MouseEventArgs e)
        {

            System.Windows.Point position = e.GetPosition(this);
            if (Double.Parse((position.X / 70 - 1.5).ToString()) > 1.52 && Double.Parse((position.X/ 70 - 1.5).ToString()) <7.48)
            {
                var imagemoved = btnimgNought.Margin;
                imagemoved.Left = position.X - bdrimgNought.Margin.Left;
                imagemoved.Right = -position.X + bdrimgNought.Margin.Right;
                imagemoved.Left = position.X / 1.4 - 300;
                imagemoved.Right = -position.X / 1.4 + 300;

                PositionOfCounter = Int32.Parse((position.X / 70 - 1.5).ToString().Substring(0, 1)) - 1;
                btnimgNought.Margin = imagemoved;
            }     
        } //Change x coordinates of the Counter in Top Grid to follow mouse pointer
        private void DoNothing(object sender, MouseEventArgs e) { }
        private async void btnimgNought_Click(object sender, RoutedEventArgs e)
        {
            if (Board.ElementAt(0)[grdBoard.ColumnDefinitions.Count - 1] != 0 || GameState()) //ensures that no counters placed when full
            {
                btnimgNought.IsEnabled = false;
                btnimgNought.MouseMove += DoNothing;                
                return;
            }               

            if(AIPlayer)
            {
                PlaceCounter(1, PositionOfCounter, true, Board);  //Have players go

                //Have AI go
                List<List<List<int>>> ListOfPossibleGoes = new List<List<List<int>>>();
                for(int index = 0; index < grdBoard.RowDefinitions.Count; index++)
                {
                    ListOfPossibleGoes.Add(PlaceCounter(2, index, false, Board.FindAll(x => true)));
                }
                 
                await PutTaskDelay(2000);

                int Value = MiniMax(Board, 2, true);
                for(int listindex = 0; listindex < ListOfPossibleGoes.Count; listindex++)
                {
                    if(Value == BoardValue(ListOfPossibleGoes.ElementAt(listindex),true))
                    {
                        PositionOfCounter = listindex;
                    }
                }
                btnimgNought.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/Nought_" + Configuration[5] + ".png")));
                PlaceCounter(2, PositionOfCounter, true, Board);
            }
            else
            {
                PlaceCounter(PlayerGo, PositionOfCounter, true, Board) ;

                if (PlayerGo == 1) { PlayerGo++; }
                else { PlayerGo--; }

                if (PlayerGo == 1)
                {
                    btnimgNought.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/Nought_" + Configuration[4] + ".png")));
                }
                if (PlayerGo == 2)
                {
                    btnimgNought.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/Nought_" + Configuration[5] + ".png")));
                }
            }
            


            
        }     
        private int BoardValue(List<List<int>> tempBoard, bool isMaximiser)
        {
            int Value = 0;
            int bignumber = 100000000;
            //Check for wins == +-10000
            for (int col = 0; col < Int32.Parse(Configuration[1]) - 3; col++)//Loop through the grid and seperate into grids of 4x4 called Current4By4
            {
                for (int row = 0; row < Int32.Parse(Configuration[0]) - 3; row++)//Create the 4x4
                {
                    List<List<int>> Current4By4 = new List<List<int>>();
                    for (int row4x4 = 0; row4x4 < 4; row4x4++)//Cretae 4x4 from larger board
                    {
                        List<int> lstTemp = new List<int>();
                        for (int col4x4 = 0; col4x4 < 4; col4x4++)
                        {
                            lstTemp.Add(Board.ElementAt(row + row4x4)[col + col4x4]);
                        }
                        Current4By4.Add(lstTemp);
                    }

                    //Check the 4x4
                    {
                        for (int col4By4 = 0; col4By4 < 4; col4By4++)//Check columns in 4x4
                        {
                            int ColSize = 0;
                            for (int row4By4 = 0; row4By4 < 4; row4By4++)
                            {
                                ColSize += Current4By4.ElementAt(row4By4)[col4By4];
                            }
                            if (ColSize == 40)
                            {
                                Value += bignumber;
                            }
                            if (ColSize == 4)
                            {
                                Value -= bignumber;
                            }
                        }//Check columns

                        for (int row4By4 = 0; row4By4 < 4; row4By4++)//Check rows in 4x4
                        {
                            int RowSize = 0;
                            for (int col4By4 = 0; col4By4 < 4; col4By4++)
                            {
                                RowSize += Current4By4.ElementAt(row4By4)[col4By4];
                            }
                            if (RowSize == 40)
                            {
                                Value += bignumber;
                            }
                            if (RowSize == 4)
                            {
                                Value -= bignumber;                            }
                        }//Check rows

                        {

                            int DiagonalSize = 0;
                            for (int ind4By4 = 0; ind4By4 < 4; ind4By4++)//Check Diagonals in 4x4
                            {
                                DiagonalSize += Current4By4.ElementAt(ind4By4)[ind4By4];
                            }
                            if (DiagonalSize == 40)
                            {
                                Value += bignumber;
                            }
                            if (DiagonalSize == 4)
                            {
                                Value -= bignumber;
                            }
                            DiagonalSize = 0;

                            for (int ind4By4 = 0; ind4By4 < 4; ind4By4++)
                            {
                                DiagonalSize += Current4By4.ElementAt(ind4By4)[3 - ind4By4];
                            }
                            if (DiagonalSize == 40)
                            {
                                Value += bignumber;
                            }
                            if (DiagonalSize == 4)
                            {
                                Value -= bignumber;
                            }
                        }//Check Diagonals
                    }


                }
            }

            //Check for rows/columns/diagonals of 3 and give 5 points
            for (int col = 0; col < Int32.Parse(Configuration[1]) - 2; col++)//Loop through the grid and seperate into grids of 3x3 called Current3By3
            {
                for (int row = 0; row < Int32.Parse(Configuration[0]) - 2; row++)//Create the 3x3
                {
                    List<List<int>> Current3By3 = new List<List<int>>();
                    for (int row3x3 = 0; row3x3 < 3; row3x3++)//Cretae 3x3 from larger board
                    {
                        List<int> lstTemp = new List<int>();
                        for (int col3x3 = 0; col3x3 < 3; col3x3++)
                        {
                            lstTemp.Add(Board.ElementAt(row + row3x3)[col + col3x3]);
                        }
                        Current3By3.Add(lstTemp);
                    }

                    //Check the 3x3
                    {
                        for (int col3By3 = 0; col3By3 < 3; col3By3++)//Check columns in 3x3
                        {
                            int ColSize = 0;
                            for (int row3By3 = 0; row3By3 < 3; row3By3++)
                            {
                                ColSize += Current3By3.ElementAt(row3By3)[col3By3];
                            }
                            if (ColSize == 30)
                            {
                                Value+= 5;
                            }
                            if (ColSize == 3)
                            {
                                Value += -5;
                            }
                        }//Check columns

                        for (int row3By3 = 0; row3By3 < 3; row3By3++)//Check rows in 3x3
                        {
                            int RowSize = 0;
                            for (int col3By3 = 0; col3By3 < 3; col3By3++)
                            {
                                RowSize += Current3By3.ElementAt(row3By3)[col3By3];
                            }
                            if (RowSize == 30)
                            {
                                Value += 5;
                            }
                            if (RowSize == 3)
                            {
                                Value += -5;
                            }
                        }//Check rows

                        {

                            int DiagonalSize = 0;
                            for (int ind3By3 = 0; ind3By3 < 3; ind3By3++)//Check Diagonals in 3x3
                            {
                                DiagonalSize += Current3By3.ElementAt(ind3By3)[ind3By3];
                            }
                            if (DiagonalSize == 30)
                            {
                                Value += 5;
                            }
                            if (DiagonalSize == 3)
                            {
                                Value += -5;
                            }
                            DiagonalSize = 0;

                            for (int ind3By3 = 0; ind3By3 < 3; ind3By3++)
                            {
                                DiagonalSize += Current3By3.ElementAt(ind3By3)[2 - ind3By3];
                            }
                            if (DiagonalSize == 30)
                            {
                                Value += 5;
                            }
                            if (DiagonalSize == 3)
                            {
                                Value += -5;
                            }
                        }//Check Diagonals
                    }


                }
            }

            //Check for rows/columns/diagonals of 2 and give 3 points
            for (int col = 0; col < Int32.Parse(Configuration[1]) - 1; col++)//Loop through the grid and seperate into grids of 2x2 called Current3By3
            {
                for (int row = 0; row < Int32.Parse(Configuration[0]) - 1; row++)//Create the 3x3
                {
                    List<List<int>> Current2By2 = new List<List<int>>();
                    for (int row2x2 = 0; row2x2 < 2; row2x2++)//Cretae 3x3 from larger board
                    {
                        List<int> lstTemp = new List<int>();
                        for (int col2x2 = 0; col2x2 < 2; col2x2++)
                        {
                            lstTemp.Add(Board.ElementAt(row + row2x2)[col + col2x2]);
                        }
                        Current2By2.Add(lstTemp);
                    }

                    //Check the 2x2
                    {
                        for (int col2By2 = 0; col2By2 < 2; col2By2++)//Check columns in 2x2
                        {
                            int ColSize = 0;
                            for (int row2By2 = 0; row2By2 < 2; row2By2++)
                            {
                                ColSize += Current2By2.ElementAt(row2By2)[col2By2];
                            }
                            if (ColSize == 20)
                            {
                                Value += 3;
                            }
                            if (ColSize == 2)
                            {
                                Value += -3;
                            }
                        }//Check columns

                        for (int row2By2 = 0; row2By2 < 2; row2By2++)//Check rows in 2x2
                        {
                            int RowSize = 0;
                            for (int col2By2 = 0; col2By2 < 2; col2By2++)
                            {
                                RowSize += Current2By2.ElementAt(row2By2)[col2By2];
                            }
                            if (RowSize == 20)
                            {
                                Value += 3;
                            }
                            if (RowSize == 2)
                            {
                                Value += -3;
                            }
                        }//Check rows

                        {

                            int DiagonalSize = 0;
                            for (int ind2By2 = 0; ind2By2 < 2; ind2By2++)//Check Diagonals in 2x2
                            {
                                DiagonalSize += Current2By2.ElementAt(ind2By2)[ind2By2];
                            }
                            if (DiagonalSize == 20)
                            {
                                Value += 3;
                            }
                            if (DiagonalSize == 2)
                            {
                                Value += -3;
                            }
                            DiagonalSize = 0;

                            for (int ind2By2 = 0; ind2By2 < 2; ind2By2++)
                            {
                                DiagonalSize += Current2By2.ElementAt(ind2By2)[1 - ind2By2];
                            }
                            if (DiagonalSize == 20)
                            {
                                Value += 3;
                            }
                            if (DiagonalSize == 2)
                            {
                                Value += -3;
                            }
                        }//Check Diagonals
                    }


                }
            }

            return -Value;
        }
        private void DrawLine(int[] input)
        {
            double Width = grdBoard.ActualWidth / Convert.ToDouble(grdBoard.ColumnDefinitions.Count);
            double Height = grdBoard.ActualHeight / Convert.ToDouble(grdBoard.RowDefinitions.Count);

            var line = new Line();
            line.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0000,225,0000,0000));

            line.X1 = input[0] * Width;
            line.X2 = input[2] * Width;
            line.Y1 = input[1] * Height;
            line.Y2 = input[3] * Height;
            line.StrokeThickness = 10;

            //Grid.SetColumnSpan(line, 100);
            //Grid.SetRowSpan(line, 100);
            grdBoard.Children.Add(line);
        }

        async Task PutTaskDelay( int milliseconds )
        {
            await Task.Delay(milliseconds);
        }

    }
}











