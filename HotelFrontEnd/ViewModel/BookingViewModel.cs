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
        private ObservableCollection<Guest> _guestCollection;

        public ObservableCollection<Guest> GuestCollection
        {
            get { return _guestCollection; }
            set { _guestCollection = value; }
        }



        //CTOR
        public BookingViewModel()
        {

        }

        //PropetyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
