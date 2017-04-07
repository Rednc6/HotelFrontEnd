using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFrontEnd.Model
{
    class Room
    {

        public int Room_ID { get; set; }
        public int Room_Nr { get; set; }
        public Char Types { get; set; }
        public double Price { get; set; }

        public Room(int RoomID, int RoomNr, Char Types, double Price)
        {
            this.Room_ID = RoomID;
            this.Room_Nr = RoomNr;
            this.Types = Types;
            this.Price = Price;
        }

        public override string ToString()
        {
            return $"Roomnr: {Room_Nr} - {Types}\r\nPrice: {Price}";
        }

    }
}
