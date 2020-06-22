using System;
using System.IO;
using System.Windows;
using System.Collections;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            SqlConnection connect = new SqlConnection("Data Source = DESKTOP-R0P0EBE\\MSSQLSRV;Uid = makeev;Password = xxXX1234;Database = Test");
            connect.Open();
            SqlCommand com = new SqlCommand("SELECT Cost,Description FROM Product", connect);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UserControl1 product = new UserControl1(reader.GetValue(2).ToString(), Int32.Parse(reader.GetValue(1).ToString()));
                    lstBox.Items.Add(product);
                }
                connect.Close();
            }
            else
            {
                MessageBox.Show("Ничего в таблице нету");
                connect.Close();
            }
        }

        private void Search_Product(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (search.Text == "Введите имя товара которое для поиска")
            {
                search.Text = "";
            }
            else
            {
                SqlConnection connect = new SqlConnection("Data Source = DESKTOP-R0P0EBE\\MSSQLSRV;Uid = makeev;Password = xxXX1234;Database = Test");
                connect.Open();
                string searchProduct = search.Text;
                SqlCommand com = new SqlCommand("SELECT Cost,Description FROM Product WHERE Description = 'searchProduct'", connect);
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    UserControl1 product = new UserControl1(reader.GetValue(2).ToString(), Int32.Parse(reader.GetValue(1).ToString()));
                    lstBox.Items.Add(product);
                    connect.Close();
                }
                else
                {
                    MessageBox.Show("Данного товара нету в наличии");
                    connect.Close();
                }
            }
        }

        private void Add_Product(object sender, RoutedEventArgs e)
        {

        }
    }
}
