
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
using YamlDotNet.Serialization;

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
            string email = Email.Text; 
            string password = Password.Password;
            if (email == "admin" && password == "admin")
            {
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                this.Close();
                return; 
            }


            using (var client = new HttpClient())
            {
                var credentials = new UserCredentials { UserName = email, Password = password };
                var json = JsonSerializer.Serialize(credentials);
                var content = new StringContent(json, Encoding.UTF8, "application/json");


                try


                {
                    var response = await client.PostAsync("http://127.0.0.1:8888/api", content); 
                    if (response.IsSuccessStatusCode)
                    {

                        string jwtToken = await response.Content.ReadAsStringAsync();


                        
                        Settings1.Default.JwtToken = jwtToken;
                        Settings1.Default.Save();





                        
                        Личный_Кабинет personalCabinetWindow = new Личный_Кабинет();


                        personalCabinetWindow.Show();
                        this.Close();

                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {


                        MessageBox.Show("Неверный email или пароль.");


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
                
                this.Close();
            }

            
            

        }
    }
}
