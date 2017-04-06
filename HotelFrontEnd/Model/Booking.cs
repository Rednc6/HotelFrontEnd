using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelFrontEnd.Converter;

namespace HotelFrontEnd.Model
{
    class Booking
    {
        public int Booking_ID { get; set; }
        public int Guest_ID { get; set; }
        public int Room_ID { get; set; }
        public DateTime Date_From { get; set; }
        public DateTime Date_To { get; set; }

        //CTOR
        public Booking(int BookingID, int GuestID, int RoomID, DateTimeOffset DateFrom, DateTimeOffset DateTo)
        {
            this.Booking_ID = BookingID;
            this.Guest_ID = GuestID;
            this.Room_ID = RoomID;
            this.Date_From = DateTimeConverter.DateTimeArrive(DateFrom);
            this.Date_To = DateTimeConverter.DateTimeLeave(DateTo);
        }

        public Booking(int GuestID, int RoomID, DateTimeOffset DateFrom, DateTimeOffset DateTo)
        {
            this.Guest_ID = GuestID;
            this.Room_ID = RoomID;
            this.Date_From = DateTimeConverter.DateTimeArrive(DateFrom);
            this.Date_To = DateTimeConverter.DateTimeLeave(DateTo);
        }

        public override string ToString()
        {
            return $"ID: {Booking_ID} - Guest: {Guest_ID} Room: {Room_ID}";
        }


    }
}
