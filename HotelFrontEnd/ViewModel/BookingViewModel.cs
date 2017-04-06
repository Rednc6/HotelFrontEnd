using HotelFrontEnd.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFrontEnd.ViewModel
{
    class BookingViewModel : INotifyPropertyChanged
    {
        public Singleton GuestSingl { get; set; }

        //CTOR
        public BookingViewModel()
        {
            GuestSingl = Singleton.Instance;
        }


        //PropetyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
