using Client.GameServiceReference;
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


using System.ServiceModel;

using System.Windows.Threading;

namespace Client
{
    /// <summary>
    /// Interaction logic for Showgames.xaml
    /// </summary>
    public partial class Showgames : Window
    {
        public Showgames(ServiceClient client, string username)
        {
            InitializeComponent();
            Client = client;
            Username = username;
            try
            {
               
                Dictionary<int, GameInfo> Games = Client.GetGames();//we call the function GetGames to get all the games in the dataBase,live and not live games
                var l = from g in Games select g.Value.FParticipant + " VS " + g.Value.SParticipant;//show all the games
                if (l.Count() > 0)
                    LBox.ItemsSource = l;
                else
                    LBox.Items.Add("Games table empty");
            }
            catch (TimeoutException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username+ " connection unstable");
                this.Close();
            }
            catch (CommunicationObjectFaultedException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", Username + " connection unstable");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Username );
            }

        }
        public ServiceClient Client { get; set; }
        public string Username { get; set; }
        //show only the live games
        private void LiveGames(object sender, RoutedEventArgs e)
        {
            try
            {
               
                Dictionary<int, GameInfo> Games = Client.GetGames(); //refresh if new game just started
                LBox.ItemsSource = from g in Games where g.Value.Live == true select g.Value.FParticipant + " VS " + g.Value.SParticipant + "  The game started at: " + g.Value.Time.ToShortTimeString();
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
                MessageBox.Show(ex.ToString(), Username );
                this.Close();
            }
        }

        //show only the ended games
        private void EndedGames(object sender, RoutedEventArgs e)
        {
            try
            {
               
                Dictionary<int, GameInfo> Games = Client.GetGames(); //refresh if new game just ended
                LBox.ItemsSource = from g in Games where g.Value.Live == false select TOSTRING(g.Value);
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
                MessageBox.Show(ex.ToString(), Username);
                this.Close();
            }
        }
        private string TOSTRING(GameInfo info)
        {
            int p;
            if (info.Winner.Equals(info.FParticipant)) p = info.FParticipantP;
            else p = info.SParticipantP;
            return  info.FParticipant + " VS " + info.SParticipant + "  The winner: " + info.Winner + "  collected " +p + " points   Game date: " + info.Time.ToShortDateString();

        }
       
    }
}
