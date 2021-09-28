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
using System.Windows.Threading;

using System.Data.OleDb;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace TelefonBook_version3_NetFaramefork
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
        public string clearOption;
        public string ConnectAccess = Properties.Settings.Default.Telefon_base_local;
        OleDbCommand commandAccess = new OleDbCommand();
        

        string connect = "SERVER=localhost;database=telefon_base;UID=root;password=root;";
        
        
        // Инициализация кнопок, потом убрать в отдельный класс
        private void _1_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumber.Text = PhoneNumber.Text + "1";
        }

        private void _2_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumber.Text = PhoneNumber.Text + "2";
        }

        private void _3_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumber.Text = PhoneNumber.Text + "3";
        }

        private void _4_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumber.Text = PhoneNumber.Text + "4";
        }

        private void _5_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumber.Text = PhoneNumber.Text + "5";
        }

        private void _6_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumber.Text = PhoneNumber.Text + "6";
        }

        private void _7_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumber.Text = PhoneNumber.Text + "7";
        }

        private void _8_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumber.Text = PhoneNumber.Text + "8";
        }

        private void _9_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumber.Text = PhoneNumber.Text + "9";
        }

        private void _0_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumber.Text = PhoneNumber.Text + "0";
        }
        public void MasBaz(string Baza)
        {
            string[] mas = { "1234", "123" };
        }
        private void PhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            plus.IsEnabled = false;


        }
        private void _plus_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumber.Text = PhoneNumber.Text + "+";
        }
        private void _clear_Click(object sender, RoutedEventArgs e)


        {
            clearOption = PhoneNumber.Text;
            if (clearOption.Length >= 1)
                clearOption = clearOption.Substring(0, clearOption.Length - 1);
            PhoneNumber.Text = clearOption;
            if (PhoneNumber.Text == "")
                plus.IsEnabled = true;
        }
        //Конец кнопок
        private void AddTelefon_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connect);
            OleDbConnection connectionAccess = new OleDbConnection(ConnectAccess);
            connection.Open();
            
            var temp = connection.State.ToString();
                   
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Contact (Number, Fio)  VALUES (@Number, @Fio)", connection);
            OleDbCommand cmd1 = new OleDbCommand("INSERT INTO [Contact] ([Number],[Fio]) VALUES (@Number, @Fio)", connectionAccess);
            cmd.Parameters.AddWithValue("@Number", PhoneNumber.Text);
            cmd.Parameters.AddWithValue("@Fio", AddName.Text);
            cmd1.Parameters.AddWithValue("@Number", PhoneNumber.Text);
            cmd1.Parameters.AddWithValue("@Fio", AddName.Text);
            try
            { cmd.ExecuteNonQuery(); }
            catch
            { MessageBox.Show("Please check SQL сommand string!"); }
            finally { connection.Close(); }
            
                connectionAccess.Open();
                var tempAccess = connectionAccess.State.ToString();
                try
                { cmd1.ExecuteNonQuery(); }
               catch
                { MessageBox.Show("Please check Access сommand string!"); }
                finally {connectionAccess.Close(); }
                TelegonBase.Items.Add(PhoneNumber.Text + "----_" + AddName.Text);
            
        }



        private void AddName_TouchEnter(object sender, TouchEventArgs e)
        {
          
        }

        private void AddName_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void AddName_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void TelefonDel_Click(object sender, RoutedEventArgs e)
        {
            AddName.Text = "ФИО";
            PhoneNumber.Text = "";
            TelegonBase.SelectedItem = "";
        }


        private void TelegonBase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = TelegonBase.SelectedItem.ToString();
            String word = s.Substring(0, s.IndexOf('-'));
            PhoneNumber.Text = word.ToString();
            String word2 = s.Substring(s.IndexOf('_')+1);
            AddName.Text = word2.ToString();





        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            string ConnectAccess = Properties.Settings.Default.Telefon_base_local;
            OleDbCommand commandAccess = new OleDbCommand();
            OleDbConnection connectionAccess = new OleDbConnection(ConnectAccess);
            connectionAccess.Open();

            string connect = "SERVER=localhost;database=telefon_base;UID=root;password=root;";
            MySqlConnection connection = new MySqlConnection(connect);

            connection.Open();

            var tempAccess = connectionAccess.State.ToString();
            var temp = connection.State.ToString();
            if (connection.State == ConnectionState.Open && temp == "Open")
            {
                MessageBox.Show(@"Connection working.");
            }
            else
            {
                MessageBox.Show(@"Please check MySQL connection string");
            }
            if (connectionAccess.State == ConnectionState.Open && tempAccess == "Open")
            {
                MessageBox.Show(@"Локальное подключение работает");
            }
            else
            {
                MessageBox.Show(@"Please check Access connection string");
            }
            OleDbCommand dbCommand = new OleDbCommand();
            dbCommand.Connection = connectionAccess;
            dbCommand.CommandText = "SELECT * FROM Contact";
            OleDbDataReader reader = dbCommand.ExecuteReader();
            while (reader.Read())
            {
                // string course = reader.GetFloat("Доллар").ToString();
                string b = reader["Fio"].ToString();
                string c = reader["Number"].ToString();
                TelegonBase.Items.Add( c+ "----_" +b);
            }


            connectionAccess.Close();
            
            
          
            connection.Close();
        }
    }
}

