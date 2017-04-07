using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelFrontEnd.ViewModel;
using HotelFrontEnd.Persistency;
using HotelFrontEnd.Model;

namespace HotelFrontEnd.Handler
{
    class ViewBookingHandler
    {
        public ViewBookingViewModel vbvm { get; set; }

        //CTOR
        public ViewBookingHandler(ViewBookingViewModel vm)
        {
            this.vbvm = vm;
            Load();
        }

        private void Load()
        {
            vbvm.GuestAndBookings = PersistencyService.GetDBView();
        }

        public void GetGuestBookings()
        {
            vbvm.GuestBookings = PersistencyService.GetAllBookingsByGuestId(vbvm.SelectedGuestAndBookngs.Guest_ID);
        }

        public void DeleteBooking()
        {
            if (vbvm.SelectedBooking.Booking_ID != 0)
                PersistencyService.BookingCommand("delete", vbvm.SelectedBooking);
            GetGuestBookings();
        }
    }

}
