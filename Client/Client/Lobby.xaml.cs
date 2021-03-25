using Client.GameServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using System.Timers;
using System.Threading;
using System.Windows.Threading;

namespace Client
{
    /// <summary>
    /// Interaction logic for Lobby.xaml
    /// </summary>
    public partial class Lobby : Window
    {
        public Lobby(ServiceClient client, ClientCallback callback, string username)
        {
            online = true;
            try
            {
                InitializeComponent();
                InviteB.Visibility = Visibility.Hidden;
                timer = new DispatcherTimer();
                Client = client;
                Username = username;
                Callback = callback;
                Client = client;
                callback.ReceivedInvitation = ShowReceivedInvitation;//assign to delegate
                client.AddPlayerToLobby(username);//add the player to the wating list
                mainWindow = null;
                ConnIndicator.Fill = System.Windows.Media.Brushes.Green;
                FillLBOnLine();//FillLBOnLine get from the server all the online and available players
               
            }
            catch (FaultException<InvitationFault> fault)
            {
                MessageBox.Show(fault.Detail.Details, Username);
            }
            catch (TimeoutException)
            {
                timer.Stop();
                ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                online = false;
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username + " connection unstable");
                this.Close();
            }
            catch (CommunicationObjectFaultedException)
            {
                timer.Stop();
                ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                online = false;
                MessageBox.Show(" connection failed , this game is canceled", Username + " connection unstable");
                this.Close();
            }
            catch (Exception ex)
            {
                timer.Stop();
                ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                online = false;
                MessageBox.Show(ex.ToString(), Username + " connection unstable");
                this.Close();
            }
        }
        public ServiceClient Client { get; set; }
        public string Username { get; set; }

