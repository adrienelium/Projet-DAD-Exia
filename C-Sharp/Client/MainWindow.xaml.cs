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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Client.FrontWcfService;

namespace Client
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            username.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string token = loginUser(username.Text, password.Password);
            if (token != "")
            {
                Manager man = new Manager(username.Text ,token);
                man.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Account's invalid","Error",MessageBoxButton.OK,MessageBoxImage.Stop);
            }
        }

        private string loginUser(string userName, string passWord)
        {
            DecryptageServiceClient service = new DecryptageServiceClient();
            LogInfo info = service.Login(new LogInfo { username = userName, password = passWord });

            if (info.token != "")
                return info.token;
            else
                return "";
        }
    }
}
