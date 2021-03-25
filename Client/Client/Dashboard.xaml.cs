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

namespace Client
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
       

        public Dashboard(ServiceClient client, ClientCallback Callback,string username)
        {
            InitializeComponent();
            
            Client = client;
            Username = username;
            callback = Callback;
        }

        public ServiceClient Client { get; set; }
        public string Username { get; set; }
        ClientCallback callback;



        private void Showplayers(object sender, RoutedEventArgs e)
        {
            try { 
            ShowPlayers mainWindow = new ShowPlayers(Client, Username);
            mainWindow.Title = Username;
            
                mainWindow.ShowDialog();
            }
            catch (Exception)
            {
                this.Close();
            }


        }

        private void Tolobby(object sender, RoutedEventArgs e)
        {
            try
            {
                Lobby mainWindow = new Lobby(Client, callback, Username);
                mainWindow.Title = Username;
                this.Close();
                mainWindow.Show();
            }
            catch (Exception)
            {
                this.Close();
            }

        }

        private void Showgames(object sender, RoutedEventArgs e)
        {
            try
            {
                Showgames mainWindow = new Showgames(Client, Username);
                mainWindow.Title = Username;
                mainWindow.ShowDialog();
            }
            catch(Exception)
            {
                this.Close();
            }
            
                
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