        ClientCallback Callback;
        string otherplayer;
        DispatcherTimer timer;//timer to refresh the available users list
        bool online;
        GameWindow mainWindow;


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += delegate { FillLBOnLine(); };
            timer.Start();
        }

        private void FillLBOnLine()
        {
            try
            {
               
                var list = new List<string>(Client.GetWaitingList());//call GetWaitingList() and convert to list
                list.Remove(Username);//remove the user from the list so the player can't invite him self to a game
                LBoxOnLine.ItemsSource = list;
               
            }
            catch (TimeoutException)
            {
                timer.Stop();
                ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                online = false;
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username + " connection unstable");
                this.Close();
            }
            catch (CommunicationObjectFaultedException)
            {
                timer.Stop();
                ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                online = false;
                MessageBox.Show(" connection failed , this game is canceled", Username + " connection unstable");
                this.Close();
            }
            catch (Exception ex)
            {
                timer.Stop();
                ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                online = false;
                MessageBox.Show(ex.ToString(), Username);
                this.Close();
            }
           
        }
    

        private void RefreshB_Click(object sender, RoutedEventArgs e)
        {
            FillLBOnLine();
        }

        /*when the user chosse a player from the list we print its info*/
        private void LBoxOnLine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LBoxOnLine.SelectedIndex == -1)
            {
                InviteB.Visibility = Visibility.Hidden;
                textBlockWon.Text = "";
                textBlockLost.Text = "";
                textBlockPoints.Text = "";
                textBlockPre.Text = "";
                LBGames.ItemsSource = "";
            }
            else
            {
                try
                {
                    InviteB.Visibility = Visibility.Visible;
                    int[] temp;
                    string PName = LBoxOnLine.SelectedItem.ToString();
                    
                    GameInfo[] GI = Client.GetGamesByPlayer(PName);//call the function GetGamesByPlayer
                    LBGames.ItemsSource = from gi in GI select gi.FParticipant + " VS " + gi.SParticipant + " Winner: " + gi.Winner;
                    
                    temp = Client.GetPlayerInfo(PName);////call the function GetPlayerInfo
                    textBlockWon.Text = "Won " + temp[0] + " games";
                    textBlockLost.Text = "Lost " + temp[1] + " games";
                    textBlockPoints.Text = "Points: " + temp[2];
                    if (temp[3] > 0)
                    {
                        double t1 = temp[0], t2 = temp[3];
                        double pre = (t1 / t2) * 100;
                        pre = Math.Round(pre, 2);//pre is a double number with only 2 digits after the dot
                        textBlockPre.Text = pre + "% wins";
                    }
                }
                catch (FaultException<InvitationFault> fault)
                {
                    MessageBox.Show(fault.Detail.Details, Username);
                  
                }
                catch (TimeoutException)
                {
                    timer.Stop();
                    ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                    online = false;
                    MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username + " connection unstable");
                    this.Close();
                }
                catch (CommunicationObjectFaultedException)
                {
                    timer.Stop();
                    ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                    online = false;
                    MessageBox.Show(" connection failed , this game is canceled", Username + " connection unstable");
                    this.Close();
                }
                catch (Exception ex)
                {
                    timer.Stop();
                    ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                    online = false;
                    MessageBox.Show(ex.ToString(), Username);
                    this.Close();
                }


            }
            

        }

        /* when the player get an Invitation a callback function call this function */
        private void ShowReceivedInvitation(string from)
        {
            try
            {
                var result = MessageBox.Show(from + " invited you, press yes to start the game ", "Invitation to " + Username, MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    
                    Client.InvitationAnswer(from, true);//return the answer by the function InvitationAnswer
                    otherplayer = from;
                    StartGame(false);//start a game with the flag false -not my turn-start game and wait to the player to play
                }
                else
                {
                   
                    Client.InvitationAnswer(from, false);
                }
            }
            catch (FaultException<InvitationFault> fault)
            {
                MessageBox.Show(fault.Detail.Details, Username);
            }
            catch (TimeoutException)
            {
                timer.Stop();
                ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                online = false;
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username + " connection unstable");
                this.Close();
            }
            catch (CommunicationObjectFaultedException)
            {
                timer.Stop();
                ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                online = false;
                MessageBox.Show(" connection failed , this game is canceled", Username + " connection unstable");
                this.Close();
            }
            catch (Exception ex)
            {
                timer.Stop();
                ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                online = false;
                MessageBox.Show(ex.ToString(), Username );
                this.Close();
            }

        }

        /*send invite*/
        private void InviteB_Click_1(object sender, RoutedEventArgs e)
        {
            string to = LBoxOnLine.SelectedItem.ToString();
            try
            {
               
                Client.SendInvitation(Username, to);//send invite by the function SendInvitation
                otherplayer = to;
                /* assign to delegate */
                Callback.startGame = StartGame;
                Callback.InvitationDenied = InvitationDenied;
                MessageBox.Show("The invition was sent", Username);
            }
            catch (FaultException<InvitationFault> fault)
            {
                MessageBox.Show(fault.Detail.Details,Username);
            }
            catch (CommunicationObjectFaultedException)
            {
                timer.Stop();
                ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                online = false;
                MessageBox.Show(" connection failed , this game is canceled", Username + " connection unstable");
                this.Close();
            }
            catch (TimeoutException)
            {
                timer.Stop();
                ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                online = false;
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username + " connection unstable");
                this.Close();
            }
            catch (Exception ex)
            {
                timer.Stop();
                ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                online = false;
                MessageBox.Show(ex.ToString(), Username);
                this.Close();
            }


        }
       /* start game */
        private void StartGame(bool myturn)
        {
            /* the id of a live game in the server is the name of the player who sent the invite */
            /* if the player called the function startGame with myturn=true then he/she who sent the invite  and first move in game is his/her*/            
            if(myturn)
                mainWindow = new GameWindow(Client, Callback, Username, Username, myturn);
            else
               mainWindow = new GameWindow(Client, Callback,Username, otherplayer,myturn);
            mainWindow.Title = Username+" VS "+otherplayer;
            timer.Stop();
            mainWindow.ShowDialog();
            timer.Start();
            
        }
        /* if the invitation denied a callback function call this function*/
        private void InvitationDenied()
        {
            MessageBox.Show("your invitation denied",Username);
        }

     

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();
            ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
            if (mainWindow!=null)
                mainWindow.Close();
            try
            {   if(online)
                Client.ClientDisconnect(Username);
            }
            catch (TimeoutException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username + " connection unstable");
            }
            catch (CommunicationObjectFaultedException)
            {
                MessageBox.Show(" connection failed , this game is canceled", Username + " connection unstable");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Username );
            }
        }

        private void ExitB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client.ClientDisconnect(Username);
                this.Close();
            }
            catch (TimeoutException)
            {
                timer.Stop();
                ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                online = false;
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username + " connection unstable");
                this.Close();
            }
            catch (CommunicationObjectFaultedException)
            {
                timer.Stop();
                ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                online = false;
                MessageBox.Show(" connection failed , this game is canceled", Username + " connection unstable");
                this.Close();
            }
            catch (Exception ex)
            {
                timer.Stop();
                ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                online = false;
                MessageBox.Show(ex.ToString(), Username );
                this.Close();
            }
        }

        /*back to dashboard*/
        private void BTDB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client.ClientDisconnect(Username);//remove player from wating list
                ClientCallback callback1 = new ClientCallback();
                ServiceClient client1 = new ServiceClient(new InstanceContext(callback1));

                Dashboard mainWindow = new Dashboard(client1, callback1, Username);
                mainWindow.Title = Username;
                this.Close();
                mainWindow.Show();
            }
            catch (TimeoutException)
            {
                timer.Stop();
                ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                online = false;
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username + " connection unstable");
                this.Close();
            }
            catch (CommunicationObjectFaultedException)
            {
                timer.Stop();
                ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                online = false;
                MessageBox.Show(" connection failed , this game is canceled", Username + " connection unstable");
                this.Close();
            }
            catch (Exception ex)
            {
                timer.Stop();
                ConnIndicator.Fill = System.Windows.Media.Brushes.Red;
                online = false;
                MessageBox.Show(ex.ToString(), Username );
                this.Close();
            }
        }
        
    }
}
