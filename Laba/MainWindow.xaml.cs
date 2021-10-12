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
using Laba.Properties;
using System.Data.OleDb;

namespace Laba
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       AppliactionContext DB;

        public MainWindow()
        {
            InitializeComponent();

            DB = new AppliactionContext();
        }

       public static OleDbCommand command = new OleDbCommand();
       


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Login_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Login.Text == "Login")
            {
                Login.Text = "";
            }

        }



        private void Login_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Login.Text == "")
                Login.Text = "Login";
        }

        private void Password_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Password.Text == "Password")
            {
                Password.Text = "";
            }
        }

        private void Password_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Password.Text == "")
            {
                Password.Text = "Password";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ConnectionString = Laba.Properties.Settings.Default.ConnectionString;
            OleDbConnection connection = new OleDbConnection(ConnectionString);
            try { 
            connection.Open();
                }
            catch
            {
                MessageBox.Show("Error connection");
            }
            string pass = Password.Text;
            string login = Login.Text;
            try
            {
                OleDbCommand command = new OleDbCommand("SELECT FROM login, where login = @login and Password = @pass ", connection);

                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@pass", pass);
            }
            catch {
                MessageBox.Show("Wrong");
                    };
            if ( login == "root" && pass == "toor")
            {
             
                Window examp = new Window();
                examp.Show();

            }
            if (login == "user" && pass == "user")
            {
                MainWindow main = new MainWindow();
                main.Show();
            }
           


            connection.Close();
        }

   
    }
}
