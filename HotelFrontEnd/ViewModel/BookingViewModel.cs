﻿using HotelFrontEnd.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelFrontEnd.Commen;
using HotelFrontEnd.Persistency;
using HotelFrontEnd.Handler;

namespace HotelFrontEnd.ViewModel
{
    class BookingViewModel : INotifyPropertyChanged
    {
        //RelayCommands
        public ICommand AddBookingCommand { get; set; }
        public Singleton GuestSingl { get; set; }

        private int _bookingID;
        public int BookingID
        {
            get { return _bookingID; }
            set { _bookingID = value; }
        }

        private int _guestID;
        public int GuestID
        {
            get { return _guestID; }
            set { _guestID = value;
                OnPropertyChanged(nameof(GuestID));
            }
        }

        private int _roomID;
        public int RoomID
        {
            get { return _roomID; }
            set { _roomID = value;
                OnPropertyChanged(nameof(RoomID));
            }
        }

        private DateTimeOffset _dateTo;
        public DateTimeOffset DateTo
        {
            get { return _dateTo; }
            set { _dateTo = value;
                OnPropertyChanged(nameof(DateTo));
            }
        }

        private DateTimeOffset _dateFrom;
        public DateTimeOffset DateFrom
        {
            get { return _dateFrom; }
            set { _dateFrom = value;
                OnPropertyChanged(nameof(DateFrom));
            }
        }

        public BookingHandler bh { get; set; }

        //CTOR
        public BookingViewModel()
        {
            GuestSingl = Singleton.Instance;
            bh = new BookingHandler(this);
            AddBookingCommand = new RelayCommand(bh.AddBooking, null);

            DateTime dt = System.DateTime.Now;
            DateTo = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            DateFrom = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());

        }


        //PropetyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
