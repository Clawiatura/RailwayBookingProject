using RailwayBookingProject.View;
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

    }

}