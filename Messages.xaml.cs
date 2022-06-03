using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _HJEM_IS__NOTIFICATION_SYSTEM1
{
    /// <summary>
    /// Interaction logic for Messages.xaml
    /// </summary>
    public partial class Messages : Window
    {
        public Messages()
        {
            InitializeComponent();
            LoadAllMessages();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //LoadAllMessages();

        }

        private void LoadAllMessages()
        {
            Message msg = new Message();
            string Message = "";
            string Subject = "";
            string Date = "";
            string CustomerId = "";
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            cn.ConnectionString = "Data Source=DESKTOP-98CESK0\\ADMIN;Initial Catalog=Northwind;User ID=sa;Password=thefuture";
            List<string> str = new List<string>();
            ArrayList mylist = new ArrayList();
            cmd.Connection = cn;
            cmd.Connection.Open();
            cmd.CommandText = "Select * from CustomerMessages ";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //str.Add(dr.GetValue(0).ToString());
                msg.Messages = dr.GetValue(1).ToString();
                msg.Subject = (dr.GetValue(2).ToString());
                msg.CustomerId = (dr.GetValue(3).ToString());
                msg.MessageDate = Convert.ToDateTime(dr.GetValue(5));

            }
            mylist.Add(msg);
            dataGrid.Items.Add(mylist);
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
