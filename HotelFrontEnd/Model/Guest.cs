using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFrontEnd.Model
{
    class Guest
    {
        public int Guest_ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Phone_Nr { get; set; }

        // Ctor
        public Guest(int guestID, string name, string adress, int PhoneNr)
        {
            this.Guest_ID = guestID;
            this.Name = name;
            this.Adress = adress;
            this.Phone_Nr = PhoneNr;
        }

        public override string ToString()
        {
            return $"{Name} | {Adress} | {Phone_Nr}";
        }

    }
}
