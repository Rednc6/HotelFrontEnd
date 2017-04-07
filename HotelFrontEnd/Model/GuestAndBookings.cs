using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFrontEnd.Model
{
    class GuestAndBookings
    {

        //        public Guest GuestObj { get; set; }

        public String Name { get; set; }
        public int Guest_ID { get; set; }
        public int NumberBookings { get; set; }


        public GuestAndBookings(String gname, int gid, int bcount)
        {
            // this.GuestObj = g;
            this.Name = gname;
            this.Guest_ID = gid;
            this.NumberBookings = bcount;
        }

        public override string ToString()
        {
            return $"Name: {Name}\r\nBookings: {NumberBookings}";
        }

    }
}
