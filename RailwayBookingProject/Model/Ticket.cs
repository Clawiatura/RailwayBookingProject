using Microsoft.Xaml.Behaviors.Core;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Windows.Input;

namespace RailwayBookingProject.Model
{
    public class Ticket : INotifyPropertyChanged
    {
        private int ticketid;
        [JsonPropertyName("ticketid")]
        public int TicketId
        {
            get => ticketid;
            set
            {
                ticketid = value;
                OnPropertyChanged(nameof(TicketId));
            }
        }
        public bool IsSelected { get; set; }

        private int clientid;
        [JsonPropertyName("clientid")]
        public int ClientId
        {
            get => clientid;
            set
            {
                clientid = value;
                OnPropertyChanged(nameof(ClientId));
            }
        }


        private string departureCity;
        [JsonPropertyName("departureCity")]
        public string DepartureCity
        {
            get => departureCity;
            set
            {
                departureCity = value;
                OnPropertyChanged(nameof(DepartureCity));
            }
        }

        private string arrivalCity;
        [JsonPropertyName("arrivalCity")]
        public string ArrivalCity
        {
            get => arrivalCity;
            set
            {
                arrivalCity = value;
                OnPropertyChanged(nameof(ArrivalCity));
            }
        }

        private DateTime departureDate;
        [JsonPropertyName("departureDate")]
        public DateTime DepartureDate
        {
            get => departureDate;
            set
            {
                departureDate = value;
                OnPropertyChanged(nameof(DepartureDate));
            }
        }

        private decimal price;
        [JsonPropertyName("price")]
        public decimal Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }




        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        // Пример команды (если нужна)
        private ActionCommand bookTicketCommand;
        public ICommand BookTicketCommand => bookTicketCommand ??= new ActionCommand(BookTicket);

        private void BookTicket()
        {
            // Логика бронирования билета
            throw new NotImplementedException();
        }
    }
}

