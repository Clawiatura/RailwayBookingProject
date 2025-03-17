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

namespace RailwayBookingProject.View
{
    /// <summary>
    /// Логика взаимодействия для JoinClient.xaml
    /// </summary>
    public partial class JoinClient : Window
    {
        public JoinClient()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
