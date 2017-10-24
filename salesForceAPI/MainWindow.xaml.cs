using System;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace salesForceAPI
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

        public void webStuff()
        {
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            //string username = "DummyUsername";
            String username = "sconn823@gmail.com";

            string password = "Thehobbit75hm54AginwHghqVDgub5EinsuQ";

            String credintials = username + ":" + password;
            //https://na14.salesforce.com/services/data/v24.0/sobjects
            WebRequest req = WebRequest.Create(@"https://na14.salesforce.com/services/data/");
            req.Method = "GET";
            req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(credintials));
            //req.Headers["Authorization"] = "Bearer " + ("morgan@greaterreading.com:oDQBQPC4Y1");
            req.PreAuthenticate = true;

            Stream inputReader;

            try
            {
                HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                MessageBox.Show("Character Set: " + resp.CharacterSet + "\n" + "Status Code: " + resp.StatusCode + "\n" + "Status Description: " + resp.StatusDescription);
                inputReader = resp.GetResponseStream();


                StreamReader readBoy = new StreamReader(inputReader);
                string text = readBoy.ReadToEnd();

                textBox.Text = text;

            }
            catch (WebException ex)
            {
                
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    MessageBox.Show(ex.ToString() + "\r\n\r\n" + (int)response.StatusCode);
                    Console.WriteLine(ex.ToString());
                }
                //MessageBox.Show(ex.ToString());
                //Console.WriteLine(ex.ToString()); 
            }

            
        }
    }
}
