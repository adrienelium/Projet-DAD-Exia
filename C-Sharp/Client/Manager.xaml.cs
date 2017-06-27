﻿using Client.FrontWcfService;
using Microsoft.Win32;
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
    /// Logique d'interaction pour Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        private string token;
        private string username;
        private List<string> contentfiles = new List<string>(); 
        public Manager(string username,string token)
        {
            this.token = token;
            this.username = username;
            InitializeComponent();

            DecryptageServiceClient service = new DecryptageServiceClient();
            updateState(service.GetState(username, token));
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
                    sr.Close();
                }
            }
        }

        private void updateState(State state)
        {
            state.amount = 4; // TEST VALUE

            labelcomment.Content = state.comment;
            progress.Value = state.amount;

            switch (state.amount)
            {
                case 0:
                    seeresult.IsEnabled = false;
                    browse.IsEnabled = true;
                    launchbutton.IsEnabled = false;
                    break;
                case 1:
                    seeresult.IsEnabled = false;
                    browse.IsEnabled = false;
                    launchbutton.IsEnabled = false;
                    break;
                case 2:
                    seeresult.IsEnabled = false;
                    browse.IsEnabled = false;
                    launchbutton.IsEnabled = false;
                    break;
                case 3:
                    seeresult.IsEnabled = false;
                    browse.IsEnabled = false;
                    launchbutton.IsEnabled = false;
                    break;
                case 4:
                    seeresult.IsEnabled = true;
                    browse.IsEnabled = true;
                    launchbutton.IsEnabled = false;
                    break;
                default:

                    break;

            }
        }

        private void seeresult_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Coming soon !!");
            // Open dialog with textbox for text and textbox for mail
        }

        private void launchbutton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Coming soon !!");
            // launch request and thread state
        }
    }
}