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
    /// Interaction logic for CommonGames.xaml
    /// </summary>
    public partial class CommonGames : Window
    {
        public CommonGames(ServiceClient client,string id1,string id2)
        {
            InitializeComponent();
            
            try 
            {
                Games = client.GetCommonGames(id1, id2);//call the function GetCommonGames to get the common games of the two players
                if (Games.CommonGames.Length > 0)
                {
                    LBox.ItemsSource = from g in Games.CommonGames select g.FParticipant + " gained " + g.FParticipantP + ", " + g.SParticipant + " gained " + g.SParticipantP + ", the winner: " + g.Winner;
                    if (Games.Champion.Equals("Equal")) textBox.Text = id1 + " 50% ," + id2 + " 50%";
                    else
                    {
                        double t1 = Games.Precentage, t2 = Games.CommonGames.Length;
                        double b = (t1 / t2) * 100;
                        b = Math.Round(b, 2);//b is a double number with 2 digits after the dot
                                             //the champion is the player who won most of the games,we print his name first
                        if (Games.Champion.Equals(id1)) { textBox.Text = id1 + " " + b + "% ," + id2 + " " + (100 - b) + "%"; }
                        else { textBox.Text = id2 + " " + b + "% ," + id1 + " " + (100 - b) + "%"; }
                    }
                }
                else
                {
                    textBox.Text = id1 + " and " + id2 + " never competed";
                }
            }
            catch (TimeoutException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", " connection unstable ");
                this.Close();
            }
            catch (CommunicationObjectFaultedException)
            {
                MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", " connection unstable ");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Close();
            }

        }
        public ServiceClient Client { get; set; }
        private CommonGamesInfo Games { get; set; }
       
    }
}
