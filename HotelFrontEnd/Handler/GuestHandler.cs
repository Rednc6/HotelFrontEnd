using HotelFrontEnd.Model;
using HotelFrontEnd.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFrontEnd.Handler
{
    class GuestHandler
    {
        public MainViewModel MainViewModel { get; set; }

        public GuestHandler(MainViewModel mvm)
        {
            this.MainViewModel = mvm;
        }

        public void AddGuest()
        {
            Guest TempGuest = new Guest(MainViewModel.GuestID, MainViewModel.GuestName, MainViewModel.GuestAdress, MainViewModel.GuestPhone);
            Singleton.Instance.AddGuest(TempGuest);
            Singleton.Instance.Load();
        }

        public void PutGuest()
        {
            Singleton.Instance.PutGuest(MainViewModel.SelectedGuest);
        }

        public void DeleteGuest()
        {
            Singleton.Instance.DeleteGuest(MainViewModel.SelectedGuest);
        }


    }
}

