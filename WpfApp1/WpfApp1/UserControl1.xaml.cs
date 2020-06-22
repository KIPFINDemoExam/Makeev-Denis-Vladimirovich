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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public class Product
    {
        public int id { get; set; }
        public double cost { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
    }
public partial class UserControl1 : UserControl
    {
        public UserControl1(string namee, double cosst)
        {
            InitializeComponent();
            this.Description.Text = namee;
            this.Cost.Text = cosst.ToString();
        }
    }

}
