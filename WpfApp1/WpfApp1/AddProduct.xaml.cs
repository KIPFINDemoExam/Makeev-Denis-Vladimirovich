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
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();
        }
        public void FinalAdd()
        {
            double cost = Int32.Parse(Cost.Text);
            if (cost < 0) {
                MessageBox.Show("пожалуйста,введите число которое больше нуля");
            }
            else
            {
                SqlConnection connect = new SqlConnection("Data Source = DESKTOP-R0P0EBE\\MSSQLSRV;Uid = makeev;Password = xxXX1234;Database = Test");
                connect.Open();
                string name = Name.Text;
                string des = description.Text;
                string man = manufacturer.Text;

                SqlCommand com = new SqlCommand("SELECT ,Cost,Description FROM Product WHERE Description = 'name'", connect);
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Экземпляр товара уже находится в базе данных");
                    connect.Close();
                }
                else
                {
                    SqlCommand count = new SqlCommand("SELECT * FROM Product", connect);
                    SqlDataReader countReader = count.ExecuteReader();
                    int c = 0;
                    while (reader.HasRows)
                    {
                        c++;//считаем количество строк
                    }
                    c++; //и увеличваем это количество на единицу для задания нового номера идентификатора
                    com = new SqlCommand("INSERT INTO [dbo].[Product]([Id],[Cost],[Description],[MainImagePath],[IsActive],[ManufacturerID]) VALUES ('c','cost','des','man')", connect);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Товар был успешно добавлен в базу данных");
                    connect.Close();
                }
            }
            
        }
    }
}
