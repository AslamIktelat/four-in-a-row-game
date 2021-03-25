using Client.GameServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
      
        public GameWindow(ServiceClient client, ClientCallback callback, string username,string gameId,bool myturn)
        {
            InitializeComponent();
            CloseGame = false;
            Client = client;
            Callback = callback;
            Username = username;
            GameId = gameId;
            /* assign to delegates */
            callback.AddMove =AddCircle;
            callback.OnOffCan = MyTurn;
            callback.EndLostGame = Lost;
            callback.EndDrawGame = Draw;
            callback.callbackEndGameOtherPlayerQuit = EndGameOtherPlayerQuit;
            /* CountMyMoves to know how many balls this player has in each column */
            CountMyMoves = new int[6];
            for (int i = 0; i < 6; i++)
                CountMyMoves[i] = 0;
            /* cols to know how many balls for the two players in each  column*/
            cols = new Dictionary<string, int>();
            cols.Add("c1", 0);
            cols.Add("c2", 0);
            cols.Add("c3", 0);
            cols.Add("c4", 0);
            cols.Add("c5", 0);
            cols.Add("c6", 0);
            /* colsCanvs to konw to which canvs to add a ball */
            colsCanvs = new Dictionary<string, Canvas>();
            colsCanvs.Add("c1", c1);
            colsCanvs.Add("c2", c2);
            colsCanvs.Add("c3", c3);
            colsCanvs.Add("c4", c4);
            colsCanvs.Add("c5", c5);
            colsCanvs.Add("c6", c6);
            /* int matrix of the game board , we add to to matrix only the moves of this player */
            GameBoard = new int[6,7];
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 7; j++)
                    GameBoard[i, j] = 0;
            MyTurn(myturn);//call the function MyTurn
             thr = new Thread(ServiceClientAlive);///catch here not in the thread
            try
            {
                thr.Start();
            }
            catch (TimeoutException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response this game is canceled", Username + " connection unstable");
                    thr.Abort();
                    CloseGame = true;
                    this.Close();
            }
            catch (CommunicationObjectFaultedException)
            {
                MessageBox.Show(" connection failed , this game is canceled", Username + " connection unstable");
                thr.Abort();
                CloseGame = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Username);
                thr.Abort();
                CloseGame = true;
                this.Close();
            }
        }
         string Username { get; set; }
        int[,] GameBoard;
        int[] CountMyMoves;
        string GameId;
        ServiceClient Client;
        ClientCallback Callback;
        Dictionary<string, int> cols;
        Dictionary<string, Canvas> colsCanvs;
        bool CloseGame;
        Thread thr;


        private void ServiceClientAlive()
        {
          //  try
           // {
                while (Client.Ping())
                {
                //sleep
                this.Dispatcher.Invoke(() =>
                {
                    ConnIndicator.Fill = System.Windows.Media.Brushes.Green;
                });
               
                    Thread.Sleep(5000);///5 sec
                this.Dispatcher.Invoke(() =>
                {
                    ConnIndicator.Fill = System.Windows.Media.Brushes.Orange;
                });
                Thread.Sleep(500);
            }

  
        }

       /* this function get call from this player or from a callback function */
        private void Draw()
        {
            MessageBox.Show("Game Over with draw, you gained " + GameOver(false) + " points",Username);
            this.Close();
        }

        /* callback function call this function */
        private void Lost()
        {
            MessageBox.Show("you lost, you gained " + GameOver(false) + " points",Username);
            this.Close();
        }
        /*we call this function to end the game if one of the players won or if the board is full and the game ended with draw*/
        /* if the player call this function with flag =true then he/she is the winner */
        /* else he/she is loser or if game is ended with draw the two players call this function with flag=false*/
        private int GameOver(bool falg)
        {
            int p = 0;
            try
            {
                CloseGame = true;
                int c = 0;
                bool b = true;
                //the 100 bouns 
                for (int i = 0; i < 6; i++)
                {
                    c = c + CountMyMoves[i];
                    if (CountMyMoves[i] == 0) b = false;
                }
                if (b) p = 100;
                if (!falg)//if not winner he/she get 10 points for each ball she/he added to the board
                {
                    p = c * 10 + p;
                }
                if (falg)
                {
                    p = p + 1000;
                }
               
                Client.MyPoints(Username, GameId, p);
                if (falg)
                {
                    MessageBox.Show("YOU WIN, you gained " + p + " points", Username);
                    this.Close();
                }

                
            }
            catch (FaultException<LiveGameFault> fault)
            {
                thr.Abort();
                MessageBox.Show(fault.Detail.Details, Username);
                CloseGame = true;
                this.Close();
            }
            catch (TimeoutException)
            {
                thr.Abort();
                MessageBox.Show(" connection unstable , it took to long to get a response this game is canceled",Username + " connection unstable");
                CloseGame = true;
                this.Close();

            }
            catch (CommunicationObjectFaultedException)
            {
                thr.Abort();
                MessageBox.Show(" connection failed , this game is canceled", Username + " connection unstable");
                CloseGame = true;
                this.Close();

            }
            catch (Exception ex)
            {
                thr.Abort();
                MessageBox.Show(ex.ToString(),Username + " connection unstable");
                CloseGame = true;
                this.Close();

            }
            return p;
        }
        /* this function turn on/off the canvass*/
        private void MyTurn(bool flag)
        {
            if (flag)
                TBTurn.Text = "Your turn";
            else
                TBTurn.Text = "Other player turn";
            c1.IsEnabled = flag;
            c2.IsEnabled = flag;
            c3.IsEnabled = flag;
            c4.IsEnabled = flag;
            c5.IsEnabled = flag;
            c6.IsEnabled = flag;
        }

        /*c1-c6 when the player click on canvas */
        /* if the column not full we add to column counter add we call the function AddCircle*/
        private void C1(object sender, MouseButtonEventArgs e)
        {    if(cols["c1"]<7)
            {
                TBWrongMove.Text = "";
                CountMyMoves[0]++; 
                AddCircle("c1");
            }
           else
            {
                TBWrongMove.Text = "The column is full";
            }
        }
        private void C2(object sender, MouseButtonEventArgs e)
        {
           
            if (cols["c2"] < 7)
            {
                TBWrongMove.Text = "";
                CountMyMoves[1]++;
                AddCircle("c2");
            }
            else
            {
                TBWrongMove.Text = "The column is full";
            }
        }
        private void C3(object sender, MouseButtonEventArgs e)
        {
            if (cols["c3"] < 7)
            {
                TBWrongMove.Text = "";
                CountMyMoves[2]++;
                AddCircle("c3");
            }
            else
            {
                TBWrongMove.Text = "The column is full";
            }
        }
        private void C4(object sender, MouseButtonEventArgs e)
        {

            if (cols["c4"] < 7)
            {
                TBWrongMove.Text = "";
                CountMyMoves[3]++;
                AddCircle("c4");
            }
            else
            {
                TBWrongMove.Text = "The column is full";
            }
        }
        private void C5(object sender, MouseButtonEventArgs e)
        {
            if (cols["c5"] < 7)
            {
                TBWrongMove.Text = "";
                CountMyMoves[4]++;
                AddCircle("c5");
            }
            else
            {
                TBWrongMove.Text = "The column is full";
            }
        }
        private void C6(object sender, MouseButtonEventArgs e)
        {
            if (cols["c6"] < 7)
            {
                TBWrongMove.Text = "";
                CountMyMoves[5]++;
                AddCircle("c6");
            }
            else
            {
                TBWrongMove.Text = "The column is full";
            }
        }

        /* this function get calls from the this player with  myMove=true*/
        /* also get calls from a callback function with  myMove=false*/
        private void AddCircle(string c,bool myMove=true)
        {
           
            Ellipse el;
            bool win = false;
            if (myMove)//if this player calls this function
            {             
                MyTurn(false);//turn off the canvass
                win = AddMyMoveToOnlineBoard(c);//call the function AddMyMoveToOnlineBoard and if it returns true then this player won
                el = new Ellipse
                {
                    Height = 40,
                    Width = 40,
                    Fill = System.Windows.Media.Brushes.Green//my circle
                }; 
            }
            else
            {
                el = new Ellipse
                {
                    Height = 40,
                    Width = 40,
                    Fill = System.Windows.Media.Brushes.Red// other player circle
                };
               
            }
            //Display the circle on the board
            Canvas.SetLeft(el, 25);
            colsCanvs[c].Children.Add(el);
            Thread newThread = new Thread(delegate ()
            {
                DisplayCircle(el, c);
            });
            newThread.Start();
            //if this player won the game call GameOver
            if (win)
                GameOver(true);
            else
            {
                if (Username==GameId)//if true then this player who sent the invitaion so he/she who start playing then he/she who play the last move
                {
                    //check if draw by counting how many times this player played
                    int cc = 0;
                    for (int i = 0; i < 6; i++) cc = cc + CountMyMoves[i];
                    if (cc == 21)
                        Draw();//call the function Draw
                }
            }
        }

        private void DisplayCircle(Ellipse obj,string c)
        {
            Ellipse el = obj as Ellipse;
            int FH = 395-cols[c]*65;
            int CH = 0;
            int add = FH / 5;
            cols[c]++;

            for (CH = 0; CH <= FH; CH = CH + add)                          
            {
                c1.Dispatcher.Invoke(() =>
                {
                    el.Visibility = Visibility.Visible;
                });
                Thread.Sleep(50);
                c1.Dispatcher.Invoke(() =>
                {
                    el.Visibility = Visibility.Hidden;
                });
                Dispatcher.Invoke(() =>
                {
                    Canvas.SetTop(el,CH);
                    
                });
                Thread.Sleep(50);
            }
            c1.Dispatcher.Invoke(() =>
            {
                el.Visibility = Visibility.Visible;
            });
        }

        private bool AddMyMoveToOnlineBoard(string c)
        {
           /*add 1 to the matrix*/
            if(c=="c1")
            {
                GameBoard[0, cols[c]] = 1;
               
            }
            if (c == "c2")
            {
                GameBoard[1, cols[c]] = 1;
               
            }
            if (c == "c3")
            {
                GameBoard[2, cols[c]] = 1;
               
            }
            if (c == "c4")
            {
                GameBoard[3, cols[c]] = 1;
               
            }
            if (c == "c5")
            {
                GameBoard[4, cols[c]] = 1;
               
            }
            if (c == "c6")
            {
                GameBoard[5, cols[c]] = 1;
               
            }
            /*check if the this player won */
            /*if yes then call AddMyMoveToBoard IHaveFour=true and return true*/
            try
            {
                int count = 0;
                //col
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (GameBoard[i, j] == 1) count++;
                        else count = 0;
                        if (count == 4) { Client.AddMyMoveToBoard(Username, GameId, c, true); return true; }
                    }
                    count = 0;
                }

                //row
                count = 0;
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (GameBoard[j, i] == 1) count++;
                        else count = 0;
                        if (count == 4) { Client.AddMyMoveToBoard(Username, GameId, c, true); return true; }
                    }
                    count = 0;
                }

                count = 0;
                for (int i = 0; i < 6; i++)
                {
                    if (GameBoard[i, i] == 1) count++;
                    else count = 0;
                    if (count == 4) { Client.AddMyMoveToBoard(Username, GameId, c, true); return true; }
                }

                count = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (GameBoard[i + 1, i] == 1) count++;
                    else count = 0;
                    if (count == 4) {  Client.AddMyMoveToBoard(Username, GameId, c, true); return true; }
                }

                count = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (GameBoard[i + 2, i] == 1) count++;
                    else count = 0;
                    if (count == 4) { Client.AddMyMoveToBoard(Username, GameId, c, true); return true; }
                }

                count = 0;
                for (int i = 0; i < 6; i++)
                {
                    if (GameBoard[i, i + 1] == 1) count++;
                    else count = 0;
                    if (count == 4) { Client.AddMyMoveToBoard(Username, GameId, c, true); return true; }
                }

                count = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (GameBoard[i, i + 2] == 1) count++;
                    else count = 0;
                    if (count == 4) { Client.AddMyMoveToBoard(Username, GameId, c, true); return true; }
                }

                count = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (GameBoard[i, i + 3] == 1) count++;
                    else count = 0;
                    if (count == 4) { Client.AddMyMoveToBoard(Username, GameId, c, true); return true; }
                }

                count = 0;
                for (int i = 3; i >= 0; i--)
                {
                    if (GameBoard[i, 3 - i] == 1) count++;
                    else count = 0;
                    if (count == 4) { Client.AddMyMoveToBoard(Username, GameId, c, true); return true; }
                }

                count = 0;
                for (int i = 4; i >= 0; i--)
                {
                    if (GameBoard[i, 4 - i] == 1) count++;
                    else count = 0;
                    if (count == 4) { Client.AddMyMoveToBoard(Username, GameId, c, true); return true; }
                }

                count = 0;
                for (int i = 5; i >= 0; i--)
                {
                    if (GameBoard[i, 5 - i] == 1) count++;
                    else count = 0;
                    if (count == 4) {  Client.AddMyMoveToBoard(Username, GameId, c, true); return true; }
                }

                count = 0;
                for (int i = 5; i >= 0; i--)
                {
                    if (GameBoard[i, 6 - i] == 1) count++;
                    else count = 0;
                    if (count == 4) { Client.AddMyMoveToBoard(Username, GameId, c, true); return true; }
                }

                count = 0;
                for (int i = 5; i > 0; i--)
                {
                    if (GameBoard[i, 7 - i] == 1) count++;
                    else count = 0;
                    if (count == 4) {  Client.AddMyMoveToBoard(Username, GameId, c, true); return true; }
                }

                count = 0;
                for (int i = 5; i > 1; i--)
                {
                    if (GameBoard[i, 8 - i] == 1) count++;
                    else count = 0;
                    if (count == 4) {  Client.AddMyMoveToBoard(Username, GameId, c, true); return true; }
                }
                /*else call AddMyMoveToBoard IHaveFour=false and return false*/
               
                Client.AddMyMoveToBoard(Username, GameId, c, false);
            }
            catch (FaultException<LiveGameFault> fault)
            {
                thr.Abort();
                MessageBox.Show(fault.Detail.Details, Username);
                CloseGame = true;
                this.Close();
            }
            catch (TimeoutException)
            {
                thr.Abort();
                MessageBox.Show(" connection unstable , it took to long to get a response this game is canceled",Username + " connection unstable");
                CloseGame = true;
                this.Close();

            }
            catch (CommunicationObjectFaultedException)
            {
                thr.Abort();
                MessageBox.Show(" connection failed , this game is canceled", Username + " connection unstable");
                CloseGame = true;
                this.Close();

            }
            catch (Exception ex)
            {
                thr.Abort();
                MessageBox.Show(ex.ToString(), Username);
                CloseGame = true;
                this.Close();

            }
            return false;
          
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
            thr.Abort();
            try
            {
                if (CloseGame == false)//the player exit in the middle of the game
                {
                    Client.IQuit(Username, GameId);
                }
            }
            catch (TimeoutException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response this game is canceled", Username + " connection unstable");
            }
            catch (CommunicationObjectFaultedException)
            {
                MessageBox.Show(" connection failed , this game is canceled", Username + " connection unstable");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Username + " connection unstable");
            }
        }

        private void BQuit_Click(object sender, RoutedEventArgs e)
        {
            CloseGame = true;
            thr.Abort();
            try
            {
                //the player exit in the middle of the games
                Client.IQuit(Username, GameId);
                this.Close();
            }
            catch (FaultException<LiveGameFault> fault)
            {
                MessageBox.Show(fault.Detail.Details, Username);
                this.Close();
            }
            catch (TimeoutException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response this game is canceled", Username + " connection unstable");
                this.Close();
            }
            catch (CommunicationObjectFaultedException)
            {
                MessageBox.Show(" connection failed , this game is canceled", Username + " connection unstable");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Username);
                this.Close();
            }
        }

       /*a callback function call this function*/
        private void EndGameOtherPlayerQuit()
        {
                thr.Abort();
                CloseGame = true;
                MessageBox.Show("Other player quit the game, you win",Username);
                this.Close();
        }
        
    }
}
