using System;
using System.IO;
using System.Windows;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class Product
    {
        public int id { get; set; }
        public double cost { get; set; }
        public string name { get; set; }
        
    }
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            SqlConnection connect = new SqlConnection("Data Source = DESKTOP-R0P0EBE\\MSSQLSRV;Uid = makeev;Password = xxXX1234;Database = Test");
            SqlCommand com = new SqlCommand("SELECT Id,Cost,Description FROM Product", connect);
            connect.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                var ss = new Product();
                ss.id = Int32.Parse(reader.GetValue(0).ToString());
                ss.cost = Int32.Parse(reader.GetValue(1).ToString());
                ss.name = reader.GetValue(2).ToString();
                lstBox.Items.Add(ss);

            }
            connect.Close();
        }
       
        
    }
}
