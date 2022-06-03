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

namespace _HJEM_IS__NOTIFICATION_SYSTEM1
{
    /// <summary>
    /// Interaction logic for Navigation.xaml
    /// </summary>
    public partial class Navigation : Window
    {
        public Navigation()
        {
            InitializeComponent();
        }

        private void btnViewMessages_Click(object sender, RoutedEventArgs e)
        {
            Messages mn = new Messages();
            mn.ShowDialog();
        }

        private void btnSendMessages_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            mn.ShowDialog();
        }
    }
}
