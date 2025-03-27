using Newtonsoft.Json;
using RailwayBookingProject.Model;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace RailwayBookingProject.View
{
    public partial class SearchResultWindow : Window
    {
        public SearchResultWindow()
        {
            InitializeComponent();
           
        }

        private async Task SearchTIcket(string ГородОтправоения, string ГородПрибытия, DateTime date)
        {

            using (var ticket = new HttpClient())
            {
                try
                {
                    var searchTicket = await ticket.GetAsync($"http://127.0.0.1:8888/tickets?departureCity={ГородОтправоения}&ГородПрибытия={ГородПрибытия}");


                    var data = new
                    {
                        ГородОтправления = ГородОтправоения,
                        ГородПрибытия = ГородПрибытия,
                        Дата = date

                    };

                    var json = JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    content.Headers.Add("table", "ticket");

                    var response = await ticket.PostAsync("http://127.0.0.1:8888/ticket", content);
                    response.EnsureSuccessStatusCode();

                    var responseString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Успешная регистрация: " + responseString);
                }
                catch (HttpRequestException ex)
                {

                    Console.WriteLine("Ошибка HTTP запроса: " + ex.Message);
                    MessageBox.Show("Ошибка при регистрации: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }
    }
}

            //if (selectedTicket != null)
            //{

                    //    MessageBox.Show($"Вы забронировали билет:\nОтправление: {selectedTicket.DepartureCity}\nПрибытие: {selectedTicket.ArrivalCity}\nДата: {selectedTicket.DepartureDate}\nЦена: {selectedTicket.Price}");
                    //    //Добавление в базу данных

                    //    this.Close();

                    //}
//            else
//                    {
//                MessageBox.Show("Выберите билет для бронирования.");
//            }
//        }

//        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
//        {
//        }
//    }
//}
    



