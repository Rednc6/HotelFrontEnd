using HotelFrontEnd.Model;
using HotelFrontEnd.Handler;
using HotelFrontEnd.Persistency;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFrontEnd.ViewModel
{
    class ViewBookingViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Guest> _guestAndBookings;
        public ObservableCollection<Guest> GuestAndBookings
        {
            get { return _guestAndBookings; }
            set { _guestAndBookings = value; }
        }

        private ObservableCollection<Booking> _guestBookings;
        public ObservableCollection<Booking> GuestBookings
        {
            get { return _guestBookings; }
            set { _guestBookings = value; }
        }



        //CTOR
        public ViewBookingViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
