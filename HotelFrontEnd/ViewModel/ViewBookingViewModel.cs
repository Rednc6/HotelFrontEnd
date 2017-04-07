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
using System.Windows.Input;
using HotelFrontEnd.Commen;

namespace HotelFrontEnd.ViewModel
{
    class ViewBookingViewModel : INotifyPropertyChanged
    {
        public ViewBookingHandler eh { get; set; }

        public ICommand DeleteCommand { get; set; }

        private ObservableCollection<GuestAndBookings> _guestAndBookings;
        public ObservableCollection<GuestAndBookings> GuestAndBookings
        {
            get { return _guestAndBookings; }
            set { _guestAndBookings = value;
               OnPropertyChanged(nameof(GuestAndBookings)) ;
            }
        }

        private ObservableCollection<Booking> _guestBookings;
        public ObservableCollection<Booking> GuestBookings
        {
            get { return _guestBookings; }
            set { _guestBookings = value;
                OnPropertyChanged(nameof(GuestBookings));
                }
        }

        private GuestAndBookings _selectedGuestAndBookings;
        public GuestAndBookings SelectedGuestAndBookngs
        {
            get { return _selectedGuestAndBookings; }
            set { _selectedGuestAndBookings = value;
                OnPropertyChanged(nameof(SelectedGuestAndBookngs));
                if(SelectedGuestAndBookngs != null) {
                eh.GetGuestBookings();
                }
            }
        }

        private Booking _selectedBooking;

        public Booking SelectedBooking
        {
            get { return _selectedBooking; }
            set { _selectedBooking = value;
                OnPropertyChanged(nameof(SelectedBooking));
            }
        }





        //CTOR
        public ViewBookingViewModel()
        {
            eh = new ViewBookingHandler(this);

            DeleteCommand = new RelayCommand(eh.DeleteBooking, null);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
