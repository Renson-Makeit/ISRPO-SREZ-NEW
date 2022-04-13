using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace Srez
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Sale> Sales = new List<Sale>();
        public class Sale
        {
            public DateTime DateSale { get; set; }
            public Client Client { get; set; }
            public List<Telephone> Telephones { get; set; }
        }
        public class Client
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string Patronymic { get; set; }
        }
        public class Telephone
        {
            public int Articul { get; set; }
            public string NameTelephone { get; set; }
            public string Category { get; set; }
            public decimal Cost { get; set; }
            public int Count { get; set; }
            public string Manufacturer { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnPut_Click(object sender, RoutedEventArgs e)
        {

            WebClient getClient = new WebClient();
            getClient.Encoding = Encoding.UTF8;
            string from = Convert.ToDateTime(dpStart.SelectedDate).ToString("MM.dd.yyyy");
            string to = Convert.ToDateTime(dpEnd.SelectedDate).ToString("MM.dd.yyyy");
            string data = getClient.DownloadString($"https://localhost:7100/api/Sale/Get?datestart={from}&dateend={to}");
            Sales = JsonConvert.DeserializeObject<List<Sale>>(data);
            dg.ItemsSource = Sales;
        }
    }
}
