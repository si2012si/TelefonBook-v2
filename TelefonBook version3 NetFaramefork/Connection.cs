using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonBook_version3_NetFaramefork
{
    class Connection
    {
        private string connect = "SERVER=localhost;database=telefon_base;UID=root;password=root;";
       // public MySqlConnection onnection = new MySqlConnection(connect);
        

        public void ConSQL() 
        {
            
            MySqlConnection connection = new MySqlConnection(connect);
        }
        public void ConAccess()
        {
            string ConnectAccess = Properties.Settings.Default.Telefon_base_local;
            OleDbConnection connectionAccess = new OleDbConnection(ConnectAccess);
        }
        public void Add() 
        {
           
       //     MySqlCommand myCommand = new MySqlCommand(CommandText, connect);
        }

        public void Delite() 
        {
            string CommandText = "Наш SQL скрипт";
         //   MySqlCommand myCommand = new MySqlCommand(CommandText, connect);

        }

        
    }
}
