using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace _HJEM_IS__NOTIFICATION_SYSTEM1
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

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string to = "zippychep1@gmail.com";
            string from = "zippychep@gmail.com";
            //string subject = "Using the new SMTP client.";
            string subject = txtSubject.Text;
            string body = txtMessage.Text;

            MailMessage message = new MailMessage(from, to, subject, body);

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("gabriel.testapps@gmail.com", "T35tApp5"),
                EnableSsl = true
            };

            try
            {
                client.Send(message);
                Debug.WriteLine("Sent");
            }
            catch
            {
                throw;
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                string CustomerId = "BSBEV";
                // Create a SqlCommand, and identify it as a stored procedure.
                using (SqlCommand sqlCommand = new SqlCommand("sp_SaveMessage", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Add input parameter for the stored procedure and specify what to use as its value.
                    sqlCommand.Parameters.Add(new SqlParameter("@Message", SqlDbType.VarChar, 200));
                    sqlCommand.Parameters.Add(new SqlParameter("@Subject", SqlDbType.VarChar, 200));
                    sqlCommand.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 200));
                    sqlCommand.Parameters.Add(new SqlParameter("@CustomerId", SqlDbType.Int));
                    sqlCommand.Parameters["@Message"].Value = txtMessage.Text;
                    sqlCommand.Parameters["@Subject"].Value = txtSubject.Text;
                    sqlCommand.Parameters["@Status"].Value = "Sent";
                    sqlCommand.Parameters["@CustomerId"].Value = CustomerId;

                  

                    try
                    {
                        
                        connection.Open();

                        // Run the stored procedure.
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Saved successfully.");

                    }
                    catch
                    {
                        MessageBox.Show("Customer ID was not returned. Account could not be created.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
