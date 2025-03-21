
using k8s.KubeConfigModels;
using RailwayBookingProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RailwayBookingProject.View
{
    
    public partial class JoinClient : Window
    {
        public JoinClient()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = login.Text; 
            string password = Password.Password; 


            using (var client = new HttpClient())
            {
                var credentials = new UserCredentials { UserName = username, Password = password };
                var json = JsonSerializer.Serialize(credentials);
                var content = new StringContent(json, Encoding.UTF8, "application/json");


                try


                {
                    var response = await client.PostAsync("YOUR_AUTH_ENDPOINT", content); // Замените YOUR_AUTH_ENDPOINT на ваш URL
                    if (response.IsSuccessStatusCode)
                    {

                        string jwtToken = await response.Content.ReadAsStringAsync();


                        
                        Properties.Settings.Default.JwtToken = jwtToken;

                        Properties.Settings.Default.Save();


                        // Откройте личный кабинет
                        Личный_Кабинет personalCabinetWindow = new Личный_Кабинет();


                        personalCabinetWindow.Show();
                        this.Close();

                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {


                        MessageBox.Show("Неверный логин или пароль.");


                    }
                    else
                    {

                        MessageBox.Show($"Ошибка: {response.StatusCode}");


                        string errorMessage = await response.Content.ReadAsStringAsync();

                        MessageBox.Show($"Ошибка: {errorMessage}");



                    }



                }

                catch (Exception ex)
                {

                    MessageBox.Show($"Ошибка: {ex.Message}");

                }




            }
        }



        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ClientWindow personalAccountWindow = new ClientWindow();
            bool? result = personalAccountWindow.ShowDialog();
            if(result == true)
            {
                //добавление данных в БД
                this.Close();
            }

            
            

        }
    }
}
