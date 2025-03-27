using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RailwayBookingProject.Model
{
    public class Клиент : INotifyPropertyChanged
    {
        private int clientid;
        [JsonPropertyName("clientid")]
        public int Clientid
        {
            get => clientid;
            set
            {
                clientid = value;
                OnProperyChanged(nameof(Clientid));
            }
        }
        private string firstname;
        [JsonPropertyName("firstname")]
        public string Firstname
        {
            get => firstname;
            set
            {
                firstname = value;
                OnProperyChanged(nameof(Firstname));
            }
        }
        private string lastname;
        [JsonPropertyName("lastname")]
        public string Lastname
        {
            get => lastname;
            set
            {
                lastname = value;
                OnProperyChanged(nameof(Lastname));
            }
        }
        private string email;
        [JsonPropertyName("email")]
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnProperyChanged(nameof(Email));
            }
        }
        private string phone;
        [JsonPropertyName("phone")]
        public string Phone
        {
            get => phone;
            set
            {
                phone = value;
                OnProperyChanged(nameof(Phone));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnProperyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private ActionCommand registerCommand;
        public ICommand RegisterCommand => registerCommand ??= new ActionCommand(Register);

        private void Register()
        {
            throw new NotImplementedException();
        }
    }

}
