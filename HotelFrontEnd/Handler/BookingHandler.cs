using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelFrontEnd.ViewModel;

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
 //           Booking newBooking = new Booking()
        }
    } 
}
