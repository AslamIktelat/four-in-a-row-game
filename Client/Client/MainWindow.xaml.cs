using Client.GameServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        ServiceClient c;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (!string.IsNullOrEmpty(tbUsername.Text) && !string.IsNullOrEmpty(tbPasswrd.Password))
            {
                ClientCallback callback=new ClientCallback();
                ServiceClient client = new ServiceClient(new InstanceContext(callback));
                c = client;
               
               
                string username = tbUsername.Text.Trim();
                string password = tbPasswrd.Password.Trim();
                try
                {
                    
                    client.ClientConnected(username, HashValue(password));
                    Dashboard mainWindow = new Dashboard(client,callback ,username);
                    mainWindow.Title = username;
                    this.Close();
                    mainWindow.Show();
                }
                catch (FaultException<WrongPasswordFault> fault)
                {
                    MessageBox.Show(fault.Detail.Details,username);
                }
                catch (TimeoutException)
                {
                    MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later",username+ " connection unstable");
                }
                catch (CommunicationObjectFaultedException)
                {
                    MessageBox.Show(" connection unstable , it took to long to get a response, unable to connect try again later", username + " connection unstable");
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), username );
                }
            }

        }

        private string HashValue(string password)
        {
            using (SHA256 hashObject = SHA256.Create())
            {
                byte[] hashBytes = hashObject.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        

    }
}
