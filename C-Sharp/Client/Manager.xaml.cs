using Client.FrontWcfService;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Logique d'interaction pour Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        private string token;
        private string username;
        private List<string> contentfiles = new List<string>();
        private List<string> namefiles = new List<string>();


        public Manager(string username,string token)
        {
            this.token = token;
            this.username = username;
            InitializeComponent();


            Thread thState = new Thread(WorkState);
            thState.Start();
            
            // TODO Setup initial state
        }

        private void browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".txt";
            fileDialog.Multiselect = true;
            fileDialog.Filter = "Text documents (.txt)|*.txt";

            bool? res = fileDialog.ShowDialog();

            if (res == true)
            {
                labelfile.Content = "File(s) uploaded.";
                launchbutton.IsEnabled = true;

                foreach (string file in fileDialog.FileNames) {
                    System.IO.StreamReader sr = new System.IO.StreamReader(file);
                    contentfiles.Add(sr.ReadToEnd());
                    namefiles.Add(file);
                    sr.Close();
                }
            }
        }

        private void updateState(State state)
        {
            //state.amount = 4; // TEST VALUE

            

            Dispatcher.BeginInvoke((Action)(() =>
            {
                

                labelcomment.Content = state.comment;
                progress.Value = state.amount;

                if (state.amount == 0)
                {
                    browse.IsEnabled = true;
                    reset.IsEnabled = false;
                }
                else if (state.amount >= 10 && state.amount < 100)
                {
                    browse.IsEnabled = false;
                    launchbutton.IsEnabled = false;
                    reset.IsEnabled = true;
                }
                else if(state.amount == 100)
                {
                    browse.IsEnabled = true;
                    reset.IsEnabled = false;
                }

                if (state.resultExist)
                {
                    seeresult.IsEnabled = true;
                }
                else
                {
                    seeresult.IsEnabled = false;
                }

            }));


                

            
            
        }

        private void seeresult_Click(object sender, RoutedEventArgs e)
        {
            DecryptageServiceClient service = new DecryptageServiceClient();
            FrontWcfService.Result res = service.GetResult(username, token);

            Result fenres = new Result(res.docname, res.content, res.taux, res.key);
            fenres.Show();
        }

        private void launchbutton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bruteforce process will begin, confirm ?","Please confirm",MessageBoxButton.OKCancel,MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                DecryptageServiceClient service = new DecryptageServiceClient();
                service.LaunchDecryptProcess(contentfiles.ToArray(),namefiles.ToArray(), username, token);
            }
        }

        private void WorkState()
        {
            while(Thread.CurrentThread.IsAlive)
            {
                DecryptageServiceClient service = new DecryptageServiceClient();
                updateState(service.GetState(username, token));

                Thread.Sleep(1000);
            }
            
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bruteforce process will be interrupted, confirm ?", "Please confirm", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                DecryptageServiceClient service = new DecryptageServiceClient();
                service.Reset(username, token);
            }

            
        }
    }
}
