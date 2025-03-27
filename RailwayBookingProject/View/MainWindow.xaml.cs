using Newtonsoft.Json;
using RailwayBookingProject.Model;
using RailwayBookingProject.View;
using RailwayBookingProject.ViewModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace RailwayBookingProject;


public partial class MainWindow : Window
{

    public MainWindow()
    {

        InitializeComponent();


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
    private void Otkuda_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Kuda_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
    private void Search(object sender, RoutedEventArgs e)
    {
        string ГородОтправления = Otkuda.Text;
        string ГородПрибытия = Kuda.Text;
        DateTime? selectedDate = Data.SelectedDate;


        Task.Run(() => SearchTIcket(ГородОтправления, ГородПрибытия, selectedDate));
        //SearchResultWindow resultWindow = new SearchResultWindow(); // Как в окно вставить данные?!
        //resultWindow.Show();

    }
    private async Task SearchTIcket(string ГородОтправления, string ГородПрибытия, DateTime? Data)
    {

        using (var ticket = new HttpClient())
        {
            try
            {
                //  var searchTicket = await ticket.GetAsync($"http://127.0.0.1:8888/api");

                var data = new
                {
                    ГородОтправления = ГородОтправления,
                    ГородПрибытия = ГородПрибытия,
                    DepartureDate = Data

                };


                JsonContent content = JsonContent.Create(data);
                using var request = new HttpRequestMessage(HttpMethod.Get, "http://127.0.0.1:8888/api");
                request.Headers.Add("table", "ticket");
                request.Content = content;
                HttpResponseMessage response = await ticket.SendAsync(request);
                string responseText = await response.Content.ReadAsStringAsync();
                Console.WriteLine(" " + responseText);


            }
            catch (HttpRequestException ex)
            {

                Console.WriteLine("Ошибка HTTP запроса: " + ex.Message);
                MessageBox.Show("123: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }

  





    //private List<Ticket> GetTickets(string departureCity, string arrivalCity, DateTime departureDate)
    //{
    //    List<Ticket> allTickets = new List<Ticket>()
    //        {
    //            new Ticket { DepartureCity = "Москва", ArrivalCity = "Калининград", DepartureDate = new DateTime(2025, 03, 21), Price = 2500 },
    //            new Ticket { DepartureCity = "Москва", ArrivalCity = "Симферополь", DepartureDate = new DateTime(2024, 08, 20), Price = 5000 },
    //            new Ticket { DepartureCity = "Санкт-Петербург", ArrivalCity = "Москва", DepartureDate = new DateTime(2024, 08, 21), Price = 3000 },
    //            new Ticket { DepartureCity = "Москва", ArrivalCity = "Санкт-Петербург", DepartureDate = new DateTime(2024, 08, 22), Price = 2500 },
    //            new Ticket { DepartureCity = "Москва", ArrivalCity = "Симферополь", DepartureDate = new DateTime(2024, 08, 22), Price = 5000 },
    //            new Ticket { DepartureCity = "Санкт-Петербург", ArrivalCity = "Москва", DepartureDate = new DateTime(2024, 08, 23), Price = 3000 }
    //        };

    //    return allTickets.Where(t => t.DepartureCity == departureCity && t.ArrivalCity == arrivalCity && t.DepartureDate == departureDate).ToList();
    //}

    //private void Search(object sender, RoutedEventArgs e)
    //{
    //    string departureCity = Otkuda.Text;
    //    string arrivalCity = Kuda.Text;
    //    DateTime departureDate = Data.SelectedDate ?? DateTime.Today;

    //    try
    //    {
    //        List<Ticket> tickets = GetTickets(departureCity, arrivalCity, departureDate);

    //        if (tickets.Count == 0)
    //        {
    //            MessageBox.Show("Билеты не найдены.");
    //        }
    //        else
    //        {
    //            SearchResultWindow resultWindow = new SearchResultWindow(tickets);
    //            resultWindow.ShowDialog();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show($"Ошибка: {ex.Message}");
    //    }
    //}
    //private async Task<List<Ticket>> SearchTicketsAsync(string departureCity, string arrivalCity, DateTime? departureDate)
    //{
    //    string apiUrl = $"http://127.0.0.1:8888/tickets?departureCity={departureCity}&arrivalCity={arrivalCity}";

    //    if (departureDate.HasValue)
    //    {
    //        apiUrl += $"&departureDate={departureDate.Value.ToString("yyyy-MM-dd")}";
    //    }


    //    using (HttpClient client = new HttpClient())
    //    {
    //        try
    //        {
    //            HttpResponseMessage response = await client.GetAsync(apiUrl);
    //            response.EnsureSuccessStatusCode(); 

    //            string json = await response.Content.ReadAsStringAsync();
    //            return JsonConvert.DeserializeObject<List<Ticket>>(json); 
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show($"Ошибка при запросе к серверу: {ex.Message}");
    //            return null;
    //        }
    //    }
    //}


    //private async Task<List<Ticket>> Search_Click(object sender, RoutedEventArgs e)
    //{

    //    string departureCity = Otkuda.Text;
    //    string arrivalCity = Kuda.Text;
    //    DateTime departureDate = Data.SelectedDate.Value.Date;

    //    List<Ticket> tickets = await SearchTicketsAsync(departureCity, arrivalCity, departureDate);
    //    return tickets.Where(t => t.DepartureCity == departureCity && t.ArrivalCity == arrivalCity && t.DepartureDate == departureDate).ToList();


    //}
    //private async void Search(object sender, RoutedEventArgs e)
    //{
    //string departureCity = Otkuda.Text;
    //string arrivalCity = Kuda.Text;

    //string departureDate = Data.SelectedDate?.ToString("yyyy-MM-dd");


    //try
    //{
    //    List<Ticket> tickets = await SearchTicketsAsync(departureCity, arrivalCity, departureDate); 

    //    if (tickets == null || tickets.Count == 0) 
    //    {
    //        MessageBox.Show("Билеты не найдены.");
    //    }
    //    else
    //    {
    //        SearchResultWindow resultWindow = new SearchResultWindow(tickets);
    //        resultWindow.ShowDialog();
    //    }
    //}
    //catch (Exception ex)
    //{
    //    MessageBox.Show($"Ошибка: {ex.Message}");
    //}
    //}

    //private async Task<List<Ticket>> SearchTicketsAsync(string departureCity, string arrivalCity, string departureDate)
    //{
    //    string apiUrl = $"http://127.0.0.1:8888/api/tickets?departureCity={departureCity}&arrivalCity={arrivalCity}&departureDate={departureDate}"; 

    //    if (!string.IsNullOrEmpty(departureDate))
    //    {
    //        apiUrl += $"&departureDate={departureDate}";
    //    }


    //    using (HttpClient client = new HttpClient())
    //    {
    //        try
    //        {
    //            HttpResponseMessage response = await client.GetAsync(apiUrl);
    //            response.EnsureSuccessStatusCode();

    //            string json = await response.Content.ReadAsStringAsync();

    //            if (json == "Not Found") 
    //            {
    //                return new List<Ticket>(); 
    //            }
    //            else
    //            {


    //                return JsonConvert.DeserializeObject<List<Ticket>>(json);
    //            }

    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show($"Ошибка при запросе к серверу: {ex.Message}");
    //            return null; 
    //        }
    //    }
    //}

    private void Join(object sender, RoutedEventArgs e)
    {
        JoinClient personalAccountWindow = new JoinClient();
        personalAccountWindow.Show();
    }

    
}


