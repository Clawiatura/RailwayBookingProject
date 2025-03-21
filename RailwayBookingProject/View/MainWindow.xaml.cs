using RailwayBookingProject.Model;
using RailwayBookingProject.View;
using RailwayBookingProject.ViewModel;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RailwayBookingProject;


public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
        
        

        private void OpenPersonalAccount_Click(object sender, RoutedEventArgs e)
    {
        JoinClient personalAccountWindow = new JoinClient();
        personalAccountWindow.Show();

    }

    private void Ideas_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Tips_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Help_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        string departureCity = Otkuda.Text;
        string arrivalCity = Kuda.Text;
        DateTime departureDate = Data.SelectedDate ?? DateTime.MinValue;

        List<Ticket> tickets = GetTickets(departureCity, arrivalCity, departureDate);
        if (tickets.Count == 0) // Проверяем, найдены ли билеты
        {
            MessageBox.Show("Билеты не найдены.");
            return;
        }
       
            

    }


    private List<Ticket> GetTickets(string departureCity, string arrivalCity, DateTime departureDate)
    {


        List<Ticket> allTickets = new List<Ticket>()
            {
                new Ticket { DepartureCity = "Москва", ArrivalCity = "Калининград", DepartureDate = new DateTime(2025, 03, 21), Price = 2500 },
                new Ticket { DepartureCity = "Москва", ArrivalCity = "Симферополь", DepartureDate = new DateTime(2024, 08, 20), Price = 5000 },
                new Ticket { DepartureCity = "Санкт-Петербург", ArrivalCity = "Москва", DepartureDate = new DateTime(2024, 08, 21), Price = 3000 },
                 new Ticket { DepartureCity = "Москва", ArrivalCity = "Санкт-Петербург", DepartureDate = new DateTime(2024, 08, 22), Price = 2500 },
                new Ticket { DepartureCity = "Москва", ArrivalCity = "Симферополь", DepartureDate = new DateTime(2024, 08, 22), Price = 5000 },
                new Ticket { DepartureCity = "Санкт-Петербург", ArrivalCity = "Москва", DepartureDate = new DateTime(2024, 08, 23), Price = 3000 }
            };
        Search personalAccountWindow = new Search();
        personalAccountWindow.Show();

        return allTickets.Where(t => t.DepartureCity == departureCity && t.ArrivalCity == arrivalCity && t.DepartureDate == departureDate).ToList();




    }

}

