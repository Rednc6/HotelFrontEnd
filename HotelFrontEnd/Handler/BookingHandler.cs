using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelFrontEnd.ViewModel;
using HotelFrontEnd.Model;
using HotelFrontEnd.Converter;
using HotelFrontEnd.Persistency;
using Windows.UI.Popups;

namespace HotelFrontEnd.Handler
{
    class BookingHandler
    {
        public BookingViewModel BookingViewModel { get; set; }

        public BookingHandler(BookingViewModel vm)
        {
            this.BookingViewModel = vm;
        }

        public void AddBooking()
        {
            Booking newBooking = new Booking(0, Singleton.Instance.GuestCollection[Singleton.Instance.SelectedIndexCB].Guest_ID, BookingViewModel.AvailableRooms[BookingViewModel.SelectedIndexRoom].Room_ID, DateTimeConverter.DateTimeArrive(BookingViewModel.DateFrom), DateTimeConverter.DateTimeLeave(BookingViewModel.DateTo));
            PersistencyService.BookingCommand("post", newBooking);
        }
    } 
}
