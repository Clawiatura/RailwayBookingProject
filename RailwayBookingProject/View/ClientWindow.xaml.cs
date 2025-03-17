using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;
using static MaterialDesignThemes.Wpf.Theme;

namespace RailwayBookingProject.View
{
    
    public partial class ClientWindow : Window
    {
        public ClientWindow()
        {
            InitializeComponent();
        }




        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string firstName = Name.Text; 
            string lastName = Familly.Text;   
            string email = Email.Text;       
            string password = Password.Password; 

            await RegisterUser(firstName, lastName, email, password);
        }

        private async Task RegisterUser(string firstName, string lastName, string email, string password)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var data = new
                    {
                        firstName = firstName,
                        lastName = lastName,
                        email = email,
                        password = password
                    };

                    var json = JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("http://127.0.0.1:8888/api", content);
                    response.EnsureSuccessStatusCode();
                    
                    var responseString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Успешная регистрация: " + responseString);
                    this.Close();

                    
                }
                catch (HttpRequestException ex)
                {
                    
                    Console.WriteLine("Ошибка HTTP запроса: " + ex.Message);
                    MessageBox.Show("Ошибка при регистрации: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine("Ошибка: " + ex.Message);
                    MessageBox.Show("Ошибка при регистрации: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}


