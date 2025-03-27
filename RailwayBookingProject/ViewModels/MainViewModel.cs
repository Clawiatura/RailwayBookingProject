using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using RailwayBookingProject;

namespace RailwayBookingProject.ViewModels;
public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<City> Cities { get; set; }

    private int _selectedCityIdOtkuda;
    public int SelectedCityIdOtkuda
    {
        get => _selectedCityIdOtkuda;
        set
        {
            if (_selectedCityIdOtkuda != value)
            {
                _selectedCityIdOtkuda = value;
                OnPropertyChanged(nameof(SelectedCityIdOtkuda));
            }
        }
    }

    private int _selectedCityIdKuda;
    public int SelectedCityIdKuda
    {
        get => _selectedCityIdKuda;
        set
        {
            if (_selectedCityIdKuda != value)
            {
                _selectedCityIdKuda = value;
                OnPropertyChanged(nameof(SelectedCityIdKuda));
            }
        }
    }


    public MainViewModel()
    {

        Cities = new ObservableCollection<City>();

        Cities.Add(new City { Id = 1, Name = "Москва" });
        Cities.Add(new City { Id = 2, Name = "Санкт-Петербург" });
        Cities.Add(new City { Id = 3, Name = "Новосибирск" });
        Cities.Add(new City { Id = 4, Name = "Калининград" });
        Cities.Add(new City { Id = 5, Name = "Севастополь" });
        Cities.Add(new City { Id = 6, Name = "Ялта" });
        Cities.Add(new City { Id = 7, Name = "Самара" });
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
