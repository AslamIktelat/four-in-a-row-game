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

namespace Client
{
    /// <summary>
    /// Interaction logic for ShowPlayers.xaml
    /// </summary>
    public partial class ShowPlayers : Window
    {
        public ShowPlayers(ServiceClient client, string username)
        {
            InitializeComponent();
            Client = client;
            Username = username;
            try
            {
               
                Players = Client.GetUsers();//call the function GetUsers to get all the users
                if (Players.Count > 0)
                {
                    var IS = from p in Players
                             select p.Key + ",    Points: " + p.Value["Points"] + "   Games: " + p.Value["GamesCounter"]
                             + "   Wins: " + p.Value["WonCounter"] + "   Losses: " + p.Value["Losses"];
                    LBox1.ItemsSource = IS;
                    LBox2.ItemsSource = IS;
                }

                else
                {
                    LBox1.Items.Clear();
                    LBox2.Items.Clear();
                    LBox1.Items.Add("Players table empty");
                    LBox2.Items.Add("Players table empty");
                }
            }
            catch (TimeoutException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", username+" connection unstable");
                this.Close();
            }
            catch (CommunicationObjectFaultedException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", username + " connection unstable");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Username);
                this.Close();
            }



        }

        public ServiceClient Client { get;  set; }
        public string Username { get;  set; }
        private Dictionary<string,Dictionary<string,int>> Players { get; set; }

        /* The order by functions*/
        /* at the beging of each function we call the function  Client.GetUsers() to refresh the list if new user singed up*/
        private void ByName(object sender, RoutedEventArgs e)
        {
            try
            {
               
                Players = Client.GetUsers();
                if (Players.Count > 0)
                {
                    var IS = from p in Players
                             orderby p.Key ascending
                             select p.Key + ",    Points: " + p.Value["Points"] + "   Games: " + p.Value["GamesCounter"]
                                         + "   Wins: " + p.Value["WonCounter"] + "   Losses: " + p.Value["Losses"];
                    LBox1.ItemsSource = IS;
                    LBox2.ItemsSource = IS;
                }
                else
                {
                    LBox1.Items.Clear();
                    LBox2.Items.Clear();
                    LBox1.Items.Add("Players table empty");
                    LBox2.Items.Add("Players table empty");
                }
            }
            catch (TimeoutException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username + " connection unstable");
                this.Close();
            }
            catch (CommunicationObjectFaultedException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username + " connection unstable");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Username);
                this.Close();
            }


        }

        private void ByPoints(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Players = Client.GetUsers();
                if (Players.Count > 0)
                {
                    var IS = from p in Players
                             orderby p.Value["Points"] descending
                             select p.Key + ",    Points: " + p.Value["Points"] + "   Games: " + p.Value["GamesCounter"]
                      + "   Wins: " + p.Value["WonCounter"] + "   Losses: " + p.Value["Losses"];
                    LBox1.ItemsSource = IS;
                    LBox2.ItemsSource = IS;
                }
                else
                {
                    LBox1.Items.Clear();
                    LBox2.Items.Clear();
                    LBox1.Items.Add("Players table empty");
                    LBox2.Items.Add("Players table empty");
                }
            }
            catch (TimeoutException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username + " connection unstable");
                this.Close();
            }
            catch (CommunicationObjectFaultedException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username + " connection unstable");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Username);
                this.Close();
            }

        }

        private void ByWins(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Players = Client.GetUsers();
                if (Players.Count > 0)
                {
                    var IS = from p in Players
                             orderby p.Value["WonCounter"] descending
                             select p.Key + ",    Points: " + p.Value["Points"] + "   Games: " + p.Value["GamesCounter"]
                       + "   Wins: " + p.Value["WonCounter"] + "   Losses: " + p.Value["Losses"];
                    LBox1.ItemsSource = IS;
                    LBox2.ItemsSource = IS;
                }
                else
                {
                    LBox1.Items.Clear();
                    LBox2.Items.Clear();
                    LBox1.Items.Add("Players table empty");
                    LBox2.Items.Add("Players table empty");
                }
            }
            catch (TimeoutException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username + " connection unstable");
                this.Close();
            }
            catch (CommunicationObjectFaultedException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username + " connection unstable");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Username);
                this.Close();
            }

        }

        private void ByLosses(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Players = Client.GetUsers();
                if (Players.Count > 0)
                {
                    var IS = from p in Players
                             orderby p.Value["Losses"] descending
                             select p.Key + ",    Points: " + p.Value["Points"] + "   Games: " + p.Value["GamesCounter"]
                      + "   Wins: " + p.Value["WonCounter"] + "   Losses: " + p.Value["Losses"];
                    LBox1.ItemsSource = IS;
                    LBox2.ItemsSource = IS;
                }
                else
                {
                    LBox1.Items.Clear();
                    LBox2.Items.Clear();
                    LBox1.Items.Add("Players table empty");
                    LBox2.Items.Add("Players table empty");
                }
            }
            catch (TimeoutException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username + " connection unstable");
                this.Close();
            }
            catch (CommunicationObjectFaultedException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username + " connection unstable");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Username);
                this.Close();
            }


        }

        private void ByGames(object sender, RoutedEventArgs e)
        {    try
            {
                
                Players = Client.GetUsers();
                if (Players.Count > 0)
                {
                    var IS = from p in Players
                             orderby p.Value["GamesCounter"] descending
                             select p.Key + ",    Points: " + p.Value["Points"] + "   Games: " + p.Value["GamesCounter"]
                      + "   Wins: " + p.Value["WonCounter"] + "   Losses: " + p.Value["Losses"];
                    LBox1.ItemsSource = IS;
                    LBox2.ItemsSource = IS;
                }
                else
                {
                    LBox1.Items.Clear();
                    LBox2.Items.Clear();
                    LBox1.Items.Add("Players table empty");
                    LBox2.Items.Add("Players table empty");
                }
            }
            catch (TimeoutException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username + " connection unstable");
                this.Close();
            }
            catch (CommunicationObjectFaultedException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username + " connection unstable");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Username );
                this.Close();
            }

        }

        /* after choosing two players we open new "CommonGames" window to show the common games of the two players */
        private void ShowGames(object sender, RoutedEventArgs e)
        {
           
            string p1, p2;
            if((LBox1.SelectedIndex==-1)|| (LBox2.SelectedIndex == -1))
            {
                MessageBox.Show("Choose two players",Username,MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
            else
            {
                if(LBox1.SelectedItem.ToString()== LBox2.SelectedItem.ToString())
                {
                    MessageBox.Show("you need to choose two different players", Username);
                }
                else
                {
                    p1 = LBox1.SelectedItem.ToString();
                    p2 = LBox2.SelectedItem.ToString();
                    p1 = p1.Substring(0, p1.IndexOf(','));
                    p2 = p2.Substring(0, p2.IndexOf(','));
                    CommonGames mainWindow = new CommonGames(Client, p1, p2);
                    mainWindow.Title = p1 + " VS " + p2;
                    mainWindow.ShowDialog();
                }
               
            }
            
        }

        
    }
}
