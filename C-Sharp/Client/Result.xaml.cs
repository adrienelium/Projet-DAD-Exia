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
    /// Logique d'interaction pour Result.xaml
    /// </summary>
    public partial class Result : Window
    {
        public Result(string docname, string content, int taux, string key)
        {
            InitializeComponent();

            this.docname.Text = docname;
            this.content.AppendText(content);
            rate.Text = taux.ToString();

            this.key.Text = key;
        }
    }
}
